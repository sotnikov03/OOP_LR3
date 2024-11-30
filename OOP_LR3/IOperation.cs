using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR3
{
    public interface IOperation
    {
        string GetName(); // операция
        string GetSymbol(); // Символ
        bool Execute(bool arg1, bool arg2); // Результат
    }

    public class AndOperation : IOperation
    {
        public string GetName() => "AND";
        public string GetSymbol() => "&";
        public bool Execute(bool arg1, bool arg2) => arg1 && arg2;
    }

    public class OrOperation : IOperation
    {
        public string GetName() => "OR";
        public string GetSymbol() => "|";
        public bool Execute(bool arg1, bool arg2) => arg1 || arg2;
    }

    public class XorOperation : IOperation
    {
        public string GetName() => "XOR";
        public string GetSymbol() => "^";
        public bool Execute(bool arg1, bool arg2) => arg1 ^ arg2;
    }

    public class NandOperation : IOperation
    {
        public string GetName() => "Штрих Шеффера";
        public string GetSymbol() => "|";
        public bool Execute(bool arg1, bool arg2) => !(arg1 && arg2);
    }
}
