#include "pch.h"

#include "CppClassLib.h"

using namespace System::Runtime::CompilerServices;

[assembly:RuntimeCompatibilityAttribute(WrapNonExceptionThrows = false)];

void CppClassLib::MyCppClass::M1()
{
	throw (42);
}

void CppClassLib::MyCppClass::M2()
{
	throw (gcnew NotSupportedException("Managed NotSupportedException from C++/CLI"));
}

void CppClassLib::MyCppClass::M3()
{
	try
	{
		throw gcnew String("This is a string");
	}
	catch (RuntimeWrappedException^)
	{
		Console::WriteLine("RuntimeWrappedException caught in C++/CLI");
		throw;
	}
	catch (Exception^)
	{
		Console::WriteLine("General Exception caught in C++/CLI");
		throw;
	}
	catch (...)
	{
		Console::WriteLine("Catch clause in C++/CLI");
		throw;
	}
}
