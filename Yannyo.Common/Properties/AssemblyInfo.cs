using System.Reflection;
using System.Runtime.CompilerServices;
using Yannyo.Common;

//
// �йس��򼯵ĳ�����Ϣ��ͨ������
// ���Լ����Ƶġ�������Щ����ֵ���޸������
// ��������Ϣ��
//
[assembly: AssemblyTitle("Yannyo Common DLL")]
[assembly: AssemblyDescription("Yannyo �������")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Yannyo Inc.")]
#if NET1
[assembly: AssemblyProduct("Yannyo 2.5 (.NET Framework 1.1)")]
#else
[assembly: AssemblyProduct("Yannyo 2.5 (.NET Framework 2.0/3.x)")]
#endif
[assembly: AssemblyCopyright("2008, Yannyo Inc.")]
[assembly: AssemblyTrademark("Yannyo")]
[assembly: AssemblyCulture("")]

//
// ���򼯵İ汾��Ϣ������ 4 ��ֵ���:
//
//      ���汾
//      �ΰ汾 
//      �ڲ��汾��
//      �޶���
//
// ������ָ��������Щֵ,Ҳ����ʹ�á��޶��š��͡��ڲ��汾�š���Ĭ��ֵ,�����ǰ�
// ������ʾʹ�� '*':

[assembly: AssemblyVersion(Utils.ASSEMBLY_VERSION)]
[assembly: AssemblyFileVersion(Utils.ASSEMBLY_VERSION)]

//
// Ҫ�Գ��򼯽���ǩ��,����ָ��Ҫʹ�õ���Կ���йس���ǩ���ĸ�����Ϣ,��ο� 
// Microsoft .NET Framework �ĵ���
//
// ʹ����������Կ�������ǩ������Կ��
//
// ע��:
//   (*) ���δָ����Կ,����򼯲��ᱻǩ����
//   (*) KeyName ��ָ�Ѿ���װ�ڼ�����ϵ�
//      ���ܷ����ṩ����(CSP)�е���Կ��KeyFile ��ָ����
//       ��Կ���ļ���
//   (*) ��� KeyFile �� KeyName ֵ����ָ��,�� 
//       �������д���:
//       (1) ����� CSP �п����ҵ� KeyName,��ʹ�ø���Կ��
//       (2) ��� KeyName �����ڶ� KeyFile ����,�� 
//           KeyFile �е���Կ��װ�� CSP �в���ʹ�ø���Կ��
//   (*) Ҫ���� KeyFile,����ʹ�� sn.exe(ǿ����)ʵ�ù��ߡ�
//       ��ָ�� KeyFile ʱ,KeyFile ��λ��Ӧ�������
//       ��Ŀ���Ŀ¼,��
//       %Project Directory%\obj\<configuration>������,��� KeyFile λ��
//       ����ĿĿ¼,Ӧ�� AssemblyKeyFile 
//       ����ָ��Ϊ [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) ���ӳ�ǩ������һ���߼�ѡ�� - �й����ĸ�����Ϣ,����� Microsoft .NET Framework
//       �ĵ���
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
