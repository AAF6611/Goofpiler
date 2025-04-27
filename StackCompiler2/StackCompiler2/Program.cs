using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

Console.WriteLine("code begin");

// a method to get the strings

// a method to check the syntax sequences

// a method to add each string to a stack

// a method to add the variables to a table

/*
string[] legalSec = new string[4];

string illegalToken = "illegal token";
string illegalNum1 = "illegal num";
string legalWord = "legal word";
string predefinedVariable = "predefined variable";
string legalNumber = "legal number";

Dictionary<string, char> subkeypairs = new Dictionary<string, char>();
subkeypairs.Add("add", 'A'); // add x y -> x = x+y
subkeypairs.Add("sub", 'S'); // sub x y -> x = x-y
subkeypairs.Add("mul", 'M');
subkeypairs.Add("div", 'D');
subkeypairs.Add("num", 'N'); // num x 4 -> new variable x = 4
subkeypairs.Add("cln", 'F'); // cln x y -> new variable x = y
subkeypairs.Add("out", 'O'); // out x -> writes the value of x
subkeypairs.Add("bgn", 'B');
subkeypairs.Add("end", 'E');

Dictionary<string, char> mainkeypairs = new Dictionary<string, char>();
mainkeypairs.Add("code", 'C');
mainkeypairs.Add("bgn", 'B');
mainkeypairs.Add("end", 'E');

legalSec[0] = "ACC";
legalSec[1] = "SCC";
legalSec[2] = "MCC";
legalSec[3] = "DCC";
*/

Dictionary<string, double> variablePairs = new Dictionary<string, double>();
List<Stack> subcodelist = new List<Stack>();

Regex regexNumber = new Regex(@"^\d+$");
Regex regexString = new Regex(@"^\w+$");
string inputCode = string.Empty;
string outputCode = string.Empty;

void addcode(Stack stack)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'addcode'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    while (inputCode != "code end")
    {
        inputCode = Console.ReadLine();

        if (inputCode.Split(" ")[0] == "bgn")
        {
            addsubcode(inputCode.Split(" ")[1]);
            //stack.Push(substack);

        }
        switch (inputCode.Split(" ")[0])
        {
            case "num":
                stack.Push(inputCode);
                break;
            case "add":
                stack.Push(inputCode);
                break;
            case "sub":
                stack.Push(inputCode);
                break;
            case "mul":
                stack.Push(inputCode);
                break;
            case "div":
                stack.Push(inputCode);
                break;
            case "cln":
                stack.Push(inputCode);
                break;
            case "out":
                stack.Push(inputCode);
                break;
            case "inc":
                stack.Push(inputCode);
                break;
            case "dec":
                stack.Push(inputCode);
                break;
            case "lop":
                stack.Push(inputCode);
                break;
            case "cal":
                stack.Push(inputCode);
                break;
            default:
                break;
        }
    }
    stack.Push("code end");
}
void addsubcode(string subname)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'addsubcode'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    Stack substack = new Stack();
    substack.Push(subname);
    while (inputCode != "end")
    {
        inputCode = Console.ReadLine();

        if (inputCode.Split(" ")[0] == "bgn")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    error: the use of 'bgn', can not add sub program insid a sub program, ");
            Console.ForegroundColor= ConsoleColor.Gray;
        }
        else
        {
            switch (inputCode.Split(" ")[0])
            {
                case "num":
                    substack.Push(inputCode);
                    break;
                case "add":
                    substack.Push(inputCode);
                    break;
                case "sub":
                    substack.Push(inputCode);
                    break;
                case "mul":
                    substack.Push(inputCode);
                    break;
                case "div":
                    substack.Push(inputCode);
                    break;
                case "cln":
                    substack.Push(inputCode);
                    break;
                case "out":
                    substack.Push(inputCode);
                    break;
                case "inc":
                    substack.Push(inputCode);
                    break;
                case "dec":
                    substack.Push(inputCode);
                    break;
                case "lop":
                    substack.Push(inputCode);
                    break;
                case "cal":
                    substack.Push(inputCode);
                    break;
                default:
                    break;
            }
        }
    }
    //substack.Push("end");
    subcodelist.Add(substack);
    return;
}
void scanner(Stack stack)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'scanner'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    //reverse the stack:
    Stack tempstack = stack;

    Stack scanningstack = new Stack();
    object[] objects = tempstack.ToArray();
    foreach (object obj in objects)
    {   
        scanningstack.Push(obj);
    }
    //delete the first element of the tempstack which is the name
    scanningstack.Pop();

    int lines = 0;
    while (scanningstack.Count != 0)
    {
        lines++;
        object obj = scanningstack.Pop();

        string[] stringobj = obj.ToString().Split(" ");
        Console.WriteLine(obj.ToString());
        switch (stringobj[0])
        {
            case "code":
                Console.ForegroundColor = ConsoleColor.Green;
                switch (stringobj[1])
                {
                    case "begin": Console.WriteLine("    starting the code"); break;
                    case "end": Console.WriteLine("    ending the code"); break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case "num":
                variabledefiner(stringobj);
                break;
            case "add":
                if (checkvariableexists(stringobj[1]) && checkvariableexists(stringobj[2]))
                {
                    addvariables(stringobj);
                }
                break;
            case "sub":
                if (checkvariableexists(stringobj[1]) && checkvariableexists(stringobj[2]))
                {
                    subvariables(stringobj);
                }
                break;
            case "mul":
                if (checkvariableexists(stringobj[1]) && checkvariableexists(stringobj[2]))
                {
                    mulvariables(stringobj);
                }
                break;
            case "div":
                if (checkvariableexists(stringobj[1]) && checkvariableexists(stringobj[2]))
                {
                    divvariables(stringobj);
                }
                break;
            case "out":
                if (checkvariableexists(stringobj[1]))
                {
                    outvariable(stringobj);
                }
                break;
            case "inc":
                if (checkvariableexists(stringobj[1]))
                {
                    incvariable(stringobj);
                }
                break;
            case "dec":
                if (checkvariableexists(stringobj[1]))
                {
                    decvariable(stringobj);
                }
                break;
            case "lop":
                if (checksubcodeexists(stringobj[1]) && checkvariableexists(stringobj[2]))
                {
                    foreach (Stack substack in subcodelist)
                    {
                        if (substack.Contains(stringobj[1]))
                        {
                            while (variablePairs[stringobj[2]] != 0)
                            {
                                scanner(substack);
                                variablePairs[stringobj[2]] = variablePairs[stringobj[2]] - 1;
                            }
                        }
                    }
                }
                break;
            case "cal":
                if (checksubcodeexists(stringobj[1]))
                {
                    foreach (Stack substack in subcodelist)
                    {
                        if (substack.Contains(stringobj[1]))
                        {
                            scanner(substack);
                        }
                    }
                }
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    error: bad token at " + "'" + stringobj[0] + "'");
                Console.ForegroundColor = ConsoleColor.Gray;
                break;

        }
    }
    return;
}

bool checkvariableexists(string varname)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'chechvariableexists'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    if (variablePairs.ContainsKey(varname))
    {
        return true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    error: no variable with the name: " + varname);
        Console.ForegroundColor = ConsoleColor.Gray;
        return false;
    }
}
bool checksubcodeexists(string subname)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'checksubcodeexists'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    foreach (Stack substack in subcodelist)
    {
        if (substack.Contains(subname))
        {
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    error: no sub program with the name: " + subname);
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        }
    }
    return false;
}
void variabledefiner(string[] vardefinestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'variabledefiner'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    /*Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("    defining a new variable named: " + vardefinestring[1] + " and value of: " + vardefinestring[2]);
    Console.ForegroundColor = ConsoleColor.Gray;*/

    double varvalue = Convert.ToDouble(vardefinestring[2]);
    string varname = vardefinestring[1];
    if (variablePairs.ContainsKey(varname))
    {
        //Console.WriteLine("    the variable named: " + varname + "already exists, overwriting the value");
        variablePairs[varname] = varvalue;
    }
    else
    {
        variablePairs.Add(varname, varvalue);
    }
}

void addvariables(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'addvariables'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    /*Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("    adding variable named: " + varibleusestring[1] + " and variable named: " + varibleusestring[2]);
    Console.ForegroundColor = ConsoleColor.Gray;*/

    string varname1 = varibleusestring[1];
    string varname2 = varibleusestring[2];
    double answere = variablePairs.GetValueOrDefault(varname1) + variablePairs.GetValueOrDefault(varname2);
    variablePairs[varname1] = answere;
}
void subvariables(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'subvariables'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    /*Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("subtracting variable named: " + varibleusestring[1] + " and variable named: " + varibleusestring[2]);
    Console.ForegroundColor = ConsoleColor.Gray;*/

    string varname1 = varibleusestring[1];
    string varname2 = varibleusestring[2];
    double answere = variablePairs.GetValueOrDefault(varname1) - variablePairs.GetValueOrDefault(varname2);
    variablePairs[varname1] = answere;
}
void mulvariables(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'mulvariables'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    /*Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("multiplying variable named: " + varibleusestring[1] + " and variable named: " + varibleusestring[2]);
    Console.ForegroundColor = ConsoleColor.Gray;*/

    string varname1 = varibleusestring[1];
    string varname2 = varibleusestring[2];
    double answere = variablePairs.GetValueOrDefault(varname1) * variablePairs.GetValueOrDefault(varname2);
    variablePairs[varname1] = answere;
}
void divvariables(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'divvariables'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    /*Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("dividing variable named: " + varibleusestring[1] + " and variable named: " + varibleusestring[2]);
    Console.ForegroundColor = ConsoleColor.Gray;*/
    string varname1 = varibleusestring[1];
    string varname2 = varibleusestring[2];
    double answere = variablePairs.GetValueOrDefault(varname1) / variablePairs.GetValueOrDefault(varname2);
    variablePairs[varname1] = answere;
}
void outvariable(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'outvariable'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    Console.ForegroundColor = ConsoleColor.Yellow;
    string varname1 = varibleusestring[1];
    Console.WriteLine(variablePairs.GetValueOrDefault(varname1));
    Console.ForegroundColor= ConsoleColor.Gray;
}
void incvariable(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'incvariable'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    string varname1 = varibleusestring[1];
    variablePairs[varname1] = variablePairs.GetValueOrDefault(varname1)+1;
}
void decvariable(string[] varibleusestring)
{
    /*Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("    called 'decvariable'");
    Console.ForegroundColor = ConsoleColor.Gray;*/

    string varname1 = varibleusestring[1];
    variablePairs[varname1] = variablePairs.GetValueOrDefault(varname1) - 1;
}

Stack mainstack = new Stack();
mainstack.Push("code begin");
addcode(mainstack);
scanner(mainstack);