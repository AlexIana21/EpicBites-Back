namespace Utils

{
    public static class Logger
    {
        private static readonly string filePath = "log.txt";

        public static void LogError(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true)) //crear el txt si no existe y si existe escribir en el 
                {
                    writer.WriteLine("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine("Mensaje de Error: " + ex.Message);
                    writer.WriteLine(new string('-', 50)); 
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine("No se pudo escribir en el archivo de log: " + logEx.Message);
            }
        }
    }
}
