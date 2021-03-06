using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Фильмотека")]
[assembly: AssemblyDescription("Фильмотека - это специализированная программа для учета, хранения информации о фильмах и связанных с ними материалов. \r\nПрограмма  распространяется бесплатно по принципу «As is» («Как есть») без каких-либо гарантий на бесперебойную работу, отсутствие ошибок основывается на лицензии GNU GPL v2.0. \r\nПожелания, предложения и информацию об ошибках направляйте по адресу: support@it-enginer.ru")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("FilmCollection")]
[assembly: AssemblyCopyright("Copyright © 2016-2023 Бирюков Сергей")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7c7d4adc-5917-4986-8176-1e28884a678a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//
//[assembly: AssemblyVersion("1.0.0.1")]
//[assembly: AssemblyFileVersion("1.0.0.1")]
//

#if DEBUG
[assembly: AssemblyVersion("1.5.*")]
#else
[assembly: AssemblyVersion("1.3")]
#endif
