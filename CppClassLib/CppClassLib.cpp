#include "CppClassLib.h"

using namespace System::Runtime::CompilerServices;

#pragma region Region for M3()
[assembly:RuntimeCompatibilityAttribute(WrapNonExceptionThrows = true)];
#pragma endregion

void CppClassLib::MyCppClass::M1()
{
    throw (42);
}

void CppClassLib::MyCppClass::M2()
{
    throw (gcnew NotSupportedException("NotSupportedException from C++/CLI"));
}

void CppClassLib::MyCppClass::M3()
{
    try
    {
        throw gcnew String("A string has been thrown from C++/CLI. Rethrowing...");
    }
    catch (RuntimeWrappedException^)
    {
        Console::WriteLine("RuntimeWrappedException clause in C++/CLI. Rethrowing...");
        throw;
    }
    catch (Exception^)
    {
        Console::WriteLine("General Exception clause in C++/CLI. Rethrowing...");
        throw;
    }
    catch (...)
    {
        Console::WriteLine("Catch clause in C++/CLI. Rethrowing...");
        throw;
    }
}
