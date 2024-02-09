namespace doginals
{
        public class DoginalResult
        {
            public int page { get; set; }
            public int size
            {
                get; set;
            }

            public int totalPages { get; set; }

            public List<DoginalResultData> data { get; set; }
        }
}