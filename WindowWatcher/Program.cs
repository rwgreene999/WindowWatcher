using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace WindowWatcher
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            try
            {
                var exists = System.Diagnostics.Process
                    .GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location))
                    .Count() > 1;
                if (exists)
                {
                    return; 
                }

                OperationalParameters op = new OperationalParameters { };
                op.LoadParametersSettings();

                op = ParseCommandLine(op, args);

                if (op.showHelp || !op.BeenHereBefore)
                {
                    Application.Run(new HelpWindow());
                }
                if (!op.BeenHereBefore)
                {
                    op.BeenHereBefore = true;
                    op.SaveParametersSettings();
                }
                op.LoadParametersSettings();

                var form = new Form1();

                form.Op = op;
                Application.Run(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wicked happened, report this to Robert\r\n\r\nmsg=" + ex.Message, "Window Watcher"); 
            }

        }

        private static OperationalParameters ParseCommandLine(OperationalParameters defaultOp, string[] args)
        {
            bool ShowHelp = false; 
            OperationalParameters op = defaultOp.Clone();

            return op; 

            foreach (string a in args)
            {
                op.showHelp = true; 

                //string arg = a.ToLower(); 
                //if (arg.StartsWith("/") || arg.StartsWith("-")) 
                //{
                //    arg = arg.Substring(1); 
                //}
                //string[] argparts = arg.Split(new char[]{':'}); 
                //switch (argparts[0])
                //{
                //    case "recheck":
                //        op.msRecheckLyncExist = (GetNumber(argparts, 10))*1000;
                //        break;
                //    case "check":
                //        op.msSeekNewLyncs = (GetNumber(argparts, 5)) * 1000;
                //        break;

                //    case "verbose":
                //        op.verbose = true;
                //        break;

                //    case "flash":
                //        op.Flash= true;
                //        break;

                //    default:
                //        op.showHelp = true;
                //        break;
                //}



            }


            return op; 
        
        }

        private static int GetNumber(string[] argparts, int p)
        {
            if (argparts.Length < 2)
            {
                return p; 
            }
            int data = 0;
            if (!(Int32.TryParse(argparts[1], out data)))
            {
                return p; 
            }
            return data; 
        }

        
    }

}
