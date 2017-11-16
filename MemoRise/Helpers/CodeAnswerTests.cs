using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace MemoRise.Helpers
{
    public class CodeAnswerTests
    {
        private const int cardSum = 17;

        private const int cardRemaind = 18;

        public bool IsAnswerRight(int cardId, CompilerResults compilerResult)
        {
            switch (cardId)
            {
                case cardSum: return IsAnswerForCardId16Right(compilerResult);
                case cardRemaind: return IsAnswerForCardId17Right(compilerResult);
                default: return false;
            }
        }

        private bool IsAnswerForCardId16Right(CompilerResults compilerResult)
        {
            Type calcType = compilerResult.CompiledAssembly.GetType("Quiz");
            object calc = Activator.CreateInstance(calcType);

            int actualResult = (int)calcType
                .InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 0, 0 });
            int expectedResult = 0;

            int actualResult2 = (int)calcType
                .InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { -5, 7 });
            int expectedResult2 = 2;

            int actualResult3 = (int)calcType
                .InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 10, 130 });
            int expectedResult3 = 140;

            int actualResult4 = (int)calcType
                .InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { 4, -54 });
            int expectedResult4 = -50;

            int actualResult5 = (int)calcType
                .InvokeMember("Sum", BindingFlags.InvokeMethod, null, calc, new object[] { -4, -54 });
            int expectedResult5 = -58;

            if (actualResult == expectedResult &&
                actualResult2 == expectedResult2 &&
                actualResult3 == expectedResult3 &&
                actualResult4 == expectedResult4 &&
                actualResult5 == expectedResult5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsAnswerForCardId17Right(CompilerResults compilerResult)
        {
            Type calcType = compilerResult.CompiledAssembly.GetType("Quiz");
            object calc = Activator.CreateInstance(calcType);

            bool isDivideByZeroException = false;

            try
            {
                calcType.InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { 0, 0 });
            }
            catch
            {
                isDivideByZeroException = true;
            }

            int actualResult2 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { 7, 5 });
            int expectedResult2 = 2;

            int actualResult3 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { 5, 7 });
            int expectedResult3 = 5;

            int actualResult4 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { 2, -47 });
            int expectedResult4 = 2;

            int actualResult5 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { 54, -7 });
            int expectedResult5 = 5;

            int actualResult6 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { -74, 13 });
            int expectedResult6 = -9;

            int actualResult7 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { -3, 58 });
            int expectedResult7 = -3;

            int actualResult8 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { -54, -11 });
            int expectedResult8 = -10;

            int actualResult9 = (int)calcType
                .InvokeMember("Remainder", BindingFlags.InvokeMethod, null, calc, new object[] { -11, -51 });
            int expectedResult9 = -11;

            if (isDivideByZeroException &&
                actualResult2 == expectedResult2 &&
                actualResult3 == expectedResult3 &&
                actualResult4 == expectedResult4 &&
                actualResult5 == expectedResult5 &&
                actualResult6 == expectedResult6 &&
                actualResult7 == expectedResult7 &&
                actualResult8 == expectedResult8 &&
                actualResult9 == expectedResult9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}