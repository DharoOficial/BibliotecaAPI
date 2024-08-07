using System.Text;

namespace MVCAPIBiblioteca.Utils
{
    public class CreateNewFile <T>
    {
        public CreateNewFile(string pathFile, string content)
        {
            FileStream fileStream = new FileStream(pathFile, FileMode.Create);
            using (var escritor = new StreamWriter(fileStream))
            {
                escritor.WriteLine(content);

            }
        }
    }
}
