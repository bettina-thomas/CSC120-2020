using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRlatch_memory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a key: ");
            var inputData = @"C:\Data\input.txt";
            var a = 100;
            var storedValue = Storage.ReadData();
            if (storedValue > 0)
            {
                a = storedValue;
                Console.WriteLine($"Stored Value {a}");
                //Console.ReadLine();
                    var truthTableInputs = Storage.ReadInputTableData(inputData);

                    foreach (var input in truthTableInputs)
                    {

                        if (input.s == false && input.r == true)
                        {
                            Console.WriteLine($"{input.s}, {input.r}, {0}, {1}");
                        }
                        if (input.s == true && input.r == false)
                        {
                            Console.WriteLine($"{input.s}, {input.r}, {1}, {0}");
                        }
                        if (input.s && input.r == true)
                        {
                            Console.WriteLine("Error");
                        }
                        if (input.s && input.r == false)
                        {
                            Console.WriteLine($"{input.s}, {input.r}, {input.q}, {input.n}");
                        }

                    }
                Console.WriteLine($"Press any key to continue");
                Console.ReadLine();
            }
           for(int i = 0; i < 5000; i++)
            {
                Storage.SaveData(a);
                Console.WriteLine($"Print Current Stored Value{i}");
                a = i;

            }

        }
        
        
        private static void SimulateMemory()
        {
            var a = 100;
            var storedValue = Storage.ReadData();
            if (storedValue > 0)
            {
                a = storedValue;
                Console.WriteLine($"Press Any Key to continue");
                Console.ReadLine();
            }
            for (int i = storedValue; i < 10000; i++)
            {
                Storage.SaveData(a);
                Console.WriteLine($"Print Current Stored Value {i}");
                a = i;
            }

            Console.WriteLine($"Stored Value {a}");
        }
    }


    public class Storage
    {
        static string STORAGE = "Memory.txt";        //name the file
        public static bool SaveData(int val)            //save the data to file //can use to save when sr false
        {
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write(val);
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }

        public static int ReadData()        //if the file exists reads all data //Readdata reads all savedata&readdata in memory class
        {
            if (!File.Exists(STORAGE))
            {
                return 0;
            }
            var data = File.ReadAllText(STORAGE);
            int result;
            bool inValue = Int32.TryParse(data, out result);
            if (inValue)
            {
                var val = int.Parse(data);
                return val;
            }
            else
            {
                return 0;
            }
        }



        public static bool SaveInputTableData(int val1, int val2, int result1, int result2)
        {
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.WriteLine($"{val1}, {val2}, {result1}, {result2}");
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }

        public static bool SaveInputTableData(InputTable tt)
        {

            return SaveInputTableData(
                                        tt.s ? 1 : 0,
                                        tt.r ? 1 : 0,
                                        tt.q ? 1 : 0,
                                        tt.n ? 1 : 0
                                        );
        }
        public static InputTable ReadInputTable()
        {
            var inputRow = new InputTable();
            if (!File.Exists(STORAGE))
            {
                return inputRow;
            }
            var data = File.ReadAllText(STORAGE);
            var dataElements = data.Split(','); // 0,1,0,1  will be split into arrays
            inputRow.s = Utility.ConvertToBoolean(dataElements[0]); //converts split data to boolean 
            inputRow.r = Utility.ConvertToBoolean(dataElements[1]);
            inputRow.q = Utility.ConvertToBoolean(dataElements[2]);
            inputRow.n = Utility.ConvertToBoolean(dataElements[3]);
            return inputRow;

            //return inputRow;
        }

        public static List<InputTable> ReadInputTableData(string dataPath)      //takes inputs ^^ and writes to file
        {
            var inputList = new List<InputTable>();
            var fs = new FileStream(dataPath, FileMode.Open);
            var sr = new StreamReader(fs);
            var isHeader = false;
            int counter = 0;
            string line;
            while (sr.Peek() != -1)
            {
                var inputRow = new InputTable();
                line = sr.ReadLine();
                if (!isHeader)
                {
                    isHeader = !isHeader;
                    continue;
                }
                var dataElements = line.Split(',');
                inputRow.s = Utility.ConvertToBoolean(dataElements[0]);
                inputRow.r = Utility.ConvertToBoolean(dataElements[1]);
                inputRow.q = Utility.ConvertToBoolean(dataElements[2]);
                inputRow.n = Utility.ConvertToBoolean(dataElements[3]);
                inputList.Add(inputRow);
                //System.Console.WriteLine(line);

                System.Console.WriteLine(line);
                counter++;

            }
            System.Console.ReadLine();
            sr.Close(); 
            fs.Close();

            return inputList;
        }

    }
    public class Utility    //convert the 1 or 0 to boolean
    {
        public static Boolean ConvertToBoolean(string data)
        {
            return (data == "1" ? true : false);
        }
        public static int ConvertToBit(Boolean data)
        {
            return Convert.ToInt16(data);
        }
    }
    public class InputTable         //class contains each column of data
    {
        public Boolean s { get; set; }
        public Boolean r { get; set; }
        public Boolean q { get; set; }
        public Boolean n { get; set; }
    }
}
