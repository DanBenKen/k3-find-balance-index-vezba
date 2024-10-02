/* Process Array
 * Find the index in the array where the sum of the elements on the left side
 * is the same as the elements on the right
 */

int[][] matrix =
[
    [1, 2, 3, 4, 5], //1
    [5, 4, 3, 2], //2 (1)
    [1, 1, 1, 1, 1], //3 (2)
    [-1, 0, 1], //4
    [], //5
    [0, -2, 2], //6
    null
];

FindBalanceIndexInMatrix(matrix);

// Promenio sam metodu kako funkcionise kako bi bila optimizovanija. Da ne prolazimo kroz dva for-a, nego kroz jedan.
// Problem kod prlazenja kroz niz vise puta je sto to postaje "expensive" za nasu aplikaciju.
static int ProcessArray(int[] arr)
{
    // Proveravamo ako je niz prazan, vracamo -1 kao jasni indikator
    if (arr.Length == 0)
        return -1;

    int totalSum = 0;
    int leftSum = 0;

    // Racuna ukupan zbir elemenata
    foreach (int num in arr)
    {
        totalSum += num;
    }

    // Prolazi kroz niz i proverava balansirajuci indeks
    for (int i = 0; i < arr.Length; i++)
    {
        totalSum -= arr[i]; // Oduzima se trenutni element iz ukupnog zbira

        // Proveravamo da li su levi i desni zbir jednaki i vracamo trenutni indeks kao balansirajuci indeks
        if (leftSum == totalSum)
        {
            return i;
        }

        leftSum += arr[i]; // Dodaje se trenutni element u levi zbir
    }

    return -1; // Vracamo -1 kao jasni indikator da nema balansirajuceg indeksa
}

static void FindBalanceIndexInMatrix(int[][] matrix)
{
    int count = 1;

    foreach (var arr in matrix)
    {
        // Proveravamo da li je niz null
        if (arr == null)
        {
            Console.WriteLine($"Array {count} is null");
        }
        else
        {
            int res = ProcessArray(arr);

            if (res != -1)
            {
                Console.WriteLine($"Balancing index for array {count} is {res}");
            }
            else
            {
                Console.WriteLine($"Array {count} has no balancing index");
            }
        }

        count++;
    }
}