namespace MergeSortingNS
{
    /// <summary>
    /// Класс, содержащий методы сортировки.
    /// </summary>
    public class MergeSorting
    {
        /// <summary>
        /// Метод запускающий сортировку.
        /// </summary>
        /// /// <param name="array">массив для сортировки.</param>
        /// /// <returns>отсортированный массив.</returns>
        public static double[] MergeSort(double[] array)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            cancellationTokenSource.CancelAfter(100);
            var task = Task.Run(() => Sort(array, token));
            return task.Result;
        }

        private static double[] Sort(double[] sortArr, CancellationToken token)
        {
            if (sortArr.Length == 0)
            {
                throw new SortException("пустой массив");
            }

            if (sortArr.Length == 1)
            {
                return sortArr;
            }

            var task1 = Task.Run(() => Sort(sortArr.Take(sortArr.Length / 2).ToArray(), token));
            var task2 = Task.Run(() => Sort(sortArr.Skip(sortArr.Length / 2).ToArray(), token));
            if (token.IsCancellationRequested)
            {
                throw new SortException("выполнение более 100мс");
            }

            double[] firstArr = task1.Result;
            double[] secondArr = task2.Result;
            int firstArrItterator = 0;
            int secondArrItterator = 0;
            int i = 0;
            for (; firstArrItterator < firstArr.Length && secondArrItterator < secondArr.Length; i++)
            {
                if (firstArr[firstArrItterator] > secondArr[secondArrItterator])
                {
                    sortArr[i] = secondArr[secondArrItterator];
                    secondArrItterator++;
                }
                else
                {
                    sortArr[i] = firstArr[firstArrItterator];
                    firstArrItterator++;
                }

                if (token.IsCancellationRequested)
                {
                    throw new SortException("выполнение более 100мс");
                }
            }

            for (; firstArrItterator < firstArr.Length; i++)
            {
                sortArr[i] = firstArr[firstArrItterator];
                firstArrItterator++;
                if (token.IsCancellationRequested)
                {
                    throw new SortException("выполнение более 100мс");
                }
            }

            for (; secondArrItterator < secondArr.Length; i++)
            {
                sortArr[i] = secondArr[secondArrItterator];
                secondArrItterator++;
                if (token.IsCancellationRequested)
                {
                    throw new SortException("выполнение более 100мс");
                }
            }

            return sortArr;
        }

        /// <summary>
        /// класс для кастомной ошибки.
        /// </summary>
        public class SortException : Exception
        {
            public SortException(string message)
                : base(message)
            {
            }
        }
    }
}
