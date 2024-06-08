namespace LINQ_Training
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choose = 0;
            List<Product> listProduct = new ListProduct().products;
            do
            {
                Console.WriteLine("Enter from 1 to 5: ");
                choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Get name, order by decending");
                        var temp = listProduct.Where(p => !String.IsNullOrWhiteSpace(p.Name)).OrderBy(p => p.Name).ToList();
                        temp.ForEach(p => Console.WriteLine(p.Name));
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }

            } while (choose != 0);
        }
    }
}
