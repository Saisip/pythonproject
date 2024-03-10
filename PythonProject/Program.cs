using Python.Runtime;

RunScript("demopy");

static void RunScript(string scriptName)
{
    Runtime.PythonDLL = @"C:\Program Files\Python310\python310.dll";
    PythonEngine.Initialize();
    using (Py.GIL())
    {
        var user_id = new PyString("DR4913");
        var password = new PyString("A6yanAR04");
        Console.WriteLine("Enter Zerodha TFA");
        string tfa = Console.ReadLine();
        var twofa = new PyString(tfa);

        var pythonScript = Py.Import(scriptName);
        var result = pythonScript.InvokeMethod("Hello");

        var enctoken_st = pythonScript.InvokeMethod("get_enctoken", new PyObject[] { user_id, password, twofa });
        var enctoken = new PyString(enctoken_st);
        var kite = pythonScript.InvokeMethod("KiteApp", new PyObject[] { enctoken });
        var posi = kite.InvokeMethod("positions");
        //var posi = pythonScript.InvokeMethod("kite.positions");

        //string twofa = Readline   input("Enter TFA\n\n")
        //        enctoken = get_enctoken(user_id, password, twofa)
        //if not enctoken:
        //    raise Exception("Enter valid details !!!!")

        Console.WriteLine(posi);
        return ;

    }
}