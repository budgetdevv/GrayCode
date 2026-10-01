namespace GrayCode
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const uint NUM_BITS = 3;

            var grayCodes = GrayCodeNaive(NUM_BITS);

            foreach (var grayCode in grayCodes)
            {
                // Pad number with leading zeros

                var paddedGrayCode = grayCode
                    .ToString()
                    .PadLeft((int) NUM_BITS, '0');

                Console.WriteLine(paddedGrayCode);
            }
        }

        private static uint[] GrayCodeNaive(uint numBits)
        {
            if (numBits == 0)
            {
                return [];
            }

            uint[] arr = [ 0, 1 ];

            uint currentBits = 1;

            while (currentBits < numBits)
            {
                currentBits++;

                // ReSharper disable once AccessToModifiedClosure
                // Reason: Subsequent ..reversedSeq ensures the captured currentBits is correct
                var reversedSeq = arr
                    .Reverse()
                    // Pad nums with leading 1
                    .Select(x => AddLeadingOne(x, currentBits));

                arr = [ ..arr, ..reversedSeq ];
            }

            return arr;

            uint AddLeadingOne(uint num, uint currentBits)
            {
                // Add leading 1 to decimal num ( Base 10 )
                // E.x. num = 2 ( Base 10 ), currentBits = 2 -> 12 ( Base 10 )

                var leadingOne = (uint) MathF.Pow(10, currentBits - 1);

                return num + leadingOne;
            }
        }

        private static uint[] GrayCodeByFormula(uint numBits)
        {
            // TODO: Work on this

            throw new NotImplementedException();
        }
    }
}