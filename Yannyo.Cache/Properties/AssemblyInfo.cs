using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Yannyo.Common;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("Yannyo Cache DLL")]
[assembly: AssemblyDescription("Yannyo 缓存类库")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Yannyo Inc.")]
#if NET1
[assembly: AssemblyProduct("Yannyo (.NET Framework 1.1)")]
#else
[assembly: AssemblyProduct("Yannyo (.NET Framework 2.0/3.x)")]
#endif
[assembly: AssemblyCopyright("2008, Yannyo Inc.")]
[assembly: AssemblyTrademark("Yannyo")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("bc9a6b75-5f62-4298-a6b9-40e8b4287b8c")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“修订号”和“内部版本号”的默认值，
// 方法是按如下所示使用“*”:
[assembly: AssemblyVersion(Utils.ASSEMBLY_VERSION)]
[assembly: AssemblyFileVersion(Utils.ASSEMBLY_VERSION)]
