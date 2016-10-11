
/****** Object:  Table [dbo].[tbFeesSubjectMoneyDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbFeesSubjectMoneyDataInfo](
	[FeesSubjectMoneyDataID] [int] IDENTITY(1,1) NOT NULL,
	[FeesSubjectClassID] [int] NOT NULL,
	[bMoney] [numeric](18, 6) NOT NULL,
	[eMoney] [numeric](18, 6) NOT NULL,
	[fUpdateDateTime] [datetime] NOT NULL,
	[fAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbFeesSubjectInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbFeesSubjectInfo](
	[FeesSubjectID] [int] IDENTITY(1,1) NOT NULL,
	[FeesSubjectClassID] [int] NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[fCode] [varchar](50) NULL,
	[fDebitCredit] [int] NOT NULL,
	[fAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用科目编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbFeesSubjectInfo', @level2type=N'COLUMN',@level2name=N'FeesSubjectID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbFeesSubjectInfo', @level2type=N'COLUMN',@level2name=N'fName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbFeesSubjectInfo', @level2type=N'COLUMN',@level2name=N'fAppendTime'
GO
/****** Object:  Table [dbo].[tbFeesSubjectClassInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbFeesSubjectClassInfo](
	[FeesSubjectClassID] [int] IDENTITY(1,1) NOT NULL,
	[cParentID] [int] NOT NULL,
	[cClassName] [varchar](50) NOT NULL,
	[cOrder] [int] NOT NULL,
	[cAppendTime] [datetime] NOT NULL,
	[cDirection] [int] NOT NULL,
	[cCode] [varchar](50) NOT NULL,
	[cType] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbEventLogInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbEventLogInfo](
	[EventLogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[eMSG] [varchar](1024) NOT NULL,
	[eAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbEventLogInfo', @level2type=N'COLUMN',@level2name=N'EventLogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbEventLogInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbEventLogInfo', @level2type=N'COLUMN',@level2name=N'eMSG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbEventLogInfo', @level2type=N'COLUMN',@level2name=N'eAppendTime'
GO
/****** Object:  Table [dbo].[tbErpOrderInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbErpOrderInfo](
	[ErpOrderID] [int] IDENTITY(1,1) NOT NULL,
	[O_ID] [int] NOT NULL,
	[O_ORDERNUM] [varchar](50) NOT NULL,
	[O_CREATETIME] [datetime] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[P_ID] [int] NOT NULL,
	[P_CODE] [varchar](50) NOT NULL,
	[P_NAME] [varchar](128) NOT NULL,
	[P_RULES] [varchar](50) NOT NULL,
	[S_ID] [int] NOT NULL,
	[S_PRICE] [money] NOT NULL,
	[S_QUANTITY] [int] NOT NULL,
	[S_TOTAL] [money] NOT NULL,
	[StoresID] [int] NOT NULL,
	[C_CODE] [varchar](50) NULL,
	[C_NAME] [varchar](128) NOT NULL,
	[R_NAME] [varchar](50) NOT NULL,
	[R_ID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[SA_NAME] [varchar](50) NOT NULL,
	[PROMOTIONS] [int] NOT NULL,
	[IsCheck] [int] NOT NULL,
	[storageid] [int] NOT NULL,
	[eAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'ErpOrderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据头系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'O_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据头编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'O_ORDERNUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据头创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'O_CREATETIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erp产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'P_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'P_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'P_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'P_RULES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'S_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子单金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'S_PRICE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子单数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'S_QUANTITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子单总额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'S_TOTAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'C_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'R_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'R_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务员名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'SA_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbErpOrderInfo', @level2type=N'COLUMN',@level2name=N'eAppendTime'
GO
/****** Object:  Table [dbo].[tbDepartmentsClassInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbDepartmentsClassInfo](
	[DepartmentsClassID] [int] IDENTITY(1,1) NOT NULL,
	[dParentID] [int] NOT NULL,
	[dClassName] [varchar](50) NOT NULL,
	[dOrder] [int] NOT NULL,
	[dAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbDataToMailInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbDataToMailInfo](
	[DataToMaillID] [int] IDENTITY(1,1) NOT NULL,
	[dDataType] [int] NOT NULL,
	[dDateType] [int] NOT NULL,
	[dState] [int] NOT NULL,
	[dEmail] [varchar](512) NOT NULL,
	[dAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbCustomersClassInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCustomersClassInfo](
	[CustomersClassID] [int] IDENTITY(1,1) NOT NULL,
	[cParentID] [int] NOT NULL,
	[cClassName] [varchar](50) NOT NULL,
	[cOrder] [int] NOT NULL,
	[cAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbCostValenceInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCostValenceInfo](
	[CostVelenceID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[cPrice] [money] NOT NULL,
	[cDateTime] [datetime] NOT NULL,
	[cAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCostValenceInfo', @level2type=N'COLUMN',@level2name=N'CostVelenceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCostValenceInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCostValenceInfo', @level2type=N'COLUMN',@level2name=N'cPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCostValenceInfo', @level2type=N'COLUMN',@level2name=N'cDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCostValenceInfo', @level2type=N'COLUMN',@level2name=N'cAppendTime'
GO
/****** Object:  Table [dbo].[tbCertificateWorkingLogInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCertificateWorkingLogInfo](
	[CertificateWorkingLogID] [int] IDENTITY(1,1) NOT NULL,
	[CertificateID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[cType] [int] NOT NULL,
	[cMsg] [varchar](512) NULL,
	[cAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作记录编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'CertificateWorkingLogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属凭证编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'CertificateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'cType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'cMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbCertificateWorkingLogInfo', @level2type=N'COLUMN',@level2name=N'cAppendTime'
GO
/****** Object:  Table [dbo].[tbCertificatePicInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCertificatePicInfo](
	[CertificatePicID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CertificateID] [int] NOT NULL,
	[cCode] [varchar](32) NOT NULL,
	[cPic] [varchar](512) NOT NULL,
	[cAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbCertificateInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCertificateInfo](
	[CertificateID] [int] IDENTITY(1,1) NOT NULL,
	[cCode] [varchar](50) NOT NULL,
	[cNumber] [int] NOT NULL,
	[cMoney] [money] NOT NULL,
	[cType] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[cRemake] [varchar](512) NULL,
	[toObject] [int] NOT NULL,
	[toObjectID] [int] NOT NULL,
	[cObject] [int] NOT NULL,
	[cObjectID] [int] NOT NULL,
	[cState] [int] NOT NULL,
	[BankID] [int] NOT NULL,
	[cDateTime] [datetime] NOT NULL,
	[cAppendTime] [datetime] NOT NULL,
	[cSteps] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbCertificateDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbCertificateDataInfo](
	[CertificateDataID] [int] IDENTITY(1,1) NOT NULL,
	[CertificateID] [int] NOT NULL,
	[FeesSubjectID] [int] NOT NULL,
	[cdName] [varchar](512) NOT NULL,
	[toObject] [int] NOT NULL,
	[toObjectID] [int] NOT NULL,
	[cdMoney] [money] NOT NULL,
	[cdMoneyB] [money] NOT NULL,
	[cdRemake] [varchar](512) NULL,
	[cdAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbBankMoneyInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBankMoneyInfo](
	[BankMoneyID] [int] IDENTITY(1,1) NOT NULL,
	[BankID] [int] NOT NULL,
	[bMoney] [money] NOT NULL,
	[bUpdateTime] [datetime] NOT NULL,
	[bAppendTime] [datetime] NOT NULL,
	[isBegin] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbBankInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbBankInfo](
	[BankID] [int] IDENTITY(1,1) NOT NULL,
	[bName] [varchar](128) NOT NULL,
	[bAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbBankCapitalAccountInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBankCapitalAccountInfo](
	[CapitalAccountID] [int] IDENTITY(1,1) NOT NULL,
	[cAccountName] [nvarchar](500) NOT NULL,
	[FeesSubjectClassID] [int] NOT NULL,
	[cAccountMoney] [money] NOT NULL,
	[cType] [int] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pUpdateTime] [datetime] NOT NULL,
	[cDirection] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CapitalAccountID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbARMoneyInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbARMoneyInfo](
	[ARMoneyID] [int] IDENTITY(1,1) NOT NULL,
	[ARObjID] [int] NOT NULL,
	[ARObjType] [int] NOT NULL,
	[aAMoney] [money] NOT NULL,
	[aBMoney] [money] NOT NULL,
	[aOpenDate] [datetime] NULL,
	[aOpenMoney] [money] NULL,
	[aDate] [datetime] NULL,
	[aActualDate] [datetime] NULL,
	[aActualMoney] [money] NOT NULL,
	[aUpdateTime] [datetime] NOT NULL,
	[aSteps] [int] NOT NULL,
	[aErpOrderIDStr] [ntext] NULL,
	[aAppendTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbAPMoneyInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbAPMoneyInfo](
	[APMoneyID] [int] IDENTITY(1,1) NOT NULL,
	[APObjID] [int] NOT NULL,
	[APObjType] [int] NOT NULL,
	[aNPMoney] [money] NOT NULL,
	[aPMoney] [money] NOT NULL,
	[aPayMoney] [money] NOT NULL,
	[aOtherMoney] [money] NOT NULL,
	[aReMake] [varchar](256) NULL,
	[FeesSubjectID] [int] NOT NULL,
	[aErpOrderIDStr] [ntext] NULL,
	[aDoDateTime] [datetime] NOT NULL,
	[aAppendTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_M_VideoInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_VideoInfo](
	[m_VideoInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[video_id] [bigint] NOT NULL,
	[url] [varchar](512) NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[num_iid] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'm_VideoInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属对象系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统视频编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'video_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'绝对地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频记录所关联的商品的数字id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_VideoInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
/****** Object:  Table [dbo].[tb_M_UserInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_UserInfo](
	[m_UserInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[user_id] [bigint] NOT NULL,
	[uid] [varchar](50) NOT NULL,
	[nick] [varchar](50) NOT NULL,
	[sex] [char](1) NOT NULL,
	[created] [datetime] NOT NULL,
	[last_visit] [datetime] NOT NULL,
	[birthday] [varchar](50) NOT NULL,
	[type] [char](1) NOT NULL,
	[has_more_pic] [bit] NOT NULL,
	[item_img_num] [int] NOT NULL,
	[item_img_size] [int] NOT NULL,
	[prop_img_num] [int] NOT NULL,
	[prop_img_sizec] [int] NOT NULL,
	[auto_repost] [varchar](50) NOT NULL,
	[promoted_type] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[alipay_bind] [varchar](50) NOT NULL,
	[consumer_protection] [int] NOT NULL,
	[alipay_account] [varchar](50) NOT NULL,
	[alipay_no] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[magazine_subscribe] [bit] NOT NULL,
	[vertical_market] [varchar](128) NULL,
	[avatar] [varchar](256) NULL,
	[online_gaming] [bit] NOT NULL,
	[m_AppendTime] [datetime] NOT NULL,
	[m_UpdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'm_UserInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店用户系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店用户系统内部编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'uid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'last_visit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否购买多图服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'has_more_pic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可上传图片数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'item_img_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上传单张图片大小' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'item_img_size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可上传属性图片数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'prop_img_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单张销售属性图片最大容量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'prop_img_sizec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否受限制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'auto_repost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有无实名认证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'promoted_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝绑定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'alipay_bind'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否消保' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'consumer_protection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'alipay_account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'alipay_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否订阅淘天下' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'magazine_subscribe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户参与垂直市场类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'vertical_market'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否网游用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'online_gaming'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'm_AppendTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_UserInfo', @level2type=N'COLUMN',@level2name=N'm_UpdateTime'
GO
/****** Object:  Table [dbo].[tb_M_TradeInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_TradeInfo](
	[m_TradeInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[seller_nick] [varchar](50) NOT NULL,
	[buyer_nick] [varchar](50) NOT NULL,
	[title] [varchar](512) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[num_iid] [bigint] NOT NULL,
	[price] [money] NOT NULL,
	[pic_path] [varchar](512) NOT NULL,
	[num] [int] NOT NULL,
	[tid] [bigint] NOT NULL,
	[buyer_message] [varchar](512) NULL,
	[shipping_type] [varchar](50) NOT NULL,
	[alipay_no] [varchar](50) NOT NULL,
	[payment] [money] NOT NULL,
	[discount_fee] [money] NOT NULL,
	[adjust_fee] [money] NOT NULL,
	[snapshot_url] [varchar](512) NOT NULL,
	[snapshot] [varchar](512) NULL,
	[status] [varchar](50) NOT NULL,
	[seller_rate] [bit] NOT NULL,
	[buyer_rate] [bit] NOT NULL,
	[buyer_memo] [varchar](512) NULL,
	[seller_memo] [varchar](512) NULL,
	[trade_memo] [varchar](512) NULL,
	[pay_time] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[buyer_obtain_point_fee] [int] NOT NULL,
	[point_fee] [int] NOT NULL,
	[real_point_fee] [int] NOT NULL,
	[total_fee] [money] NOT NULL,
	[post_fee] [money] NOT NULL,
	[buyer_alipay_no] [varchar](128) NOT NULL,
	[receiver_name] [varchar](50) NOT NULL,
	[receiver_state] [varchar](50) NOT NULL,
	[receiver_city] [varchar](50) NOT NULL,
	[receiver_district] [varchar](50) NOT NULL,
	[receiver_address] [varchar](512) NOT NULL,
	[receiver_zip] [varchar](50) NOT NULL,
	[receiver_mobile] [varchar](50) NOT NULL,
	[receiver_phone] [varchar](50) NOT NULL,
	[consign_time] [datetime] NOT NULL,
	[buyer_email] [varchar](50) NOT NULL,
	[commission_fee] [money] NOT NULL,
	[seller_alipay_no] [varchar](128) NOT NULL,
	[seller_mobile] [varchar](50) NOT NULL,
	[seller_phone] [varchar](50) NOT NULL,
	[seller_name] [varchar](50) NOT NULL,
	[seller_email] [varchar](128) NOT NULL,
	[available_confirm_fee] [money] NOT NULL,
	[has_post_fee] [bit] NOT NULL,
	[received_payment] [money] NOT NULL,
	[cod_fee] [money] NOT NULL,
	[cod_status] [varchar](50) NOT NULL,
	[timeout_action_time] [datetime] NOT NULL,
	[is_3D] [bit] NOT NULL,
	[buyer_flag] [int] NOT NULL,
	[seller_flag] [int] NOT NULL,
	[promotion] [varchar](512) NOT NULL,
	[invoice_name] [varchar](512) NOT NULL,
	[trade_from] [varchar](50) NOT NULL,
	[alipay_url] [varchar](512) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'm_TradeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'end_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易类型列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'pic_path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'tid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家留言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'shipping_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝交易号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'alipay_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统优惠金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'discount_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家手工调整金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'adjust_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易快照地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'snapshot_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快照详细信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'snapshot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家是否已评价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家是否已评价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'trade_memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'pay_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家获得积分,返点的积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_obtain_point_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家使用积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'point_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家实际使用积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'real_point_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'total_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'post_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家支付宝账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_alipay_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的所在省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的所在城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的所在地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_district'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的详细地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_zip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人的电话号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'receiver_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家发货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'consign_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家邮件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易佣金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'commission_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家支付宝帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_alipay_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家邮件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易中剩余的确认收货金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'available_confirm_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否包含邮费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'has_post_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家实际收到的支付宝打款金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'received_payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货到付款服务费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'cod_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货到付款物流状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'cod_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超时到期时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'timeout_action_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是3D淘宝交易' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'is_3D'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家备注旗帜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'buyer_flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家备注旗帜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'seller_flag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易促销详细信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'promotion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发票抬头' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'invoice_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'trade_from'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建交易接口成功后，返回的支付url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TradeInfo', @level2type=N'COLUMN',@level2name=N'alipay_url'
GO
/****** Object:  Table [dbo].[tb_M_TimeOutInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_M_TimeOutInfo](
	[m_TimeOutInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[remind_type] [int] NOT NULL,
	[exist_timeout] [bit] NOT NULL,
	[timeout] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易超时编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'm_TimeOutInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提醒的类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'remind_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否存在超时' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'exist_timeout'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'超时时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_TimeOutInfo', @level2type=N'COLUMN',@level2name=N'timeout'
GO
/****** Object:  Table [dbo].[tb_M_StockInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_M_StockInfo](
	[m_StockInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[m_Num] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[m_UpdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品库存信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_StockInfo', @level2type=N'COLUMN',@level2name=N'm_StockInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属配置信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_StockInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属商品信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_StockInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_StockInfo', @level2type=N'COLUMN',@level2name=N'm_Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_StockInfo', @level2type=N'COLUMN',@level2name=N'm_UpdateTime'
GO
/****** Object:  Table [dbo].[tb_M_ShoppingAddressInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ShoppingAddressInfo](
	[m_ShoppingAddressInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[address_id] [int] NOT NULL,
	[receiver_name] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[mobile] [varchar](50) NOT NULL,
	[is_default] [bit] NOT NULL,
	[created] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易地址系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'm_ShoppingAddressInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'address_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'receiver_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否为默认收货地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'is_default'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShoppingAddressInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
/****** Object:  Table [dbo].[tb_M_ShippingInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ShippingInfo](
	[m_ShippingInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_TradeInfoID] [int] NOT NULL,
	[tid] [bigint] NOT NULL,
	[seller_nick] [varchar](50) NOT NULL,
	[buyer_nick] [varchar](50) NOT NULL,
	[delivery_start] [datetime] NOT NULL,
	[delivery_end] [datetime] NOT NULL,
	[out_sid] [varchar](50) NOT NULL,
	[item_title] [varchar](128) NOT NULL,
	[receiver_name] [varchar](50) NOT NULL,
	[receiver_phone] [varchar](50) NOT NULL,
	[receiver_mobile] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[freight_payer] [varchar](50) NOT NULL,
	[seller_confirm] [varchar](10) NOT NULL,
	[company_name] [varchar](128) NOT NULL,
	[is_success] [bit] NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'm_ShippingInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属交易编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'm_TradeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'tid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'seller_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'buyer_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预约取货开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'delivery_start'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预约取货结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'delivery_end'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'out_sid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'item_title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'receiver_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'receiver_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'receiver_mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'谁承担运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'freight_payer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否确认发货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'seller_confirm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'company_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货是否成功' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'is_success'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ShippingInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
/****** Object:  Table [dbo].[tb_M_SendGoodsInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_SendGoodsInfo](
	[m_SendGoodsID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[m_TradeInfoID] [varchar](256) NOT NULL,
	[receiver_name] [varchar](50) NOT NULL,
	[receiver_state] [varchar](50) NULL,
	[receiver_city] [varchar](50) NULL,
	[receiver_district] [varchar](50) NULL,
	[receiver_address] [varchar](256) NOT NULL,
	[receiver_zip] [varchar](50) NULL,
	[receiver_mobile] [varchar](50) NULL,
	[receiver_phone] [varchar](50) NULL,
	[from_name] [varchar](50) NOT NULL,
	[from_state] [varchar](50) NULL,
	[from_city] [varchar](50) NULL,
	[from_district] [varchar](50) NULL,
	[from_address] [varchar](256) NOT NULL,
	[from_zip] [varchar](50) NULL,
	[from_mobile] [varchar](50) NULL,
	[from_phone] [varchar](50) NULL,
	[mExpName] [int] NOT NULL,
	[mExpNO] [varchar](50) NULL,
	[mMemo] [varchar](256) NULL,
	[mState] [int] NOT NULL,
	[mAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'm_SendGoodsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'OrderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'm_TradeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_district'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_zip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'receiver_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_district'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_zip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发件人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'from_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'mExpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'mExpNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'mMemo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'mState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_SendGoodsInfo', @level2type=N'COLUMN',@level2name=N'mAppendTime'
GO
/****** Object:  Table [dbo].[tb_M_PropImgInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_PropImgInfo](
	[m_PropImgInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[m_id] [bigint] NOT NULL,
	[product_id] [bigint] NOT NULL,
	[props] [varchar](512) NOT NULL,
	[url] [varchar](512) NOT NULL,
	[position] [int] NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品属性图片系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'm_PropImgInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属对象系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品属性图片编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片所属产品的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性串(pid:vid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_PropImgInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
/****** Object:  Table [dbo].[tb_M_ProductInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ProductInfo](
	[m_ProductInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[product_id] [bigint] NOT NULL,
	[outer_id] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[tsc] [varchar](50) NOT NULL,
	[cid] [varchar](50) NOT NULL,
	[cat_name] [varchar](128) NOT NULL,
	[props] [varchar](512) NOT NULL,
	[props_str] [varchar](512) NOT NULL,
	[binds_str] [varchar](512) NOT NULL,
	[sale_props_str] [varchar](512) NOT NULL,
	[name] [varchar](128) NOT NULL,
	[binds] [varchar](512) NOT NULL,
	[sale_props] [varchar](512) NOT NULL,
	[price] [money] NOT NULL,
	[m_desc] [ntext] NULL,
	[pic_url] [varchar](512) NOT NULL,
	[modified] [datetime] NOT NULL,
	[status] [int] NOT NULL,
	[collect_num] [int] NOT NULL,
	[m_level] [int] NOT NULL,
	[pic_path] [varchar](512) NOT NULL,
	[vertical_market] [int] NOT NULL,
	[customer_props] [varchar](512) NULL,
	[property_alias] [varchar](512) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店产品系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'm_ProductInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erp系统产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'outer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'淘宝标准产品编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'tsc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品类目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'cat_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的关键属性列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的关键属性字符串列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'props_str'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的非关键属性字符串列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'binds_str'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的销售属性字符串列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'sale_props_str'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的非关键属性列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'binds'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的销售属性列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'sale_props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的市场价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'm_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的主图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'pic_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的collect次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'collect_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品的级别level' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'm_level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品对应的图片路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'pic_path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'垂直市场' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'vertical_market'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户自定义属性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'customer_props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售属性值别名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ProductInfo', @level2type=N'COLUMN',@level2name=N'property_alias'
GO
/****** Object:  Table [dbo].[tb_M_OrderRefundInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_OrderRefundInfo](
	[m_OrderRefundInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[num_iid] [int] NOT NULL,
	[refund_id] [int] NOT NULL,
	[tid] [int] NOT NULL,
	[oid] [int] NOT NULL,
	[alipay_no] [varchar](50) NOT NULL,
	[total_fee] [money] NOT NULL,
	[buyer_nick] [varchar](50) NOT NULL,
	[seller_nick] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[order_status] [varchar](50) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[good_status] [varchar](50) NOT NULL,
	[has_good_return] [bit] NOT NULL,
	[refund_fee] [money] NOT NULL,
	[payment] [money] NOT NULL,
	[reason] [varchar](50) NOT NULL,
	[m_desc] [varchar](512) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[price] [money] NOT NULL,
	[num] [int] NOT NULL,
	[good_return_time] [datetime] NOT NULL,
	[company_name] [varchar](50) NOT NULL,
	[sid] [varchar](50) NOT NULL,
	[address] [varchar](512) NULL,
	[shipping_type] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'm_OrderRefundInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'refund_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店交易单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'tid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'oid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝交易号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'alipay_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易总金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'total_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'buyer_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'seller_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款申请时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款对应的订单交易状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'order_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'good_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家是否需要退货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'has_good_return'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退还金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'refund_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付给卖家的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'reason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'm_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'good_return_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'company_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货运单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'sid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家收货地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderRefundInfo', @level2type=N'COLUMN',@level2name=N'shipping_type'
GO
/****** Object:  Table [dbo].[tb_M_OrderPromotionDetailInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_OrderPromotionDetailInfo](
	[m_Order_PromotionDetailInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[m_id] [int] NOT NULL,
	[promotion_name] [varchar](50) NOT NULL,
	[discount_fee] [money] NOT NULL,
	[gift_item_name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'm_Order_PromotionDetailInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠信息名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'promotion_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优惠金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'discount_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'满就送商品时，所送商品的名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderPromotionDetailInfo', @level2type=N'COLUMN',@level2name=N'gift_item_name'
GO
/****** Object:  Table [dbo].[tb_M_OrderInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_OrderInfo](
	[m_OrderInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_TradeInfoID] [int] NOT NULL,
	[num_iid] [bigint] NOT NULL,
	[total_fee] [money] NOT NULL,
	[discount_fee] [money] NOT NULL,
	[adjust_fee] [money] NOT NULL,
	[sku_id] [varchar](50) NOT NULL,
	[sku_properties_name] [varchar](512) NOT NULL,
	[item_meal_name] [varchar](512) NOT NULL,
	[num] [int] NOT NULL,
	[title] [varchar](512) NOT NULL,
	[price] [money] NOT NULL,
	[pic_path] [varchar](512) NOT NULL,
	[seller_nick] [varchar](50) NOT NULL,
	[buyer_nick] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[refund_status] [varchar](50) NOT NULL,
	[oid] [bigint] NOT NULL,
	[outer_iid] [varchar](50) NOT NULL,
	[outer_sku_id] [varchar](50) NOT NULL,
	[payment] [money] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[snapshot_url] [varchar](512) NOT NULL,
	[snapshot] [varchar](1024) NULL,
	[timeout_action_time] [datetime] NOT NULL,
	[buyer_rate] [bit] NOT NULL,
	[seller_rate] [bit] NOT NULL,
	[refund_id] [varchar](50) NULL,
	[seller_type] [varchar](50) NOT NULL,
	[modified] [datetime] NOT NULL,
	[cid] [bigint] NOT NULL,
	[is_oversold] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'm_OrderInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属交易编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'm_TradeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'total_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单优惠金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'discount_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手工调整金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'adjust_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品的最小库存单位Sku的id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'sku_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SKU的值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'sku_properties_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'套餐的值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'item_meal_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'pic_path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'seller_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'buyer_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'refund_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'oid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家外部编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'outer_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部网店自己定义的Sku编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'outer_sku_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家实付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'payment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单快照URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'snapshot_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单快照详细信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'snapshot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单超时到期时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'timeout_action_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家是否已评价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'buyer_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家是否已平价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'seller_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退款中的退款ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'refund_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'seller_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易商品对应的类目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否超卖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_OrderInfo', @level2type=N'COLUMN',@level2name=N'is_oversold'
GO
/****** Object:  Table [dbo].[tb_M_MessageInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_MessageInfo](
	[m_MessageInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[m_id] [int] NOT NULL,
	[refund_id] [int] NOT NULL,
	[owner_id] [int] NOT NULL,
	[owner_nick] [varchar](50) NOT NULL,
	[owner_role] [varchar](50) NOT NULL,
	[m_content] [varchar](400) NOT NULL,
	[created] [datetime] NOT NULL,
	[message_type] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证信息系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_MessageInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统留言编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统预留编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'refund_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言者编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'owner_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言者昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'owner_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'留言者身份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'owner_role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'm_content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信息类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageInfo', @level2type=N'COLUMN',@level2name=N'message_type'
GO
/****** Object:  Table [dbo].[tb_M_MessageImgInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_MessageImgInfo](
	[m_MessageImgInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_MessageInfoID] [int] NOT NULL,
	[url] [varchar](512) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageImgInfo', @level2type=N'COLUMN',@level2name=N'm_MessageImgInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属留言编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageImgInfo', @level2type=N'COLUMN',@level2name=N'm_MessageInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MessageImgInfo', @level2type=N'COLUMN',@level2name=N'url'
GO
/****** Object:  Table [dbo].[tb_M_MemberInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_MemberInfo](
	[m_MemberInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[buyer_id] [varchar](50) NULL,
	[buyer_nick] [varchar](50) NULL,
	[member_grade] [varchar](50) NULL,
	[trade_amount] [numeric](18, 6) NULL,
	[trade_count] [numeric](18, 6) NULL,
	[laste_time] [datetime] NULL,
	[status] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'm_MemberInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'买家数字ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'buyer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'buyer_nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'member_grade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总交易额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'trade_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总交易量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'trade_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次交易时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'laste_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_MemberInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
/****** Object:  Table [dbo].[tb_M_LocationInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_LocationInfo](
	[m_LocationID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[zip] [varchar](50) NOT NULL,
	[address] [varchar](512) NOT NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[district] [varchar](128) NULL,
	[m_AppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'm_LocationID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮政编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'zip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'city'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'country'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区县' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'district'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_LocationInfo', @level2type=N'COLUMN',@level2name=N'm_AppendTime'
GO
/****** Object:  Table [dbo].[tb_M_ImgInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ImgInfo](
	[m_ImgInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[m_id] [bigint] NOT NULL,
	[product_id] [bigint] NOT NULL,
	[url] [varchar](512) NOT NULL,
	[position] [int] NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子图片系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'm_ImgInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属对象系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品图片ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'm_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片所属产品的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ImgInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
/****** Object:  Table [dbo].[tb_M_GoodsSkuInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_GoodsSkuInfo](
	[m_GoodsSkuInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[sku_id] [bigint] NOT NULL,
	[num_iid] [bigint] NOT NULL,
	[properties] [varchar](512) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [money] NOT NULL,
	[outer_id] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[status] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品Sku系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsSkuInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店Sku编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'sku_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属网店对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售属性组合字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'properties'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属于该Sku的商品数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属于该Sku的商品的价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'outer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
/****** Object:  Table [dbo].[tb_M_GoodsSkuExtraInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_GoodsSkuExtraInfo](
	[m_GoodsSkuExtraInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_GoodsSkuInfoID] [int] NOT NULL,
	[extra_id] [int] NOT NULL,
	[sku_id] [int] NOT NULL,
	[properties] [varchar](512) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [money] NOT NULL,
	[memo] [varchar](512) NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展信息系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsSkuExtraInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属系统Sku编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsSkuInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'extra_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属网店系统Sku编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'sku_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sku的销售属性组合字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'properties'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属于这个sku的商品的数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属于这个sku的商品的价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsSkuExtraInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
/****** Object:  Table [dbo].[tb_M_GoodsInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_GoodsInfo](
	[m_GoodsID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[m_ProductInfoID] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[outer_id] [varchar](50) NOT NULL,
	[num_iid] [bigint] NOT NULL,
	[detail_url] [varchar](512) NOT NULL,
	[title] [varchar](60) NOT NULL,
	[nick] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[props_name] [varchar](1024) NOT NULL,
	[promoted_service] [varchar](512) NOT NULL,
	[cid] [bigint] NOT NULL,
	[seller_cids] [varchar](512) NOT NULL,
	[props] [varchar](1024) NOT NULL,
	[input_pids] [varchar](1024) NULL,
	[input_str] [varchar](1024) NULL,
	[m_desc] [ntext] NOT NULL,
	[pic_url] [varchar](512) NOT NULL,
	[num] [int] NOT NULL,
	[valid_thru] [int] NOT NULL,
	[list_time] [datetime] NOT NULL,
	[delist_time] [datetime] NOT NULL,
	[stuff_status] [varchar](50) NOT NULL,
	[price] [money] NOT NULL,
	[post_fee] [money] NOT NULL,
	[express_fee] [money] NOT NULL,
	[ems_fee] [money] NOT NULL,
	[has_discount] [bit] NOT NULL,
	[freight_payer] [varchar](50) NOT NULL,
	[has_invoice] [bit] NOT NULL,
	[has_warranty] [bit] NOT NULL,
	[has_showcase] [bit] NOT NULL,
	[modified] [datetime] NOT NULL,
	[increment] [varchar](50) NOT NULL,
	[approve_status] [varchar](50) NOT NULL,
	[postage_id] [bigint] NOT NULL,
	[auction_point] [int] NOT NULL,
	[property_alias] [varchar](50) NULL,
	[is_virtual] [bit] NOT NULL,
	[is_taobao] [bit] NOT NULL,
	[is_ex] [bit] NOT NULL,
	[is_timing] [bit] NOT NULL,
	[is_3D] [bit] NOT NULL,
	[one_station] [bit] NOT NULL,
	[second_kill] [varchar](50) NOT NULL,
	[auto_fill] [varchar](50) NOT NULL,
	[violation] [bit] NOT NULL,
	[created] [datetime] NOT NULL,
	[cod_postage_id] [bigint] NOT NULL,
	[sell_promise] [bit] NOT NULL,
	[m_IsDeltet] [bit] NOT NULL,
	[m_UpdateTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品信息系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属Erp系统产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属系统产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'm_ProductInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属产品的id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'outer_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'detail_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卖家昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'nick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品属性名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'props_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消保类型，多个类型以,分割' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'promoted_service'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品所属的叶子类目 id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品所属的店铺内卖家自定义类目列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'seller_cids'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品属性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'props'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户自行输入的类目属性ID串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'input_pids'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户自行输入的子属性名和属性值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'input_str'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'm_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品主图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'pic_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'valid_thru'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'list_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'delist_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品新旧程度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'stuff_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平邮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'post_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快递' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'express_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ems' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'ems_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否会员打折' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'has_discount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费承担方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'freight_payer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否含发票' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'has_invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有报修' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'has_warranty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否橱窗推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'has_showcase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加价幅度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'increment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品上传后的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'approve_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宝贝所属的运费模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'postage_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返点比例' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'auction_point'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性值别名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'property_alias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否为虚拟商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'is_virtual'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在淘宝显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'is_taobao'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在外部网店使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'is_ex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否定时上架' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'is_timing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否淘宝3D商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'is_3D'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否淘1站商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'one_station'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'秒杀类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'second_kill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代充商品类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'auto_fill'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品是否违规' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'violation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货到付款运费模板ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'cod_postage_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否承诺退换货服务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsInfo', @level2type=N'COLUMN',@level2name=N'sell_promise'
GO
/****** Object:  Table [dbo].[tb_M_GoodsExtraInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_GoodsExtraInfo](
	[m_GoodsExtraInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_GoodsID] [int] NOT NULL,
	[eid] [int] NOT NULL,
	[num_iid] [int] NOT NULL,
	[title] [varchar](100) NOT NULL,
	[m_desc] [varchar](1024) NULL,
	[feature] [varchar](512) NULL,
	[memo] [varchar](512) NULL,
	[type] [varchar](50) NOT NULL,
	[reserve_price] [money] NOT NULL,
	[created] [datetime] NOT NULL,
	[modified] [datetime] NOT NULL,
	[list_time] [datetime] NOT NULL,
	[delist_time] [datetime] NOT NULL,
	[approve_status] [varchar](50) NOT NULL,
	[pic_url] [varchar](512) NOT NULL,
	[options] [int] NOT NULL,
	[item_pic_url] [varchar](512) NOT NULL,
	[item_options] [int] NOT NULL,
	[item_num] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品扩展信息系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsExtraInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属系统商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统扩展信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'eid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'num_iid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'm_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自定义信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'feature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展商品的类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展商品的价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'reserve_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'list_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'delist_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品上传后的状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'approve_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'pic_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'options字段，用于对扩展商品按位打某些标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'options'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品里面的主图地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'item_pic_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品Item里面的options字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'item_options'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品Item库存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsExtraInfo', @level2type=N'COLUMN',@level2name=N'item_num'
GO
/****** Object:  Table [dbo].[tb_M_GoodsCatInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_GoodsCatInfo](
	[m_GoodsCatInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL,
	[cid] [bigint] NOT NULL,
	[parent_cid] [bigint] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[is_parent] [bit] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[sort_order] [int] NOT NULL,
	[mUpdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类目编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'm_GoodsCatInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类目编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'parent_cid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否为父类目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'is_parent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_GoodsCatInfo', @level2type=N'COLUMN',@level2name=N'sort_order'
GO
/****** Object:  Table [dbo].[tb_M_ExpressTemplatesInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ExpressTemplatesInfo](
	[m_ExpressTemplatesID] [int] IDENTITY(1,1) NOT NULL,
	[mName] [varchar](50) NOT NULL,
	[mPIC] [varchar](50) NOT NULL,
	[mWidth] [varchar](50) NOT NULL,
	[mHeight] [varchar](50) NOT NULL,
	[mExpName] [varchar](128) NOT NULL,
	[mData] [ntext] NULL,
	[mAppendTime] [datetime] NOT NULL,
	[m_ConfigInfoID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'm_ExpressTemplatesID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'背景图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mPIC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mHeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物流公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mExpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模板内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ExpressTemplatesInfo', @level2type=N'COLUMN',@level2name=N'mAppendTime'
GO
/****** Object:  Table [dbo].[tb_M_CreditInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_M_CreditInfo](
	[m_CreditInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_UserInfoID] [int] NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_level] [int] NOT NULL,
	[score] [int] NOT NULL,
	[total_num] [int] NOT NULL,
	[good_num] [int] NOT NULL,
	[last_updatetime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信用信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'm_CreditInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'm_UserInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信用类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信用等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'm_level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'信用总分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'score'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收到的评价总条数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'total_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收到的好评总条数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'good_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_CreditInfo', @level2type=N'COLUMN',@level2name=N'last_updatetime'
GO
/****** Object:  Table [dbo].[tb_M_ConfirmFeeInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_M_ConfirmFeeInfo](
	[m_ConfirmFeeInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_Type] [int] NOT NULL,
	[m_ObjID] [int] NOT NULL,
	[confirm_fee] [money] NOT NULL,
	[confirm_post_fee] [money] NOT NULL,
	[is_last_order] [bit] NOT NULL,
	[mAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'm_ConfirmFeeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'm_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应对象编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'm_ObjID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'确认收货的金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'confirm_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'需确认收货的邮费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'confirm_post_fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是最后一笔订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'is_last_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfirmFeeInfo', @level2type=N'COLUMN',@level2name=N'mAppendTime'
GO
/****** Object:  Table [dbo].[tb_M_ConfigInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_ConfigInfo](
	[m_ConfigInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_Name] [varchar](50) NOT NULL,
	[m_AppKey] [varchar](50) NOT NULL,
	[m_AppSecret] [varchar](50) NOT NULL,
	[StoresID] [int] NOT NULL,
	[m_State] [int] NOT NULL,
	[m_SessionKey] [varchar](50) NULL,
	[m_UpdateTime] [datetime] NULL,
	[m_AppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配置信息编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_ConfigInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'淘宝AppKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_AppKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'淘宝AppSecret' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_AppSecret'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_ConfigInfo', @level2type=N'COLUMN',@level2name=N'm_AppendTime'
GO
/****** Object:  Table [dbo].[tb_M_AppSubscribeInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_M_AppSubscribeInfo](
	[m_AppSubscribeInfoID] [int] IDENTITY(1,1) NOT NULL,
	[m_UserInfoID] [int] NOT NULL,
	[lease_id] [varchar](50) NOT NULL,
	[status] [varchar](50) NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[version_no] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用订购编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'm_AppSubscribeInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'm_UserInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'插件实例ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'lease_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订购状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'end_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_M_AppSubscribeInfo', @level2type=N'COLUMN',@level2name=N'version_no'
GO
/****** Object:  StoredProcedure [dbo].[sp_ErpWillPay]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ErpWillPay]
/*应付*/
	(
	@bDate	datetime = null,		--开始时间
	@eDate	datetime = null			--结束时间
	)

AS
begin

	declare @tSQLwhere varchar(3000);
	declare @tSQLwhere_a varchar(1000);
	declare @tSQLwhere_b varchar(1000);

	--采购入库
	set @tSQLwhere_a = ' and tbErpOrderInfo.IsCheck=0 and  tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=4';
	--采购退货
	set @tSQLwhere_b = ' and tbErpOrderInfo.IsCheck=0 and  tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=8';
	
	set @tSQLwhere = 'select tbSupplierInfo.SupplierID,tbSupplierInfo.sName,tbSupplierInfo.sCode,tbSupplierInfo.sDoDayMoney,
		 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbSupplierInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' ) as DeliveryMoney,
		 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbSupplierInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
		 (select isnull(sum(tbAPMoneyInfo.aNPMoney),0) from tbAPMoneyInfo where tbAPMoneyInfo.APObjType=0 and tbAPMoneyInfo.APObjID=tbSupplierInfo.SupplierID ) as NPMoney,
		 (select isnull(sum(tbAPMoneyInfo.aPMoney),0) from tbAPMoneyInfo where tbAPMoneyInfo.APObjType=0 and tbAPMoneyInfo.APObjID=tbSupplierInfo.SupplierID ) as AMoney,
		 (select isnull(sum(tbAPMoneyInfo.aPayMoney),0) from tbAPMoneyInfo where tbAPMoneyInfo.APObjType=0 and tbAPMoneyInfo.APObjID=tbSupplierInfo.SupplierID ) as ActualMoney  
		from tbSupplierInfo  order by DeliveryMoney desc';
		
	exec(@tSQLwhere);
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ErpCustomerPay_do]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ErpCustomerPay_do]
/*处理指定客户,指定时间段内应付账款信息*/
	(
	@bDate	datetime = null,		--开始时间
	@eDate	datetime = null			--结束时间
	)
	
AS
begin
	
	declare @tSQLwhere varchar(3000);
	declare @tSQLwhere_a varchar(1000);
	declare @tSQLwhere_b varchar(1000);
	
	--销售发货
	set @tSQLwhere_a = '  tbErpOrderInfo.IsCheck=0 and  tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=1';
	--销售退货
	set @tSQLwhere_b = '  tbErpOrderInfo.IsCheck=0 and  tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=5';
	
	set @tSQLwhere = 'update tbErpOrderInfo set tbErpOrderInfo.IsCheck=1 where ';
	
	exec(@tSQLwhere+@tSQLwhere_a);
	
	exec(@tSQLwhere+@tSQLwhere_b);
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_getorderlist]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_getorderlist]
    @Page int = 1,      -- 当前页码
	@PageSize int = 20,     -- 每页记录条数(页面大小)
    @OrderBy nvarchar(100) = '', -- 排序规则
	@Filter nvarchar(2000)    -- 过滤条件
AS

-- 整合SQL
Declare @SQL nvarchar(4000), @Portion nvarchar(4000);

IF LEN(RTRIM(LTRIM(@Filter))) > 0
Begin
  set @Filter='where '+@Filter;
End
--替换未审核单据单据号,使其为较大值
Set @SQL = 'Select *,ROW_NUMBER() over (ORDER BY '+@OrderBy+') as RowNo 
from (select *,(REPLACE(tbOrderInfo.oOrderNum,''-'',''99'')) as nOrderNum,(case 
                 when  tbOrderInfo.oType in(1,2) then 
                 (select su.sName from tbSupplierInfo su where su.SupplierID=tbOrderInfo.StoresID) 
                 when  tbOrderInfo.oType in(3,4,5,6,7,11) then 
                 (select so.sName from tbStoresInfo so where so.StoresID=tbOrderInfo.StoresID) 
				  when  tbOrderInfo.oType = 9 then 
                 (select ss.sName from tbStorageInfo ss where ss.StorageID=tbOrderInfo.StoresID) 
                 end) as StoresSupplierName,
                isnull((select sum(isnull(ol.oMoney,0)) from tbOrderListInfo ol where ol.OrderID=tbOrderInfo.OrderID and ol.oWorkType=(select max(oll.oWorkType) from tbOrderListInfo oll where oll.OrderID=tbOrderInfo.OrderID))*(case when tbOrderInfo.oType in(2,4) then -1 else 1 end),0) as SumMoney,
                (select s.sName from tbStaffInfo s where s.StaffID=tbOrderInfo.StaffID) as StaffName,
                (select u.uName from tbUserInfo u where u.UserID=tbOrderInfo.UserID) as UserName,
                (select top 1 us.sName from tbStaffInfo us where us.StaffID=(select top 1 StaffID from tbUserInfo where UserID=tbOrderInfo.UserID )) as UserStaffName,
                (select top 1 w.pAppendTime from tbOrderWorkingLogInfo w where w.OrderID=tbOrderInfo.OrderID and w.oType=6 order by pAppendTime desc) as PrintTime
                from tbOrderInfo '+@Filter+') as o';

Set @SQL = 'select top('+CAST(@PageSize AS nvarchar(8))+') * from ('+@SQL+') as tab where tab.RowNo BETWEEN ('+CAST(@Page AS nvarchar(8))+'-1)*'+CAST(@PageSize AS nvarchar(8))+'+1 AND '+CAST(@Page AS nvarchar(8))+'*'+CAST(@PageSize AS nvarchar(8));

--总记录数
Set @SQL = 'select count(0) from tbOrderInfo '+ @Filter+';'+@SQL;

--select @SQL;

  -- 执行SQL, 取当前页记录集
 Execute(@SQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDateTimeList]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetDateTimeList]
	@begintime datetime,
	@endtime datetime,
	@dtype int
AS
begin
	declare @day int;
	declare @month int;
	declare @year int;

--删除原数据
If object_id('tempdb..#DateTimeList') is  not null
Drop table #DateTimeList
--创建新临时表
Create table #DateTimeList (
					tdate datetime
				)

if @dtype = 1
begin
	select @day=DATEDIFF(day, @begintime, @endtime) 
	while @day>=0 
	begin
		insert into #DateTimeList 
			select dateadd(day,@day,@begintime)
		set @day=@day-1;
	end
end
if @dtype = 2
begin
	select @month=DATEDIFF(month, @begintime, @endtime) 
	while @month>=0 
	begin
		insert into #DateTimeList 
			select dateadd(month,@month,@begintime)
		set @month=@month-1;
	end
end
if @dtype = 3
begin
	select @year=DATEDIFF(year, @begintime, @endtime) 
	while @year>=0 
	begin
		insert into #DateTimeList 
			select dateadd(year,@year,@begintime)
		set @year=@year-1;
	end
end


	select * from #DateTimeList order by tdate asc
	
	Drop table #DateTimeList;
end
GO
/****** Object:  Table [dbo].[tbscheduledevents]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbscheduledevents](
	[scheduleID] [int] IDENTITY(1,1) NOT NULL,
	[key] [varchar](50) NOT NULL,
	[lastexecuted] [datetime] NOT NULL,
	[servername] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbSalesInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbSalesInfo](
	[SalesID] [int] IDENTITY(1,1) NOT NULL,
	[StoresID] [int] NOT NULL,
	[sStoresID] [varchar](50) NULL,
	[sStoresName] [varchar](128) NULL,
	[ProductsID] [int] NOT NULL,
	[sProductsName] [varchar](128) NULL,
	[sNum] [int] NOT NULL,
	[sPrice] [money] NOT NULL,
	[sDateTime] [datetime] NOT NULL,
	[sIsYH] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售数据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'SalesID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'sNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'sPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'sDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbSalesInfo', @level2type=N'COLUMN',@level2name=N'sAppendTime'
GO
/****** Object:  Table [dbo].[tbSales_Staff_StoresDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSales_Staff_StoresDataInfo](
	[StaffStoresID] [int] NOT NULL,
	[StoresID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[bdate] [datetime] NOT NULL,
	[edate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbReportInvoicingDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbReportInvoicingDataInfo](
	[ReportInvoicingID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[ProductClassID] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[bQuantity] [numeric](18, 6) NOT NULL,
	[bMoney] [numeric](18, 6) NOT NULL,
	[InQuantity] [numeric](18, 6) NOT NULL,
	[InMoney] [numeric](18, 6) NOT NULL,
	[OutQuantity] [numeric](18, 6) NOT NULL,
	[OutMoney] [numeric](18, 6) NOT NULL,
	[eQuantity] [numeric](18, 6) NOT NULL,
	[eMoney] [numeric](18, 6) NOT NULL,
	[BadQuantity] [numeric](18, 6) NOT NULL,
	[BadMoney] [numeric](18, 6) NOT NULL,
	[rType] [int] NOT NULL,
	[rDateTime] [datetime] NOT NULL,
	[rBDateTime] [datetime] NOT NULL,
	[rEdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbRegionInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbRegionInfo](
	[RegionID] [int] IDENTITY(1,1) NOT NULL,
	[rName] [varchar](50) NOT NULL,
	[rUpID] [int] NOT NULL,
	[rOrder] [int] NOT NULL,
	[rState] [int] NOT NULL,
	[rAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbProductsStorageLogInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductsStorageLogInfo](
	[ProductsStorageLogID] [int] IDENTITY(1,1) NOT NULL,
	[StorageID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[pQuantity] [numeric](18, 6) NOT NULL,
	[pType] [int] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pState] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductsStorageInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductsStorageInfo](
	[ProductsStorageID] [int] IDENTITY(1,1) NOT NULL,
	[StorageID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pStorage] [numeric](18, 6) NOT NULL,
	[pStorageIn] [numeric](18, 6) NOT NULL,
	[pStorageOut] [numeric](18, 6) NOT NULL,
	[pUpdateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductsInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbProductsInfo](
	[ProductsID] [int] IDENTITY(1,1) NOT NULL,
	[ProductClassID] [int] NOT NULL,
	[pCode] [varchar](50) NULL,
	[pBarcode] [varchar](50) NOT NULL,
	[pName] [varchar](128) NOT NULL,
	[pEnName] [varchar](128) NULL,
	[pBrand] [varchar](128) NOT NULL,
	[pStandard] [varchar](50) NOT NULL,
	[pUnits] [varchar](50) NOT NULL,
	[pMaxUnits] [varchar](50) NOT NULL,
	[pToBoxNo] [int] NOT NULL,
	[pPrice] [money] NOT NULL,
	[pSellingPrice] [money] NOT NULL,
	[pProducer] [varchar](512) NULL,
	[pExpireDay] [varchar](50) NULL,
	[pAddress] [varchar](512) NULL,
	[pState] [int] NOT NULL,
	[pDoDayQuantity] [decimal](18, 2) NOT NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pBarcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pBrand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pStandard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pUnits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'件装数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pToBoxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbProductsInfo', @level2type=N'COLUMN',@level2name=N'pAppendTime'
GO
/****** Object:  Table [dbo].[tbProductsFieldValueInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductsFieldValueInfo](
	[ProductsFieldValueID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[ProductFieldID] [int] NOT NULL,
	[pfvType] [int] NOT NULL,
	[pfvData] [ntext] NULL,
	[pfvAppendTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductPriceNOAutoInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductPriceNOAutoInfo](
	[ProductPriceNOAutoID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[PriceRMB] [money] NOT NULL,
	[ppAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductPoolInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductPoolInfo](
	[ProductPoolID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pDateTime] [datetime] NOT NULL,
	[pType] [int] NOT NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductPoolDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductPoolDataInfo](
	[ProductPoolID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[Bdate] [datetime] NOT NULL,
	[Edate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductFieldInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbProductFieldInfo](
	[ProductFieldID] [int] IDENTITY(1,1) NOT NULL,
	[ProductClassID] [int] NOT NULL,
	[pfName] [varchar](128) NOT NULL,
	[pfType] [int] NOT NULL,
	[pfOrder] [int] NOT NULL,
	[pfState] [int] NOT NULL,
	[pfAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbProductCostPriceInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbProductCostPriceInfo](
	[CostVelenceID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[cPrice] [money] NOT NULL,
	[bdate] [datetime] NOT NULL,
	[edate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbProductClassInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbProductClassInfo](
	[ProductClassID] [int] IDENTITY(1,1) NOT NULL,
	[pParentID] [int] NOT NULL,
	[pClassName] [varchar](50) NOT NULL,
	[pOrder] [int] NOT NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbPriceClassInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbPriceClassInfo](
	[PriceClassID] [int] IDENTITY(1,1) NOT NULL,
	[pParentID] [int] NOT NULL,
	[pClassName] [varchar](50) NOT NULL,
	[pOrder] [int] NOT NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbPriceClassDefaultPriceInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPriceClassDefaultPriceInfo](
	[PriceClassDefaultPriceID] [int] IDENTITY(1,1) NOT NULL,
	[PriceClassID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pPrice] [money] NOT NULL,
	[pIsEdit] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbPaymentSystemInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbPaymentSystemInfo](
	[PaymentSystemID] [int] IDENTITY(1,1) NOT NULL,
	[pName] [varchar](50) NOT NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbOrderWorkingLogInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbOrderWorkingLogInfo](
	[OrderWorkingLogID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[oType] [int] NOT NULL,
	[oMsg] [varchar](512) NULL,
	[pAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbOrderNOFullInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbOrderNOFullInfo](
	[OrderID] [int] NOT NULL,
	[OrderToID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[FormStorageID] [int] NOT NULL,
	[ToStorageID] [int] NOT NULL,
	[oQuantity] [numeric](18, 6) NOT NULL,
	[oState] [int] NOT NULL,
	[oNextOrderID] [int] NOT NULL,
	[oAppendTimie] [datetime] NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbOrderListInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbOrderListInfo](
	[OrderListID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[oQuantity] [numeric](18, 6) NOT NULL,
	[oPrice] [numeric](18, 6) NOT NULL,
	[oMoney] [numeric](18, 6) NOT NULL,
	[StoresSupplierID] [int] NOT NULL,
	[IsPromotions] [int] NOT NULL,
	[oWorkType] [int] NOT NULL,
	[oAppendTime] [datetime] NOT NULL,
	[IsGifts] [int] NOT NULL,
	[PriceClassID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbOrderInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbOrderInfo](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[oOrderNum] [varchar](50) NOT NULL,
	[oType] [int] NOT NULL,
	[StoresID] [int] NOT NULL,
	[oCustomersName] [varchar](128) NOT NULL,
	[oCustomersContact] [varchar](50) NULL,
	[oCustomersTel] [varchar](50) NULL,
	[oCustomersAddress] [varchar](512) NULL,
	[oCustomersOrderID] [varchar](50) NULL,
	[oCustomersNameB] [varchar](128) NULL,
	[StaffID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[oAppendTime] [datetime] NOT NULL,
	[oOrderDateTime] [datetime] NOT NULL,
	[oPrepay] [int] NOT NULL,
	[oState] [int] NOT NULL,
	[oSteps] [int] NOT NULL,
	[oReMake] [varchar](512) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbOrderFieldValueInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbOrderFieldValueInfo](
	[OrderFieldValueID] [int] IDENTITY(1,1) NOT NULL,
	[OrderFieldID] [int] NOT NULL,
	[OrderListID] [int] NOT NULL,
	[oFieldValue] [varchar](128) NOT NULL,
	[IsVerify] [int] NOT NULL,
	[oAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbOrderFieldInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbOrderFieldInfo](
	[OrderFieldID] [int] IDENTITY(1,1) NOT NULL,
	[OrderType] [int] NOT NULL,
	[fName] [varchar](50) NOT NULL,
	[fType] [int] NOT NULL,
	[fPrint] [int] NOT NULL,
	[fPrintAdd] [int] NOT NULL,
	[fProductField] [varchar](50) NULL,
	[fState] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMonthlyStatementWorkingLogInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMonthlyStatementWorkingLogInfo](
	[MonthlyStatementWorkingLogID] [int] IDENTITY(1,1) NOT NULL,
	[MonthlyStatementID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[mType] [int] NOT NULL,
	[mMsg] [varchar](512) NULL,
	[mAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMonthlyStatementInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMonthlyStatementInfo](
	[MonthlyStatementID] [int] IDENTITY(1,1) NOT NULL,
	[sCode] [varchar](50) NOT NULL,
	[sObjectID] [int] NOT NULL,
	[sObjectType] [int] NOT NULL,
	[sType] [int] NOT NULL,
	[sUpMoney] [money] NOT NULL,
	[sThisMoney] [money] NOT NULL,
	[sMoney] [money] NOT NULL,
	[sToMoney] [money] NOT NULL,
	[sBalanceMoney] [money] NOT NULL,
	[sSteps] [int] NOT NULL,
	[sBalanceType] [int] NOT NULL,
	[sReceiptState] [int] NOT NULL,
	[sDateTime] [datetime] NOT NULL,
	[sState] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMonthlyStatementDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMonthlyStatementDataInfo](
	[MonthlyStatementDataID] [int] IDENTITY(1,1) NOT NULL,
	[MonthlyStatementID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[oMoney] [money] NOT NULL,
	[sRemake] [varchar](512) NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMonthlyStatementAppendMoneyDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMonthlyStatementAppendMoneyDataInfo](
	[MonthlyStatementAppendMoneyDataID] [int] IDENTITY(1,1) NOT NULL,
	[MonthlyStatementID] [int] NOT NULL,
	[mMoney] [numeric](18, 6) NOT NULL,
	[mDateTime] [datetime] NOT NULL,
	[mState] [int] NOT NULL,
	[mRemake] [varchar](512) NULL,
	[mAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收付款记录编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'MonthlyStatementAppendMoneyDataID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属对账单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'MonthlyStatementID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'mMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'mState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'mRemake'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMonthlyStatementAppendMoneyDataInfo', @level2type=N'COLUMN',@level2name=N'mAppendTime'
GO
/****** Object:  Table [dbo].[tbMonthlyStatementAppendDataInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMonthlyStatementAppendDataInfo](
	[MonthlyStatementAppendDataID] [int] IDENTITY(1,1) NOT NULL,
	[MonthlyStatementID] [int] NOT NULL,
	[CertificateID] [int] NOT NULL,
	[aState] [int] NOT NULL,
	[aRemake] [varchar](512) NULL,
	[cMoney] [money] NOT NULL,
	[aAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMarketingFeesInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbMarketingFeesInfo](
	[MarketingFeesID] [int] IDENTITY(1,1) NOT NULL,
	[StoresID] [int] NOT NULL,
	[FeesSubjectID] [int] NOT NULL,
	[mRemark] [varchar](1024) NOT NULL,
	[mFees] [money] NOT NULL,
	[mDateTime] [datetime] NOT NULL,
	[mType] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[mIsIncomeExpenditure] [int] NOT NULL,
	[mAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'营销费用编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'MarketingFeesID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'FeesSubjectID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'mRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'mFees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'mDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'mType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经办人编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbMarketingFeesInfo', @level2type=N'COLUMN',@level2name=N'mAppendTime'
GO
/****** Object:  Table [dbo].[tbGiftsInfo]    Script Date: 10/11/2016 09:51:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbGiftsInfo](
	[GiftsID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[StoresID] [int] NOT NULL,
	[gNum] [int] NOT NULL,
	[gDateTime] [datetime] NOT NULL,
	[gAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'GiftsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠品数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'gNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'gDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbGiftsInfo', @level2type=N'COLUMN',@level2name=N'gAppendTime'
GO
/****** Object:  StoredProcedure [dbo].[UP_GetRecordByPageOrder]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UP_GetRecordByPageOrder]

@tblName varchar(255),   -- 表名 
@fldName varchar(255),   -- 显示字段名 
@OrderfldName varchar(255), -- 排序字段名 
@StatfldName varchar(255), -- 统计字段名 
@PageSize int = 10,   -- 页尺寸 
@PageIndex int = 1,   -- 页码 
@IsReCount bit = 0,   -- 返回记录总数, 非 0 值则返回 
@OrderType bit = 0,   -- 设置排序类型, 非 0 值则降序 
@strWhere varchar(1000) = '' -- 查询条件 (注意: 不要加 where) 
AS

declare @strSQL varchar(6000) -- 主语句 
declare @strTmp varchar(100)   -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
declare @strOrder varchar(400) -- 排序类型

if @OrderType != 0 
begin 
set @strTmp = '<(select min' 
set @strOrder = ' order by [' + @OrderfldName +'] desc' 
end 
else 
begin 
set @strTmp = '>(select max' 
set @strOrder = ' order by [' + @OrderfldName +'] asc' 
end

set @strSQL = 'select top ' + str(@PageSize) + ' ' + @fldName + ' from [' 
+ @tblName + '] where [' + @OrderfldName + ']' + @strTmp + '([' 
+ @OrderfldName + ']) from (select top ' + str((@PageIndex-1)*@PageSize) + ' [' 
+ @OrderfldName + '] from [' + @tblName + ']' + @strOrder + ') as tblTmp)' 
+ @strOrder

if @strWhere != '' 
set @strSQL = 'select top ' + str(@PageSize) + ' ' + @fldName + ' from [' 
+ @tblName + '] where [' + @OrderfldName + ']' + @strTmp + '([' 
+ @OrderfldName + ']) from (select top ' + str((@PageIndex-1)*@PageSize) + ' [' 
+ @OrderfldName + '] from [' + @tblName + '] where ' + @strWhere + ' ' 
+ @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder

if @PageIndex = 1 
begin 
set @strTmp = '' 
if @strWhere != '' 
set @strTmp = ' where ' + @strWhere

set @strSQL = 'select top ' + str(@PageSize) + ' ' + @fldName + ' from [' 
+ @tblName + ']' + @strTmp + ' ' + @strOrder 
end


if @IsReCount != 0 
set @strSQL = @strSQL+' select count(1) as Total from [' + @tblName + ']'

if @strWhere!=''
set @strSQL = @strSQL+' where ' + @strWhere
exec (@strSQL)
GO
/****** Object:  StoredProcedure [dbo].[UP_GetRecordByPage_mFld]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UP_GetRecordByPage_mFld]
	@tblName      varchar(255),       -- 表名
    @fldName      varchar(255),       -- 主键字段名
    @PageSize     int = 10,           -- 页尺寸
    @PageIndex    int = 1,            -- 页码
    @IsReCount    bit = 0,            -- 返回记录总数, 非 0 值则返回
    @OrderType    bit = 0,            -- 设置排序类型, 非 0 值则降序
    @strWhere     varchar(2000) = '', -- 查询条件 (注意: 不要加 where)
	@showFName	  varchar(2550) = '*',  -- 显示字段
	@OrderFldName varchar(255)			-- 排序字段
	
AS

-- 整合SQL
Declare @SQL nvarchar(4000), @Portion nvarchar(4000);

IF LEN(RTRIM(LTRIM(@strWhere))) > 0
Begin
  set @strWhere='where '+@strWhere;
End

Set @SQL = 'Select *,ROW_NUMBER() over (ORDER BY '+@OrderFldName+') as RowNo from (select '+@showFName+' from '+@tblName+' '+@strWhere+') as o';

Set @SQL = 'select top('+CAST(@PageSize AS nvarchar(8))+') * from ('+@SQL+') as tab where tab.RowNo BETWEEN ('+CAST(@PageIndex AS nvarchar(8))+'-1)*'+CAST(@PageSize AS nvarchar(8))+'+1 AND '+CAST(@PageIndex AS nvarchar(8))+'*'+CAST(@PageSize AS nvarchar(8));

--总记录数
Set @SQL = 'select count(0) from '+@tblName+' '+ @strWhere+';'+@SQL;

--select @SQL;

  -- 执行SQL, 取当前页记录集
 Execute(@SQL);
GO
/****** Object:  StoredProcedure [dbo].[UP_GetRecordByPage]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UP_GetRecordByPage]
    @tblName      varchar(255),       -- 表名
    @fldName      varchar(255),       -- 主键字段名
    @PageSize     int = 10,           -- 页尺寸
    @PageIndex    int = 1,            -- 页码
    @IsReCount    bit = 0,            -- 返回记录总数, 非 0 值则返回
    @OrderType    bit = 0,            -- 设置排序类型, 非 0 值则降序
    @strWhere     varchar(2000) = '', -- 查询条件 (注意: 不要加 where)
	@showFName	  varchar(2550) = '*'  -- 显示字段
AS

declare @strSQL   varchar(6000)       -- 主语句
declare @strTmp   varchar(2000)        -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
declare @strOrder varchar(400)        -- 排序类型

if @OrderType != 0
begin
    set @strTmp = '<(select min'
    set @strOrder = ' order by ' + @fldName +' desc'
end
else
begin
    set @strTmp = '>(select max'
    set @strOrder = ' order by ' + @fldName +' asc'
end

set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
    + @tblName + ' where ' + @fldName + '' + @strTmp + '('
    + @fldName + ') from (select top ' + str((@PageIndex-1)*@PageSize) + ' '
    + @fldName + ' from ' + @tblName + '' + @strOrder + ') as tblTmp)'
    + @strOrder

if @strWhere != ''
    set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
        + @tblName + ' where ' + @fldName + '' + @strTmp + '('
        + @fldName + ') from (select top ' + str((@PageIndex-1)*@PageSize) + ' '
        + @fldName + ' from ' + @tblName + ' where ' + @strWhere + ' '
        + @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder

if @PageIndex = 1
begin
    set @strTmp =''
    if @strWhere != ''
        set @strTmp = ' where ' + @strWhere

    set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
        + @tblName + '' + @strTmp + ' ' + @strOrder
end

if @IsReCount != 0
begin
if @strWhere != ''
	set @strWhere = ' where '+@strWhere;
    exec('select count(*) as Total from ' + @tblName + ''+ @strWhere);
end
--select @strSQL
exec (@strSQL)
GO
/****** Object:  Table [dbo].[tbYHsysInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbYHsysInfo](
	[YHsysID] [int] IDENTITY(1,1) NOT NULL,
	[yName] [varchar](50) NOT NULL,
	[yAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbValenceInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbValenceInfo](
	[ValenceID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[bDateTime] [datetime] NOT NULL,
	[eDateTime] [datetime] NOT NULL,
	[vPrice] [money] NOT NULL,
	[vAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变价编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'ValenceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'ProductsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变价起始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'bDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变价结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'eDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变价期间价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'vPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbValenceInfo', @level2type=N'COLUMN',@level2name=N'vAppendTime'
GO
/****** Object:  Table [dbo].[tbUserStorageInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserStorageInfo](
	[UserStorageID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[StorageIDStr] [varchar](512) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserPassportInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserPassportInfo](
	[UserID] [int] NOT NULL,
	[Erp_Name] [varchar](50) NULL,
	[Erp_Pwd] [varchar](50) NULL,
	[g_Name] [varchar](50) NULL,
	[g_PWD] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserOnLineTime_Bak]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserOnLineTime_Bak](
	[UserID] [int] NOT NULL,
	[thismonth] [smallint] NOT NULL,
	[total] [int] NOT NULL,
	[lastupdate] [datetime] NOT NULL,
 CONSTRAINT [PK_onlinetime] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUserOnLineTime]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUserOnLineTime](
	[UserID] [int] NOT NULL,
	[thismonth] [int] NOT NULL,
	[total] [int] NOT NULL,
	[lastupdate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUserOnLineLogInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserOnLineLogInfo](
	[olID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[oIP] [varchar](15) NOT NULL,
	[oUserName] [varchar](50) NOT NULL,
	[UserGroupsID] [int] NOT NULL,
	[UserSPID] [int] NOT NULL,
	[oAppendTime] [datetime] NOT NULL,
	[oLastTime] [datetime] NOT NULL,
 CONSTRAINT [PK_online] PRIMARY KEY CLUSTERED 
(
	[olID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbUserInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[uName] [varchar](50) NOT NULL,
	[StaffID] [int] NOT NULL,
	[uPWD] [char](32) NOT NULL,
	[uCode] [char](16) NOT NULL,
	[uPermissions] [varchar](2000) NOT NULL,
	[uAppendTime] [datetime] NOT NULL,
	[uUpAppendTime] [datetime] NOT NULL,
	[uLastIP] [varchar](15) NOT NULL,
	[uType] [int] NOT NULL,
	[uEstate] [int] NOT NULL,
	[olTime] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登陆密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uPWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'随机校验码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uPermissions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uAppendTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上回登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uUpAppendTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上回登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uLastIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbUserInfo', @level2type=N'COLUMN',@level2name=N'uEstate'
GO
/****** Object:  Table [dbo].[tbUserFailedLoginLogInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUserFailedLoginLogInfo](
	[ip] [char](15) NOT NULL,
	[errcount] [smallint] NOT NULL,
	[lastupdate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_tbUserFailedLoginLogInfo] PRIMARY KEY CLUSTERED 
(
	[ip] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbSupplierInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbSupplierInfo](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierClassID] [int] NOT NULL,
	[sName] [varchar](128) NOT NULL,
	[sCode] [varchar](50) NOT NULL,
	[sLicense] [varchar](50) NULL,
	[sAddress] [varchar](256) NULL,
	[sTel] [varchar](50) NULL,
	[sLinkMan] [varchar](50) NULL,
	[sDoDay] [int] NOT NULL,
	[sDoDayMoney] [money] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbSupplierClassInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbSupplierClassInfo](
	[SupplierClassID] [int] IDENTITY(1,1) NOT NULL,
	[sParentID] [int] NOT NULL,
	[sClassName] [varchar](50) NOT NULL,
	[sOrder] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStoreStorehouseProductsPriceInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStoreStorehouseProductsPriceInfo](
	[ProductPriceID] [int] IDENTITY(1,1) NOT NULL,
	[StoresID] [int] NOT NULL,
	[StoresName] [varchar](50) NOT NULL,
	[StCode] [varchar](50) NOT NULL,
	[stName] [varchar](50) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[ProductsName] [varchar](50) NOT NULL,
	[ProductsBarcode] [varchar](50) NOT NULL,
	[pPrice] [money] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pUpdateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductPriceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStoreStorehouseInfo_calculate]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[tbStoreStorehouseInfo_calculate](
	[productStorageID] [int] IDENTITY(1,1) NOT NULL,
	[sCode] [varchar](50) NULL,
	[sName] [varchar](128) NOT NULL,
	[StoresID] [int] NOT NULL,
	[stCode] [varchar](50) NOT NULL,
	[stName] [varchar](128) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pCode] [varchar](50) NULL,
	[pBarcode] [varchar](50) NOT NULL,
	[pName] [varchar](128) NOT NULL,
	[pBrand] [varchar](128) NULL,
	[pStandard] [varchar](50) NULL,
	[pRelityStorage] [int] NOT NULL,
	[pMoney] [money] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pUpdateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[productStorageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStoreStorehouseInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStoreStorehouseInfo](
	[productStorageID] [int] IDENTITY(1,1) NOT NULL,
	[sCode] [varchar](50) NULL,
	[sName] [varchar](128) NOT NULL,
	[StoresID] [int] NOT NULL,
	[stCode] [varchar](50) NOT NULL,
	[stName] [varchar](128) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pCode] [varchar](50) NULL,
	[pBarcode] [varchar](50) NULL,
	[pName] [varchar](128) NOT NULL,
	[pBrand] [varchar](128) NULL,
	[pStandard] [varchar](50) NULL,
	[pRelityStorage] [int] NOT NULL,
	[pMoney] [money] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK__tbStoreStorehous__7C4F7684] PRIMARY KEY CLUSTERED 
(
	[productStorageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStoresInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStoresInfo](
	[StoresID] [int] IDENTITY(1,1) NOT NULL,
	[sName] [varchar](128) NOT NULL,
	[sCode] [varchar](50) NOT NULL,
	[sLicense] [varchar](50) NULL,
	[CustomersClassID] [int] NOT NULL,
	[PriceClassID] [int] NOT NULL,
	[sType] [char](1) NULL,
	[RegionID] [int] NOT NULL,
	[YHsysID] [int] NOT NULL,
	[sState] [int] NOT NULL,
	[sIsFZYH] [int] NOT NULL,
	[sDoDay] [int] NOT NULL,
	[sDoDayMoney] [money] NOT NULL,
	[PaymentSystemID] [int] NOT NULL,
	[sContact] [varchar](50) NULL,
	[sTel] [varchar](50) NULL,
	[sAddress] [varchar](512) NULL,
	[sEmail] [varchar](50) NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'sName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'sCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'sType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属地区' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'RegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'sState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStoresInfo', @level2type=N'COLUMN',@level2name=N'sAppendTime'
GO
/****** Object:  Table [dbo].[tbStorageProductLogInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStorageProductLogInfo](
	[StorageProductLogID] [int] IDENTITY(1,1) NOT NULL,
	[StorageID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[splRemake] [varchar](512) NULL,
	[splAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStorageProductLogDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStorageProductLogDataInfo](
	[StorageProductLogDataID] [int] IDENTITY(1,1) NOT NULL,
	[OrderListID] [int] NOT NULL,
	[StorageProductLogID] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[pQuantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStorageInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStorageInfo](
	[StorageID] [int] IDENTITY(1,1) NOT NULL,
	[sCode] [varchar](50) NOT NULL,
	[sName] [varchar](50) NOT NULL,
	[sManager] [int] NOT NULL,
	[sTel] [varchar](50) NULL,
	[sAddress] [varchar](512) NULL,
	[sRemake] [varchar](1024) NULL,
	[sAppendTime] [datetime] NOT NULL,
	[StorageClassID] [int] NOT NULL,
	[sState] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStorageClassInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[tbStorageClassInfo](
	[StorageClassID] [int] IDENTITY(1,1) NOT NULL,
	[sParentID] [int] NOT NULL,
	[sClassName] [varchar](50) NOT NULL,
	[sOrder] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StorageClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStocktakeInventoryInfo_]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStocktakeInventoryInfo_](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[StorageID] [int] NOT NULL,
	[StorageStaff] [varchar](50) NOT NULL,
	[StaffPhoneNum] [varchar](50) NOT NULL,
	[StaffAdress] [varchar](50) NULL,
	[InventoryName] [varchar](50) NOT NULL,
	[StaffID] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL,
	[sUpdateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStocktakeInventoryInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStocktakeInventoryInfo](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[StorageID] [int] NOT NULL,
	[StorageStaff] [varchar](50) NOT NULL,
	[StaffPhoneNum] [varchar](50) NOT NULL,
	[StaffAdress] [varchar](50) NULL,
	[InventoryName] [varchar](50) NOT NULL,
	[StaffID] [int] NOT NULL,
	[StorageName] [varchar](50) NOT NULL,
	[StaffName] [varchar](50) NOT NULL,
	[sAppendTime] [datetime] NOT NULL,
	[sUpdateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStocktakeInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStocktakeInfo](
	[StocktakeID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[Quantity] [numeric](18, 6) NOT NULL,
	[sQuantity] [numeric](18, 6) NOT NULL,
	[sDateTime] [datetime] NOT NULL,
	[sAppendTime] [datetime] NOT NULL,
	[StaffID] [int] NOT NULL,
	[sSteps] [int] NOT NULL,
 CONSTRAINT [PK__tbStocktakeInfo__3A179ED3] PRIMARY KEY CLUSTERED 
(
	[StocktakeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStockProductInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStockProductInfo](
	[StockProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsID] [int] NOT NULL,
	[StorageID] [int] NOT NULL,
	[isOK] [decimal](18, 2) NOT NULL,
	[isBad] [decimal](18, 2) NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStaffWorkDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffWorkDataInfo](
	[StaffWorkDataID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[wDate] [varchar](50) NOT NULL,
	[wEnterprise] [varchar](512) NOT NULL,
	[wTel] [varchar](50) NULL,
	[wJobs] [varchar](50) NOT NULL,
	[wIncome] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'wDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'wEnterprise'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'wTel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'wJobs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收入' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffWorkDataInfo', @level2type=N'COLUMN',@level2name=N'wIncome'
GO
/****** Object:  Table [dbo].[tbStaffStoresInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStaffStoresInfo](
	[StaffStoresID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[StoresID] [int] NOT NULL,
	[sType] [int] NOT NULL,
	[sDateTime] [datetime] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'StaffStoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'门店编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'StoresID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'sType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'sDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffStoresInfo', @level2type=N'COLUMN',@level2name=N'sAppendTime'
GO
/****** Object:  Table [dbo].[tbStaffInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffInfo](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentsClassID] [int] NOT NULL,
	[sName] [varchar](50) NOT NULL,
	[sSex] [char](2) NOT NULL,
	[sType] [int] NOT NULL,
	[sTel] [varchar](50) NULL,
	[sCarID] [varchar](50) NULL,
	[sEmail] [varchar](50) NULL,
	[sState] [int] NOT NULL,
	[sAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'sName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'sSex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'sType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'sState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffInfo', @level2type=N'COLUMN',@level2name=N'sAppendTime'
GO
/****** Object:  Table [dbo].[tbStaffFamilyDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffFamilyDataInfo](
	[StaffFamilyDataID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[fTitle] [varchar](50) NULL,
	[fName] [varchar](50) NULL,
	[fAge] [varchar](50) NULL,
	[fEnterprise] [varchar](512) NULL,
	[fWork] [varchar](50) NULL,
	[fAddress] [varchar](512) NULL,
	[fTel] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'称谓' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fAge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fEnterprise'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'岗位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fWork'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffFamilyDataInfo', @level2type=N'COLUMN',@level2name=N'fTel'
GO
/****** Object:  Table [dbo].[tbStaffEduDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffEduDataInfo](
	[StaffEduDataID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[eDate] [varchar](50) NOT NULL,
	[eSchools] [varchar](512) NOT NULL,
	[eContent] [varchar](512) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbStaffDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffDataInfo](
	[StaffDataID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[sBirthDay] [varchar](10) NULL,
	[sPolitical] [varchar](50) NULL,
	[sBirthplace] [varchar](50) NULL,
	[sHometown] [varchar](256) NULL,
	[sEducation] [varchar](50) NULL,
	[sProfessional] [varchar](50) NULL,
	[sHealth] [varchar](50) NULL,
	[sHeight] [int] NULL,
	[sWeight] [int] NULL,
	[sSpecialty] [varchar](512) NULL,
	[sHobbies] [varchar](512) NULL,
	[sContactAddress] [varchar](512) NULL,
	[sPhotos] [varchar](128) NULL,
	[sEmployment] [int] NULL,
	[sCanBeDate] [varchar](50) NULL,
	[sTreatment] [money] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sBirthDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sPolitical'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'籍贯' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sBirthplace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sHometown'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最高学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sEducation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sProfessional'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身体状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sHealth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身高' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sHeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'体重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'技能特长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sSpecialty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兴趣爱好' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sHobbies'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sContactAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sPhotos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'就业情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sEmployment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可报到时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sCanBeDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'希望待遇' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffDataInfo', @level2type=N'COLUMN',@level2name=N'sTreatment'
GO
/****** Object:  Table [dbo].[tbStaffAnalysisDataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbStaffAnalysisDataInfo](
	[StaffAnalysisDataID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[aWearing] [int] NOT NULL,
	[aEducation] [int] NOT NULL,
	[aWork] [int] NOT NULL,
	[aCommunication] [int] NOT NULL,
	[aConfidence] [int] NOT NULL,
	[aLeadership] [int] NOT NULL,
	[aJobstability] [int] NOT NULL,
	[aComputer] [int] NOT NULL,
	[aEnglish] [int] NOT NULL,
	[aWritten] [int] NOT NULL,
	[aEvaluation] [int] NOT NULL,
	[aEvaluationMSG] [varchar](512) NULL,
	[aDateTime] [datetime] NOT NULL,
	[aAppendTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属人员编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'StaffID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'形象' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aWearing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aEducation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作经验' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aWork'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'沟通能力' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aCommunication'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自信心' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aConfidence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领导能力' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aLeadership'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作稳定性' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aJobstability'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计算机操作能力' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aComputer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'英语水平' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aEnglish'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'笔试' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aWritten'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'综合评价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aEvaluation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平价信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aEvaluationMSG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'面试时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbStaffAnalysisDataInfo', @level2type=N'COLUMN',@level2name=N'aAppendTime'
GO
/****** Object:  Table [dbo].[tbStaff_Sales_DataInfo]    Script Date: 10/11/2016 09:51:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStaff_Sales_DataInfo](
	[SalesID] [int] NOT NULL,
	[StoresID] [int] NOT NULL,
	[ProductsID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[sdate] [datetime] NOT NULL,
	[sNum] [numeric](18, 6) NOT NULL,
	[sPrice] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[tbsetlastexecutescheduledeventdatetime]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tbsetlastexecutescheduledeventdatetime]
(
	@key VARCHAR(100),
	@servername VARCHAR(100),
	@lastexecuted DATETIME
)
AS
DELETE FROM [tbscheduledevents] WHERE ([key]=@key) AND ([lastexecuted] < DATEADD([day], - 7, GETDATE()))

INSERT [tbscheduledevents] ([key], [servername], [lastexecuted]) Values (@key, @servername, @lastexecuted)
GO
/****** Object:  View [dbo].[viProductBrand]    Script Date: 10/11/2016 09:51:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viProductBrand]
AS
SELECT     pBrand
FROM         dbo.tbProductsInfo
UNION
SELECT     pBrand
FROM         dbo.tbProductsInfo AS tbProductsInfo_1
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[33] 2[14] 3) )"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 3
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 5
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viProductBrand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viProductBrand'
GO
/****** Object:  StoredProcedure [dbo].[sp_ReprotOfStaffByStorehouse]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 业务员门店报表
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReprotOfStaffByStorehouse]
	@dbdate varchar(20),  --年份选择
	@inyStoresID int   --门店编号
AS
     
--删除原数据
If object_id('tempdb..#tbReprotOfStaff') is  not null
Drop table #tbReprotOfStaff
--创建新临时表
Create table #tbReprotOfStaff (
                    sMonth varchar(10),
					sNum1 decimal(18,3),
					sPrice1 decimal(18,3),
					sNum2 decimal(18,3),
					sPrice2 decimal(18,3),
					sNum3 decimal(18,3),
					sPrice3 decimal(18,3),
					sNum4 decimal(18,3),
					sPrice4 decimal(18,3),
					sNum5 decimal(18,3),
					sPrice5 decimal(18,3),
					sNum6 decimal(18,3),
					sPrice6 decimal(18,3),
					sNum7 decimal(18,3),
					sPrice7 decimal(18,3),
					sNum8 decimal(18,3),
					sPrice8 decimal(18,3),
					sNum9 decimal(18,3),
					sPrice9 decimal(18,3),
					sNum10 decimal(18,3),
					sPrice10 decimal(18,3),
					sNum11 decimal(18,3),
					sPrice11 decimal(18,3),
					sNum12 decimal(18,3),
					sPrice12 decimal(18,3)
				)
BEGIN

     begin
			insert into #tbReprotOfStaff 
	        
	        select datepart(month,v.pMonth) as pMonth,isnull(sum(v.sNum1),0) as sNum1,
	                                                 isnull(sum(v.sPrice1),0) as sPrice1,
	                                                 isnull(sum(v.sNum2),0) as sNum2,
	                                                 isnull(sum(v.sPrice2),0) as sPrice2,
	                                                 isnull(sum(v.sNum3),0) as sNum3,
	                                                 isnull(sum(v.sPrice3),0) as sPrice3,
	                                                 isnull(sum(v.sNum4),0) as sNum4,
	                                                 isnull(sum(v.sPrice4),0) as sPrice4,
	                                                 isnull(sum(v.sNum5),0) as sNum5, 
	                                                 isnull(sum(v.sPrice5),0) as sPrice5,
	                                                 isnull(sum(v.sNum6),0) as sNum6,
	                                                 isnull(sum(v.sPrice6),0) as sPrice6,
	                                                 isnull(sum(v.sNum7),0) as sNum7,
	                                                 isnull(sum(v.sPrice7),0) as sPrice7,
	                                                 isnull(sum(v.sNum8),0) as sNum8,
	                                                 isnull(sum(v.sPrice8),0) as sPrice8,
	                                                 isnull(sum(v.sNum9),0) as sNum9,
	                                                 isnull(sum(v.sPrice9),0) as sPrice9,
	                                                 isnull(sum(v.sNum10),0) as sNum10,
	                                                 isnull(sum(v.sPrice10),0) as sPrice10,
	                                                 isnull(sum(v.sNum11),0) as sNum11,
	                                                 isnull(sum(v.sPrice11),0) as sPrice11,
	                                                 isnull(sum(v.sNum12),0) as sNum12,
	                                                 isnull(sum(v.sPrice12),0) as sPrice12
	                                               
	        from(select datepart(month,sDateTime) as pMonth,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=1 then sNum else 0 end as sNum1, 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=1 then sPrice else 0 end as sPrice1,
				  
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=2 then sNum else 0 end as sNum2,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=2 then sPrice else 0 end as sPrice2,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=3 then sNum else 0 end as sNum3 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=3 then sPrice else 0 end as sPrice3 ,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=4 then sNum else 0 end as sNum4 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=4 then sPrice else 0 end as sPrice4,
				
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=5 then sNum else 0 end as sNum5 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=5 then sPrice else 0 end as sPrice5,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=6 then sNum else 0 end as sNum6 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=6 then sPrice else 0 end as sPrice6,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=7 then sNum else 0 end as sNum7 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=7 then sPrice else 0 end as sPrice7,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=8 then sNum else 0 end as sNum8 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=8 then sPrice else 0 end as sPrice8,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=9 then sNum else 0 end as sNum9 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=9 then sPrice else 0 end as sPrice9,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=10 then sNum else 0 end as sNum10 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=10 then sPrice else 0 end as sPrice10,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=11 then sNum else 0 end as sNum11 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=11 then sPrice else 0 end as sPrice11,
				 
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=12 then sNum else 0 end as sNum12 ,
				 case when datepart(YEAR,sDateTime)=@dbdate and datepart(month,sDateTime)=12 then sPrice else 0 end as sPrice12   
				
				 from tbSalesInfo where StoresID=@inyStoresID) as v
	         group by datepart(month,v.pMonth)
	         
	        
     end
     
    select 
      isnull(sNum1,0) as sNum1,
      isnull(sPrice1,0) as sPrice1,
      
      isnull(sNum2,0) as sNum2,
      isnull(sPrice2,0) as sPrice2,
      
      isnull(sNum3,0) as sNum3,
      isnull(sPrice3,0) as sPrice3,
      
      isnull(sNum4,0) as sNum4,
      isnull(sPrice4,0) as sPrice4,
      
      isnull(sNum5,0) as sNum5,
      isnull(sPrice5,0) as sPrice5,
      
      isnull(sNum6,0) as sNum6,
      isnull(sPrice6,0) as sPrice6,
      
      isnull(sNum7,0) as sNum7,
      isnull(sPrice7,0) as sPrice7,
      
      isnull(sNum8,0) as sNum8,
      isnull(sPrice8,0) as sPrice8,
      
      isnull(sNum9,0) as sNum9,
      isnull(sPrice9,0) as sPrice9,
      
      isnull(sNum10,0) as sNum10,
      isnull(sPrice10,0) as sPrice10,
      
      isnull(sNum11,0) as sNum11,
      isnull(sPrice11,0) as sPrice11,
      
      isnull(sNum12,0) as sNum12,
      isnull(sPrice12,0) as sPrice12
      
     from #tbReprotOfStaff 
	Drop table #tbReprotOfStaff;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReprotOfStaffByMonth]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-8-8
-- Description:	人员岗位月报表
-- =============================================
creaTE PROCEDURE [dbo].[sp_ReprotOfStaffByMonth]
	@inyDate varchar(20)		--年份
AS

	declare @month int;
    declare @sNum int=0;
    
  
--删除原数据
If object_id('tempdb..#tbReprotOfStaff') is  not null
Drop table #tbReprotOfStaff
--创建新临时表
Create table #tbReprotOfStaff (
                    tYear int,
					tMonth int,
					sNum int
				)
BEGIN
	 select @month=DATEDIFF(MONTH,CONVERT(datetime,@inyDate+'-01-01'),CONVERT(datetime,@inyDate+'-12-31'))+1
	 
	 while(@month>0)
     begin
			insert into #tbReprotOfStaff(tYear,tMonth,sNum ) values(@inyDate,@month,0)
			
			insert into #tbReprotOfStaff(tYear,tMonth,sNum ) 
	        
	        select DATEPART(YEAR,sDateTime) as sYear,DATEPART(MONTH,sDateTime) as sMonth,COUNT(distinct(StaffID)) as sCount
			  from tbStaffStoresInfo where sType=0 group by DATEPART(YEAR,sDateTime),DATEPART(MONTH,sDateTime)
			    having DATEPART(YEAR,sDateTime)=@inyDate and DATEPART(MONTH,sDateTime)=@month
	        
			set @month=@month-1;

     end
      
    
     
     select tYear,tMonth,isnull(sum(sNum),0) as sNum from #tbReprotOfStaff 
        group by tYear,tMonth order by tMonth asc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReportOfStorehouseStorage]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 实现客户进销存报表
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReportOfStorehouseStorage]
	@inyRegionID int=-1,               --区域选择
	@inyStorageID int=-1,              --门店名称选择
	@chvStaffID int=-1,                --营业员名称选择
	@dtmbAppendTime datetime=getdate,  --开始时间选择
	@dtmeAppendTime datetime=getdate,  --结束时间选择
	@reType int,                       --状态 -1=全部，0 =进货 ，1=销售 ，2=库存  
	@associated int                    --联营  -1=包含 ，0=剔除，1=仅包含
AS
BEGIN

--===================================================================================
--区域选中——时间——类型——联营：包含
--===================================================================================
    --查询该区域单独选择数据,状态为全部=-1
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=-1 and @associated=-1) 
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney ) as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ProductsID) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                left join 
              (select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
               (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join   
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID
    end
	--查询该区域单独选择数据,状态为=0:进货
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=-1) 
	begin
    select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	end
	--查询该区域单独选择数据,状态为=1:销售
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=-1) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID 
	end
	--查询该区域单独选择数据,状态为=2:库存
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=-1) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--营业员查询
		group by ProductsID) as r on r.ProductsID=p.ProductsID          
	end
	
--===================================================================================
--区域选中——时间——类型——联营：剔除
--===================================================================================
    --查询该区域单独选择数据,状态为全部=-1
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=-1 and @associated=0) 
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                left join 
              (select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
               (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join   
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
     end   
	--查询该区域单独选择数据,状态为=0:进货
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=0) 
	begin
    select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--查询该区域单独选择数据,状态为=1:销售
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=0) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID  where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--查询该区域单独选择数据,状态为=2:库存
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=0) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--营业员查询
		group by ProductsID ) as r on r.ProductsID=p.ProductsID  where p.ProductsID  not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)     
	end
	
	
--===================================================================================
--区域选中——时间——类型——联营：仅包含
--===================================================================================
    --查询该区域单独选择数据,状态为全部=-1
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=-1 and @associated=1) 
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                 group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                left join 
              (select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
               (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join   
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID in(select ProductsID from tbProductPoolDataInfo where  Edate>=@dtmeAppendTime)
       end
	--查询该区域单独选择数据,状态为=0:进货
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=1) 
	begin
    select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID in(select ProductsID from tbProductPoolDataInfo where  Edate>=@dtmeAppendTime)
	end
	--查询该区域单独选择数据,状态为=1:销售
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=1) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--查询该区域单独选择数据,状态为=2:库存
	if(@inyRegionID >-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=1) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--营业员查询
		group by ProductsID) as r on r.ProductsID=p.ProductsID   where p.ProductsID in(select ProductsID from tbProductPoolDataInfo where  Edate>=@dtmeAppendTime)       
	end
--===================================================================================
--区域为“全部选择”——时间——类型——联营：包含
--===================================================================================
	--如果区域为"全部选择"的话,状态为-1:全部
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID=-1 and @reType=-1 and @associated=-1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ProductsID) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join 
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	end
	--如果区域为"全部选择"的话,状态为0:进货
	
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=-1) 
	begin
                select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	end
	--如果区域为"全部选择"的话,状态为1:销售
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=-1) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID 
	end
	--如果区域为"全部选择"的话,状态为2:库存
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=-1) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
	    group by ProductsID) as r on r.ProductsID=p.ProductsID          
	end

--===================================================================================
--区域为“全部选择”——时间——类型——联营：剔除
--===================================================================================
	--如果区域为"全部选择"的话,状态为-1:全部
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID=-1 and @reType=-1 and @associated=0)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join 
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为0:进货
	
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=0) 
	begin
                select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为1:销售
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=0) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为2:库存
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=0) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
	    group by ProductsID) as r on r.ProductsID=p.ProductsID where p.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)         
	end
	
--===================================================================================
--区域为“全部选择”——时间——类型——联营：仅联营
--===================================================================================
	--如果区域为"全部选择"的话,状态为-1:全部
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID=-1 and @reType=-1 and @associated=1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join 
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为0:进货
	
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=0 and @associated=1) 
	begin
                select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为1:销售
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=1 and @associated=1) 
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--如果区域为"全部选择"的话,状态为2:库存
	if(@inyRegionID =-1 and @inyStorageID=-1 and @chvStaffID =-1 and @reType=2 and @associated=1) 
	begin
	   select p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
	    group by ProductsID ) as r on r.ProductsID=p.ProductsID where p.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)         
	end		
--===================================================================================
--区域、营业员联合选中——时间——类型——联营：包含
--===================================================================================
	--区域、营业员联合查询,状态为-1:全部
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=-1 and @associated=-1)
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
           from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                   and StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                  group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	
	end
	--区域、营业员联合查询,状态0=进货
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=0 and @associated=-1)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	end
	--区域、营业员联合查询,状态1=销售
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=1 and @associated=-1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID 
	end
	--区域、营业员联合查询,状态2=库存
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=2 and @associated=-1)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员查询
		and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
	  group by ProductsID ) as r on r.ProductsID=p.ProductsID          
	end
	
--===================================================================================
--区域、营业员联合选中——时间——类型——联营：剔除
--===================================================================================
	--区域、营业员联合查询,状态为-1:全部
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=-1 and @associated=0)
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
           from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                   and StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                 group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	
	end
	--区域、营业员联合查询,状态0=进货
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=0 and @associated=0)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员联合查询,状态1=销售
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=1 and @associated=0)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员联合查询,状态2=库存
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=2 and @associated=0)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员查询
		and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
	    group by ProductsID) as r on r.ProductsID=p.ProductsID  where p.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)        
	end
	
--===================================================================================
--区域、营业员联合选中——时间——类型——联营：仅联营
--===================================================================================
	--区域、营业员联合查询,状态为-1:全部
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=-1 and @associated=1)
	begin
	 select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
           from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,sum(pMoney)  as pPrice,sum(pRelityStorage) as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                   and StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                 group by ProductsID ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                     and oi.StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	
	end
	--区域、营业员联合查询,状态0=进货
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=0 and @associated=1)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StaffID=@chvStaffID--营业员查询
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员联合查询,状态1=销售
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=1 and @associated=1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--业务员ID进行查询
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员联合查询,状态2=库存
	if(@inyStorageID=-1 and @chvStaffID>-1 and @inyRegionID>-1 and @reType=2 and @associated=1)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,sum(pRelityStorage) as pRelityStorage,sum(pMoney) as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID in (select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@chvStaffID)--营业员查询
		and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
	    group by ProductsID) as r on r.ProductsID=p.ProductsID  where p.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)        
	end
--===================================================================================
--区域、营业员、门店联合选择——时间——类型——联营：包含
--===================================================================================
	--区域、营业员、门店联合查询，状态-1：全部
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=-1 and @associated=-1)
	begin
	
	  select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3  and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,pMoney  as pPrice,pRelityStorage as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  and StoresID=@inyStorageID --门店
                  ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID  --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID=@inyStorageID --门店
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID =@inyStorageID --门店
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                 (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  =@inyStorageID
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID=@inyStorageID --门店
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
	end
	--区域、营业员、门店联合查询，状态0：进货
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=0 and @associated=-1)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID 
         
	end
	--区域、营业员、门店联合查询，状态1：销售
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=1 and @associated=-1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID=@inyStorageID--门店
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID 
	end
	--区域、营业员、门店联合查询，状态2：库存
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=2 and @associated=-1)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,pRelityStorage as pRelityStorage,pMoney as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID=@inyStorageID --门店
		) as r on r.ProductsID=p.ProductsID          
	end

--===================================================================================
--区域、营业员、门店联合选择——时间——类型——联营：剔除
--===================================================================================
	--区域、营业员、门店联合查询，状态-1：全部
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=-1 and @associated=0)
	begin
	
	  select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3  and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,pMoney  as pPrice,pRelityStorage as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  and StoresID=@inyStorageID --门店
                  ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID  --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID=@inyStorageID --门店
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID =@inyStorageID --门店
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                 (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  =@inyStorageID
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID=@inyStorageID --门店
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员、门店联合查询，状态0：进货
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=0 and @associated=0)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
         
	end
	--区域、营业员、门店联合查询，状态1：销售
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=1 and @associated=0)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID=@inyStorageID--门店
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员、门店联合查询，状态2：库存
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=2 and @associated=0)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,pRelityStorage as pRelityStorage,pMoney as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID=@inyStorageID --门店
		) as r on r.ProductsID=p.ProductsID  where p.ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)        
	end	
--===================================================================================
--区域、营业员、门店联合选择——时间——类型——联营：仅联营
--===================================================================================
	--区域、营业员、门店联合查询，状态-1：全部
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=-1 and @associated=1)
	begin
	
	  select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,isnull(psi.RelityStorage,0) as RelityStorage,
           isnull(psi.InQuantity,0) as InQuantity,isnull(psi.OutQuantity,0) as OutQuantity,isnull(psi.oMoney,0) as oMoney,isnull(psi.SalesPrice,0) as SalesPrice ,isnull(psi.pPrice,0) as  pPrice,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pci.RelityStorage,pci.pPrice,pp.ProductsID,pp.oMoney,pp.InQuantity,ss.SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity
               
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=3  and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
	              
	              --期初金额
	              ( select ProductsID,pMoney  as pPrice,pRelityStorage as RelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  and StoresID=@inyStorageID --门店
                 ) as pci on pci.ProductsID=pp.ProductsID full join 
	              
	                  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID  --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID=@inyStorageID --门店
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                   and ssi.StoresID =@inyStorageID --门店
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                 (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  =@inyStorageID
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID  full join  
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                  and s.StoresID=@inyStorageID --门店
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID )psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员、门店联合查询，状态0：进货
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=0 and @associated=1)
	begin
          select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
          isnull(psi.InQuantity,0) as InQuantity,isnull(psi.oMoney,0) as oMoney,
          isnull(psi.GiveQuantity,0)as GiveQuantity,isnull(psi.GivePrice,0) as GivePrice,
          isnull(psi.yQuantity,0)as yQuantity,isnull(psi.yPrice,0) as yPrice,
          isnull(psi.tQuantity,0)as outQuantity,isnull(psi.tPrice,0) as OutPrice
          from tbProductsInfo as ppi left join(
            select outquantity.tQuantity,outquantity.tPrice,yping.yQuantity,yping.yPrice,give.GiveQuantity,give.GivePrice,pp.ProductsID,pp.oMoney,pp.InQuantity
            from (
                  
                --//进货  
               select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as InQuantity,InQuantity.oMoney from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =3 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as pp   full join 
  
                --赠品
              (select ssi.ProductsID,sum(isnull(ssi.pMoney*givequantity.GiveQuantity,0))  as GivePrice ,isnull(sum(givequantity.GiveQuantity),0) as GiveQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as givequantity on givequantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID ) as give on give.ProductsID=pp.ProductsID   full join
                  
                         
                  --样品
             ( select ssi.ProductsID,sum(isnull(ssi.pMoney*yquantity.GiveQuantity,0))  as yPrice ,isnull(sum(yquantity.GiveQuantity),0) as yQuantity from tbStoreStorehouseInfo   as ssi
                   left join 
              ( select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as GiveQuantity from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType=6 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )  as yquantity on yquantity.ProductsID=ssi.ProductsID
                  
                  where (ssi.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                  group by ssi.ProductsID) as yping on yping.ProductsID=pp.ProductsID full join 
	              
	               --退货
              
                (select distinct(p.ProductsID),isnull(Inquantity.InQuantity,0)as tQuantity,isnull(InQuantity.oMoney,0) as tPrice from tbProductsInfo as p left join(
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType =4 and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID=@inyStorageID --门店
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.pAppendTime between @dtmbAppendTime and @dtmeAppendTime)  --时间
                 and oli.oWorkType>=1 group by oli.ProductsID  )as Inquantity
	              on p.ProductsID=Inquantity.ProductsID) as outquantity on outquantity.ProductsID=pp.ProductsID) as psi  
                  
                 on ppi.ProductsID=psi.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
         
	end
	--区域、营业员、门店联合查询，状态1：销售
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=1 and @associated=1)
	begin
	   select ppi.ProductsID,ppi.pBarcode,ppi.pName,ppi.pToBoxNo,
               isnull(ss.OutQuantity,0) as OutQuantity,isnull(ss.SalesPrice,0) as SalesPrice 
                 from tbProductsInfo as ppi left join
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbAppendTime and @dtmeAppendTime)--时间
                   and s.StoresID=@inyStorageID--门店
                  group by s.ProductsID ) as ss  on ppi.ProductsID=ss.ProductsID where ppi.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)
	end
	--区域、营业员、门店联合查询，状态2：库存
	if(@inyStorageID>-1 and @inyRegionID>-1 and @chvStaffID>-1 and @reType=2 and @associated=1)
	begin
	   select  p.ProductsID,p.pName,p.pBarcode,p.pToBoxNo,ISNULL(r.pRelityStorage,0) as RelityStorage,isnull(r.pMoney,0) as pPrice from tbProductsInfo as p left join 
		(select ProductsID,pRelityStorage as pRelityStorage,pMoney as pMoney from tbStoreStorehouseInfo
		where (pAppendTime between  @dtmbAppendTime and @dtmeAppendTime)--时间
		and  StoresID=@inyStorageID --门店
		) as r on r.ProductsID=p.ProductsID  where p.ProductsID  in(select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeAppendTime)        
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_report_out_Export]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		yangangol
-- Create date: 2011-6-28
-- Description:	导出出货数据
-- =============================================
CREATE PROCEDURE [dbo].[sp_report_out_Export]
	@dtmBdate datetime,   --导出日期
	@inyCheckValue int    --导出类别 0=单品；1=客户；2=品牌；3=区域；4=业务员
AS
BEGIN
    --按单品
    if(@inyCheckValue=0)
    begin
        select p.ProductsID,p.pName,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from(
		select oli.ProductsID,isnull(sum(oli.oQuantity),0) as oQuantity,isnull(sum(oli.oMoney),0) as oMoney from tbOrderInfo as oi 
		left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmBdate)=0) group by oli.ProductsID) as pp right join
		tbProductsInfo as p on p.ProductsID=pp.ProductsID where p.pState=0 order by p.ProductsID asc
    end
	--按客户
    if(@inyCheckValue=1)
    begin
        select si.StoresID,si.sName,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from (
		select oi.StoresID,isnull(sum(oli.oQuantity),0) as oQuantity,isnull(sum(oli.oMoney),0) as oMoney from tbOrderInfo as oi 
		left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmBdate)=0) group by  oi.StoresID) as qq
		right join tbStoresInfo as si on qq.StoresID=si.StoresID where si.sState=0 order by si.StoresID
    end
    --按品牌
    if(@inyCheckValue=2)
    begin
        select p.pBrand,isnull(sum(pp.oQuantity),0) as oQuantity,isnull(sum(pp.oMoney),0) as oMoney from(
		select oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oMoney,0) as oMoney from tbOrderInfo as oi 
		left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmBdate)=0)) as pp right join
		tbProductsInfo as p on p.ProductsID=pp.ProductsID where p.pState=0 group by p.pBrand order by p.pBrand asc
    end
    --按区域
    if(@inyCheckValue=3)
    begin
        select ri.RegionID,ri.rName,isnull(pp.oQuantity,0) as RegionID,isnull(pp.oMoney,0) as oMoney from (
		select si.RegionID,isnull(sum(qq.oQuantity),0) as oQuantity,isnull(sum(qq.oMoney),0) as oMoney from (
		select oi.StoresID,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oMoney,0) as oMoney from tbOrderInfo as oi 
		left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmBdate)=0)) as qq
		left join tbStoresInfo as si on qq.StoresID=si.StoresID  group by si.RegionID) as pp right join tbRegionInfo as ri
		on ri.RegionID=pp.RegionID where ri.rState=0 order by ri.RegionID asc
    end
    --按业务员
    if(@inyCheckValue=4)
    begin
        select si.StaffID,si.sName,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney  from (
		select oi.StaffID,isnull(sum(oli.oQuantity),0) as oQuantity,isnull(sum(oli.oMoney),0) as oMoney from tbOrderInfo as oi 
		left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmBdate)=0)
		group by oi.StaffID) as pp right join tbStaffInfo as si on si.StaffID=pp.StaffID where si.sState=0 and si.sType=1 order by si.StaffID asc
    end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OpeningBalance]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-8-19
-- Description:	发生额及余额期初数据判断
-- =============================================
CREATE PROCEDURE [dbo].[sp_OpeningBalance]
	@dtmbDate datetime,			--开始日期
	@dtmeDate datetime,		    --结束日期
	@FeesSubjectClassID int,	--科目编号
	@inyStatus int				--审核状态
AS
	  
	  --无数据
	  declare @OpeningBalance_No table(
						FeesSubjectClassID int,		--科目编号
						AccountMoney money			--期初余额
								 )
  
	  
	  --有数据
      declare @OpeningBalance table(
						FeesSubjectClassID int,		--科目编号
						JAccountMoney money,		--期初余额-借方
						DAccountMoney money			--期初余额-贷方
								)
	--判断查询日期前是否有发生账户数据
	declare @CountData int;
	select @CountData=COUNT(1) from tbCertificateDataInfo as ci 
		left join tbCertificateInfo as c on ci.CertificateID=c.CertificateID
			where c.cState=0 and ci.FeesSubjectID=@FeesSubjectClassID and c.cDateTime<@dtmbDate
			
	--1、如果查询日期前无账单数据
	if(@CountData=0)
	begin
	   insert into @OpeningBalance_No(FeesSubjectClassID,AccountMoney)
	   select bi.FeesSubjectClassID,cAccountMoney from tbBankCapitalAccountInfo as bi left join 
	   tbFeesSubjectClassInfo as fi on bi.FeesSubjectClassID=fi.FeesSubjectClassID 
	   
	   where bi.FeesSubjectClassID=@FeesSubjectClassID
	     and pAppendTime<=@dtmbDate
	end
	--2、如果查询日期前有账单数据:已审核
	if(@CountData>0 and @inyStatus=1)
	begin
	  insert into @OpeningBalance(FeesSubjectClassID,JAccountMoney,DAccountMoney)
	  
	  select fsi.FeesSubjectClassID,
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as JMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as DMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,cAccountMoney from tbBankCapitalAccountInfo 
		  where pAppendTime<@dtmbDate and FeesSubjectClassID=@FeesSubjectClassID) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime<@dtmbDate 
				--已审核
				 and ci.cSteps=1 and ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) 
				
				 and cfi.FeesSubjectID=@FeesSubjectClassID
				  group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 
	end
	--3、如果查询日期前有账单数据:全部
	if(@CountData>0 and @inyStatus=0)
	begin
	  insert into @OpeningBalance(FeesSubjectClassID,JAccountMoney,DAccountMoney)
	  
	  select fsi.FeesSubjectClassID,
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as JMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as DMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,cAccountMoney from tbBankCapitalAccountInfo 
		  where pAppendTime<@dtmbDate and FeesSubjectClassID=@FeesSubjectClassID) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime<@dtmbDate 
				 and cfi.FeesSubjectID=@FeesSubjectClassID
				  group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 
	end
BEGIN
	--本期发生及期末余额
	--1、是否之前有凭证数据产生-无数据产生
	if(@CountData=0 and @inyStatus=0)
	begin
		 select fsi.cDirection,fsi.FeesSubjectClassID,
         fsi.cCode,fsi.cClassName,
         isnull(pp.cAccountMoney,0) as cAccountMoney,   --期初
          isnull(qq.cdMoney,0) as JcdMoney,				--本期发生借
            isnull(qq.cdMoneyB,0) as DcdMoney,			--本期发生贷
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as oMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as iMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,AccountMoney as cAccountMoney from @OpeningBalance_No
		) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime 
				between @dtmbDate and @dtmeDate  and cfi.FeesSubjectID=@FeesSubjectClassID
				 group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 order by fsi.cCode asc
	end
	
	
	if(@CountData=0 and @inyStatus=1)
	begin
		 select fsi.cDirection,fsi.FeesSubjectClassID,
         fsi.cCode,fsi.cClassName,
         isnull(pp.cAccountMoney,0) as cAccountMoney,   --期初
          isnull(qq.cdMoney,0) as JcdMoney,				--本期发生借
            isnull(qq.cdMoneyB,0) as DcdMoney,			--本期发生贷
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as oMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as iMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,AccountMoney as cAccountMoney from @OpeningBalance_No
		) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime 
				between @dtmbDate and @dtmeDate  and cfi.FeesSubjectID=@FeesSubjectClassID
				and ci.cSteps=1 and ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) 
				 group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 order by fsi.cCode asc
	end
	--2、是否之前有凭证数据产生-有数据产生
    if(@CountData>0 and @inyStatus=0)
    begin
		 select fsi.cDirection,fsi.FeesSubjectClassID,
         fsi.cCode,fsi.cClassName,
         isnull(pp.cAccountMoney,0) as cAccountMoney,   --期初
          isnull(qq.cdMoney,0) as JcdMoney,				--本期发生借
            isnull(qq.cdMoneyB,0) as DcdMoney,			--本期发生贷
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as oMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as iMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,
			case when JAccountMoney <>0 then JAccountMoney else DAccountMoney end as  cAccountMoney
		 from @OpeningBalance
		) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime 
				between @dtmbDate and @dtmeDate  and cfi.FeesSubjectID=@FeesSubjectClassID
				group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 order by fsi.cCode asc
    end
    
     if(@CountData>0 and @inyStatus=1)
    begin
		 select fsi.cDirection,fsi.FeesSubjectClassID,
         fsi.cCode,fsi.cClassName,
         isnull(pp.cAccountMoney,0) as cAccountMoney,   --期初
          isnull(qq.cdMoney,0) as JcdMoney,				--本期发生借
            isnull(qq.cdMoneyB,0) as DcdMoney,			--本期发生贷
		--科目为借：借+借-贷
		case when fsi.cDirection=0 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as oMoney,        
		--科目为贷：贷+贷-借
		case when fsi.cDirection=1 
			 then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as iMoney
		 from tbFeesSubjectClassInfo as  fsi left join
		(
		--期初余额
		select FeesSubjectClassID,
			case when JAccountMoney <>0 then JAccountMoney else DAccountMoney end as  cAccountMoney
		 from @OpeningBalance
		) as pp 
		on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
	   
	   --本期发生
		select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
		   from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
			 on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime 
				between @dtmbDate and @dtmeDate  and cfi.FeesSubjectID=@FeesSubjectClassID
				and ci.cSteps=1 and ci.CertificateID in(select CertificateID from tbCertificateWorkingLogInfo where cType=2) 
				 group by cfi.FeesSubjectID) qq 
		on qq.FeesSubjectID=fsi.FeesSubjectClassID  
	    
		where qq.cdMoney <>0 or qq.cdMoneyB <>0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) <>0
		or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) <>0 order by fsi.cCode asc
    end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Occurrence_forehead_and_balance_do]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-7-25
-- Description:	费用明细账
-- =============================================
CREATE PROCEDURE [dbo].[sp_Occurrence_forehead_and_balance_do]
	@inySubject int,     --科目
	@btmBdate datetime,  --开始日期
	@btmEdate datetime,  --结束日期
	@inyMonth int,       --月份
	@inyStype int,		 --统计类型
	@inyStatus int		 --审核状态
AS
    declare @DateCount int;				 --计算日期间隔
    declare @DataCount int;			     --计数
    declare @i int;						 --循环使用
    
    set @i=0;
	set @DateCount=DATEPART(MONTH,@btmEdate)-DATEPART(MONTH,@btmBdate)+1;		--找到日期间隔数
BEGIN
 
    --创建临时表
	If object_id('tempdb..#tbAccountDetails_tmp') is  not null
	Drop table #tbAccountDetails_tmp
	--创建新临时表
	create table #tbAccountDetails_tmp (
	                                    Cmonth varchar(20),
	                                    Cday varchar(20),
	                                    pzCode  int,
	                                    CertificateID int,
	                                    cdName varchar(512),
	                                    cdMoney money,
	                                    cdMoneyB money,
	                                    cDirection int,
	                                    FeesSubjectID int,
	                                    cClassName varchar(50),
	                                    cCode int,
	                                    unit varchar(512)	--单位
	                                   )
    if(@inyStatus=0)
    begin
		while @i<@DateCount
		begin
		   insert into #tbAccountDetails_tmp(Cmonth,Cday,pzCode,CertificateID,cdName,cdMoney,cdMoneyB,cDirection,FeesSubjectID,cClassName,cCode,unit)
		   select convert(varchar,datepart(month,qq.cDateTime)) as Cmonth
			,convert(varchar,datepart(DAY,qq.cDateTime)) as Cday,qq.cNumber as pzCode,qq.CertificateID,qq.cdName,
			  qq.cdMoney,qq.cdMoneyB,fsi.cDirection,qq.FeesSubjectID,fsi.cClassName,fsi.cCode,qq.toObjectID from (
			   select cfi.CertificateID,ci.FeesSubjectID,ci.cdName,ci.toObjectID,cfi.cNumber,isnull(ci.cdMoney,0) as cdMoney,isnull(ci.cdMoneyB,0) as cdMoneyB,
				cfi.cDateTime from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID 
				  where cfi.cState=0 and DATEDIFF(MONTH,cfi.cDateTime,@btmBdate)=0 and ci.FeesSubjectID=@inySubject
					   ) as qq left join tbFeesSubjectClassInfo as fsi on qq.FeesSubjectID=fsi.FeesSubjectClassID
						 order by Cmonth,Cday asc
			set @btmBdate=DATEADD(MONTH,1,@btmBdate);
			set @i=@i+1;
		end
	end
	if(@inyStatus=1)
    begin
		while @i<@DateCount
		begin
		   insert into #tbAccountDetails_tmp(Cmonth,Cday,pzCode,CertificateID,cdName,cdMoney,cdMoneyB,cDirection,FeesSubjectID,cClassName,cCode,unit)
		   select convert(varchar,datepart(month,qq.cDateTime)) as Cmonth
			,convert(varchar,datepart(DAY,qq.cDateTime)) as Cday,qq.cNumber as pzCode,qq.CertificateID,qq.cdName,
			  qq.cdMoney,qq.cdMoneyB,fsi.cDirection,qq.FeesSubjectID,fsi.cClassName,fsi.cCode,qq.toObjectID from (
			   select cfi.CertificateID,ci.FeesSubjectID,ci.cdName,ci.toObjectID,cfi.cNumber,isnull(ci.cdMoney,0) as cdMoney,isnull(ci.cdMoneyB,0) as cdMoneyB,
				cfi.cDateTime from tbCertificateDataInfo as ci left join tbCertificateInfo as cfi on ci.CertificateID=cfi.CertificateID 
				  where cfi.cState=0 and DATEDIFF(MONTH,cfi.cDateTime,@btmBdate)=0 and cfi.cSteps=1 and cfi.CertificateID in (select CertificateID from tbCertificateWorkingLogInfo where cType=2)
				   and ci.FeesSubjectID=@inySubject
					   ) as qq left join tbFeesSubjectClassInfo as fsi on qq.FeesSubjectID=fsi.FeesSubjectClassID
						 order by Cmonth,Cday asc
			set @btmBdate=DATEADD(MONTH,1,@btmBdate);
			set @i=@i+1;
		end
	end
	--明细统计
	if(@inyStype=0)
	begin
	  
		select 
		   case when Cmonth>0 and Cmonth<10 then '0'+Cmonth else Cmonth end as Cmonth,
		   case when Cday>0 and Cday<10 then '0'+Cday else Cday end as Cday,CertificateID,
		   pzCode,cdName,cdMoney,-cdMoney as cdMoneyA,cdMoneyB,-cdMoneyB as cdMoneyBB,cDirection,FeesSubjectID,cClassName,cCode,unit from #tbAccountDetails_tmp 
		       where FeesSubjectID=@inySubject and Cmonth=@inyMonth order by Cday asc
	end
	--总账统计
	if(@inyStype=1)
	begin
		select FeesSubjectID,case when Cmonth>0 and Cmonth<10 then '0'+Cmonth else Cmonth end as Cmonth,Cmonth as monthR
		  ,sum(cdMoney) as cdMoney,-sum(cdMoney) as cdMoneyA,sum(cdMoneyB) as cdMoneyB,-sum(cdMoneyB) as cdMoneyBB
		   from #tbAccountDetails_tmp where Cmonth=@inyMonth and FeesSubjectID=@inySubject
			  group by FeesSubjectID,Cmonth order by Cmonth 
	end
	DROP TABLE #tbAccountDetails_tmp;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Occurrence_forehead_and_balance]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YANGANGOL
-- Create date: 2011-7-21
-- Description:	发生额及余额
-- =============================================
CREATE PROCEDURE [dbo].[sp_Occurrence_forehead_and_balance]
	@dtmbDate datetime,    --开始日期
	@dtmeDate datetime     --结束日期
AS
    
BEGIN

  select fsi.cDirection,fsi.FeesSubjectClassID,
         fsi.cCode,fsi.cClassName,
         isnull(pp.cAccountMoney,0) as cAccountMoney,
          isnull(qq.cdMoney,0) as JcdMoney,
            isnull(qq.cdMoneyB,0) as DcdMoney,
    case when fsi.cDirection=0 
         then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) else 0 end as oMoney,        
    
    case when fsi.cDirection=1 
         then isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) else 0 end as iMoney
     from tbFeesSubjectClassInfo as  fsi left join
    (
    --期初余额
    select ba.FeesSubjectClassID,fi.cCode,ba.cAccountName,ba.cAccountMoney from tbBankCapitalAccountInfo as ba
     left join tbFeesSubjectClassInfo as fi on ba.FeesSubjectClassID=fi.FeesSubjectClassID
      where pAppendTime between @dtmbDate and @dtmeDate) as pp 
    on pp.FeesSubjectClassID=fsi.FeesSubjectClassID full join(
   
   --本期发生
    select cfi.FeesSubjectID,isnull(sum(cfi.cdMoney),0) as cdMoney,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB 
       from tbCertificateInfo as ci  right join tbCertificateDataInfo as cfi 
         on ci.CertificateID=cfi.CertificateID where ci.cState=0 and ci.cDateTime 
            between @dtmbDate and @dtmeDate and cfi.CertificateID in(select CertificateID 
             from tbCertificateWorkingLogInfo where cType=2) group by cfi.FeesSubjectID) qq 
    on qq.FeesSubjectID=fsi.FeesSubjectClassID  
    
    where qq.cdMoney !=0 or qq.cdMoneyB !=0 or  isnull(pp.cAccountMoney,0)+isnull(qq.cdMoney,0)-isnull(qq.cdMoneyB,0) !=0
    or isnull(pp.cAccountMoney,0)+isnull(qq.cdMoneyB,0)-isnull(qq.cdMoney,0) !=0 order by fsi.cCode asc

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsRegionDetailes]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 单品区域详情
-- =============================================
CREATE PROCEDURE [dbo].[sp_ProductsRegionDetailes]
	 @inyRegionID int,                   --区域ID
	 @inyProductsID int,                 --产品编号
	 @dtmbDate datetime,                 --开始时间
	 @dtmeDate datetime                  --结束时间
AS
BEGIN
          select isnull(pci.pRelityStorage,0) as RelityStorage,isnull(pci.pPrice,0) as pPrice
          ,pp.ProductsID,isnull(pp.oMoney,0) as oMoney,isnull(pp.InQuantity,0) as InQuantity
          ,isnull(ss.SalesPrice,0) as SalesPrice,isnull(ss.OutQuantity,0) as OutQuantity    
              from (  
                --//进货  
                 select oli.ProductsID,ISNULL(SUM(distinct(oli.oQuantity)),0) as InQuantity, isnull(sum(oli.oMoney),0)as oMoney from tbOrderListInfo as oli left join 
	              (select oi.OrderID,oi.oAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
                     where oi.oType in (3,4) and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 
                     and oi.StoresID  in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                      ) as orderQuantity   
	             on oli.OrderID=orderQuantity.OrderID  
	             where (orderQuantity.oAppendTime between @dtmbDate and @dtmeDate)  --时间
	             and oli.ProductsID=@inyProductsID--产品
                 and oli.oWorkType>=1 group by oli.ProductsID ) as pp   left join 
	              
	              --期初
	              ( select ProductsID,sum(isnull(pRelityStorage*pMoney,0))  as pPrice ,sum(isnull(pRelityStorage,0)) as  pRelityStorage  from tbStoreStorehouseInfo  
                  where (pAppendTime between @dtmbDate and @dtmeDate)  --时间
                   and StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)--区域
                   and ProductsID=@inyProductsID--产品
                  group by ProductsID) as pci on pci.ProductsID=pp.ProductsID left join 
	              
	             --//销售
                  (select s.ProductsID,isnull(sum(s.sNum),0) as OutQuantity,isnull(sum(s.sPrice*s.sNum),0) as SalesPrice  from tbSalesInfo s 
                  where  (s.sDateTime between @dtmbDate and @dtmeDate)--时间
                  and s.StoresID in (select StoresID from tbStoresInfo where RegionID=@inyRegionID)    --区域
                  and s.ProductsID=@inyProductsID--产品
                  group by s.ProductsID ) as ss  on pp.ProductsID=ss.ProductsID 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_sales_storehouse_basis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-5-27
-- Description:	门店同比日均销量
-- =============================================
create PROCEDURE [dbo].[sp_Products_sales_storehouse_basis]
	@inyProductID int,    --产品编号
	@inyStoresID int,     --门店编号
	@bDate datetime,      --开始日期
	@eDate datetime,      --结束日期
	@inytType int         --查询类型
AS
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期
	set @bDate=convert(datetime,convert(varchar,DATEPART(YEAR,@bDate)-1)+'-'+convert(varchar,DATEPART(MONTH,@bDate))+'-'+convert(varchar,DATEPART(DAY,@bDate))+' 00:00:00')
BEGIN
	--统计类型：时间段选择
	if @inytType=0
	begin
		  --转换日期
		  set @eDate=convert(datetime,convert(varchar,DATEPART(YEAR,@eDate)-1)+'-'+convert(varchar,DATEPART(MONTH,@eDate))+'-'+convert(varchar,DATEPART(DAY,@eDate))+' 23:59:59')
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@bDate,@eDate)+1
		  

		  select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID and oi.StoresID=@inyStoresID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and okl.pAppendTime between @bDate and @eDate) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where sDateTime between @bDate and @eDate
			and ProductsID=@inyProductID and StoresID=@inyStoresID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID  where oQuantity !=0 or sNum !=0
			group by si.sName,si.StoresID
	end
	
	--统计类型：年统计
	if @inytType=1
	begin
		  --转换日期
		  set @Date=DATEADD(yy, DATEDIFF(yy,0,@bDate), 0)                   --某年的第一天
		  set @eDate=DATEADD(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@bDate)+1, 0)) --某年的最后一天
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1

		 select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID and oi.StoresID=@inyStoresID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and datediff(YEAR,okl.pAppendTime,@bDate)=0) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where datediff(YEAR,sDateTime,@bDate)=0
			and ProductsID=@inyProductID and StoresID=@inyStoresID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID  where oQuantity !=0 or sNum !=0
	        group by si.sName,si.StoresID
	end
	
	--统计类型：月统计
	if @inytType=2
	begin
		  --转换日期
		  set @Date= DATEADD(mm, DATEDIFF(mm,0,@bDate), 0)                    --某月的第一天
		  set @eDate=DATEADD(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate)+1, 0))   --某月的最后一天
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1

		  
	      select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID and oi.StoresID=@inyStoresID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and datediff(MONTH,okl.pAppendTime,@bDate)=0) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where datediff(MONTH,sDateTime,@bDate)=0
			and ProductsID=@inyProductID and StoresID=@inyStoresID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID  where oQuantity !=0 or sNum !=0
	        group by si.sName,si.StoresID
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_sales_storehouse_annulus]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		angol
-- Create date: 2011-5-27
-- Description:	门店环比日均销量
-- =============================================
create PROCEDURE [dbo].[sp_Products_sales_storehouse_annulus] 
	@inyProductID int,    --产品编号
	@inyStoresID int,     --门店编号
	@bDate datetime,      --开始日期
	@eDate datetime,      --结束日期
	@inytType int         --查询类型
AS
BEGIN
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期   
	
	--统计类型：月统计
	if @inytType=2
	begin
	  --转换日期
	  set @Date=DATEADD(mm, DATEDIFF(mm ,0,@bDate)-1, 0)                    --上月的第一天
	  set @eDate=dateadd(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate), 0))       --上月的最后一天
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
       select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and oi.StoresID=@inyStoresID and datediff(MONTH,okl.pAppendTime,@Date)=0) 
	   and oWorkType=2 and ProductsID=@inyProductID  group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where ProductsID=@inyProductID and StoresID=@inyStoresID  and  datediff(MONTH,sDateTime,@Date)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_sales_storehouse]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-5-25
-- Description:	产品日均销量门店详情
-- =============================================
CREATE PROCEDURE [dbo].[sp_Products_sales_storehouse]
	@inyProductID int,    --产品编号
	@bDate datetime,      --开始日期
	@eDate datetime,      --结束日期
	@inytType int         --查询类型
AS
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期
BEGIN
	--统计类型：时间段选择
	if @inytType=0
	begin
		  --转换日期
		  set @bDate=convert(datetime,convert(varchar,DATEPART(YEAR,@bDate))+'-'+convert(varchar,DATEPART(MONTH,@bDate))+'-'+convert(varchar,DATEPART(DAY,@bDate))+' 00:00:00')
		  set @eDate=convert(datetime,convert(varchar,DATEPART(YEAR,@eDate))+'-'+convert(varchar,DATEPART(MONTH,@eDate))+'-'+convert(varchar,DATEPART(DAY,@eDate))+' 23:59:59')
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@bDate,@eDate)+1
		  
		  select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and okl.pAppendTime between @bDate and @eDate) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where sDateTime between @bDate and @eDate
			and ProductsID=@inyProductID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID  
			where si.sState=0 group by si.sName,si.StoresID
	end
	
	--统计类型：年统计
	if @inytType=1
	begin
		  --转换日期
		  set @Date=DATEADD(yy, DATEDIFF(yy,0,@bDate), 0)                   --某年的第一天
		  set @eDate=DATEADD(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@bDate)+1, 0)) --某年的最后一天
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
		  
		 select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and datediff(YEAR,okl.pAppendTime,@bDate)=0) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where datediff(YEAR,sDateTime,@bDate)=0
			and ProductsID=@inyProductID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID 
	        where si.sState=0  group by si.sName,si.StoresID
	end
	
	--统计类型：月统计
	if @inytType=2
	begin
		  --转换日期
		  set @Date= DATEADD(mm, DATEDIFF(mm,0,@bDate), 0)                    --某月的第一天
		  set @eDate=DATEADD(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate)+1, 0))   --某月的最后一天
		  --统计天数
		  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
	      select si.sName,si.StoresID,isnull(sum(pp.oQuantity/@intDay),0) as oQuantity,isnull(sum(convert(numeric,qq.sNum))/@intDay,0) as sNum from tbStoresInfo as si left join
			( select StoresID,oQuantity from (select oi.StoresID,oli.OrderID,oli.oQuantity as oQuantity from tbOrderInfo as oi 
			left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.ProductsID=@inyProductID) as q 
			left join tbOrderWorkingLogInfo as okl on q.OrderID=okl.OrderID 
			where okl.oType=5 and datediff(MONTH,okl.pAppendTime,@bDate)=0) as pp on pp.StoresID=si.StoresID left join

			(select StoresID,sum(sNum) as sNum from tbSalesInfo where datediff(MONTH,sDateTime,@bDate)=0
			and ProductsID=@inyProductID group by StoresID,ProductsID ) as qq on qq.StoresID=si.StoresID 
	        where si.sState=0  group by si.sName,si.StoresID
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_Sale_Details_year_basis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		angol
-- Create date: 2011-5-26
-- Description:	日均同比数据统计
-- =============================================
create PROCEDURE [dbo].[sp_Products_Sale_Details_year_basis]
    @inytType int,         --统计类型：0=时间段选择；1=年统计；2=月统计
    @intProductsID int,    --产品编号
	@bDate datetime,       --开始日期
	@eDate datetime        --结束日期
AS
BEGIN
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期   
    set @bDate=convert(datetime,convert(varchar,DATEPART(YEAR,@bDate)-1)+'-'+convert(varchar,DATEPART(MONTH,@bDate))+'-'+convert(varchar,DATEPART(DAY,@bDate))+' 00:00:00')
	--统计类型：时间段选择
	if @inytType=0
	begin
	  --转换日期
	  set @eDate=convert(datetime,convert(varchar,DATEPART(YEAR,@eDate)-1)+'-'+convert(varchar,DATEPART(MONTH,@eDate))+'-'+convert(varchar,DATEPART(DAY,@eDate))+' 23:59:59')
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@bDate,@eDate)+1
	  
	 select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and okl.pAppendTime between @bDate and @eDate) 
	  and oWorkType=2 and ProductsID=@intProductsID group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where ProductsID=@intProductsID and sDateTime between @bDate and @eDate group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0  order by oQuantity desc
	end
	
	--统计类型：年统计
	if @inytType=1
	begin
	  --转换日期
	  set @Date=DATEADD(yy, DATEDIFF(yy,0,@bDate), 0)                   --某年的第一天
	  set @eDate=DATEADD(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@bDate)+1, 0)) --某年的最后一天
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
 
      select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and datediff(YEAR,okl.pAppendTime,@bDate)=0) 
	  and oWorkType=2 and ProductsID=@intProductsID group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where ProductsID=@intProductsID and  datediff(YEAR,sDateTime,@bDate)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
	
	--统计类型：月统计
	if @inytType=2
	begin
	  --转换日期
	  set @Date= DATEADD(mm, DATEDIFF(mm,0,@bDate), 0)                    --某月的第一天
	  set @eDate=DATEADD(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate)+1, 0))   --某月的最后一天
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
	  
       select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and datediff(MONTH,okl.pAppendTime,@bDate)=0) 
	  and oWorkType=2 and ProductsID=@intProductsID group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where ProductsID=@intProductsID and  datediff(MONTH,sDateTime,@bDate)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_Sale_Details_year_annulus]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		angol
-- Create date: 2011-5-26
-- Description:	获得产品[环比]日均销量
-- =============================================
create PROCEDURE [dbo].[sp_Products_Sale_Details_year_annulus]
    @inytType int,         --统计类型：0=时间段选择；1=年统计；2=月统计
    @intProductsID int,    --产品编号
	@bDate datetime,       --开始日期
	@eDate datetime        --结束日期
AS
BEGIN
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期   
	
	--统计类型：月统计
	if @inytType=2
	begin
	  --转换日期
	  set @Date=DATEADD(mm, DATEDIFF(mm ,0,@bDate)-1, 0)                    --上月的第一天
	  set @eDate=dateadd(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate), 0))       --上月的最后一天
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
	  
       select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and datediff(MONTH,okl.pAppendTime,@Date)=0) 
	  and oWorkType=2 and ProductsID=@intProductsID group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where ProductsID=@intProductsID and  datediff(MONTH,sDateTime,@Date)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_Sale_Details]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-5-25
-- Description:	产品日均销量统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_Products_Sale_Details] 
	@inytType int,         --统计类型：0=时间段选择；1=年统计；2=月统计
	@bDate datetime,       --开始日期
	@eDate datetime        --结束日期
AS
BEGIN
    declare @intDay int;     --记录天数
	declare @Date datetime;  --暂存日期   
	
	--统计类型：时间段选择
	if @inytType=0
	begin
	  --转换日期
	  set @bDate=convert(datetime,convert(varchar,DATEPART(YEAR,@bDate))+'-'+convert(varchar,DATEPART(MONTH,@bDate))+'-'+convert(varchar,DATEPART(DAY,@bDate))+' 00:00:00')
	  set @eDate=convert(datetime,convert(varchar,DATEPART(YEAR,@eDate))+'-'+convert(varchar,DATEPART(MONTH,@eDate))+'-'+convert(varchar,DATEPART(DAY,@eDate))+' 23:59:59')
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@bDate,@eDate)+1
	  
	 select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and okl.pAppendTime between @bDate and @eDate) 
	  and oWorkType=2 group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where sDateTime between @bDate and @eDate group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0  order by oQuantity desc
	end
	
	--统计类型：年统计
	if @inytType=1
	begin
	  --转换日期
	  set @Date=DATEADD(yy, DATEDIFF(yy,0,@bDate), 0)
	  set @eDate=DATEADD(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@bDate)+1, 0))
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1
      
      select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and datediff(YEAR,okl.pAppendTime,@bDate)=0) 
	  and oWorkType=2 group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where  datediff(YEAR,sDateTime,@bDate)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
	
	--统计类型：月统计
	if @inytType=2
	begin
	  --转换日期
	  set @Date= DATEADD(mm, DATEDIFF(mm,0,@bDate), 0)                    --某月的第一天
	  set @eDate=DATEADD(ms,-3,DATEADD(mm, DATEDIFF(mm,0,@bDate)+1, 0))   --某月的最后一天
	  --统计天数
	  set @intDay=DATEDIFF(DAY,@Date,@eDate)+1

       select p.ProductsID,pName,pBarcode,isnull(pp.oQuantity/@intDay,0) as oQuantity,isnull(convert(numeric,si.sNum)/@intDay,0) as sNum from tbProductsInfo as p left join
	  (select ProductsID,isnull(sum(oQuantity),0) as oQuantity from tbOrderListInfo where OrderID in(select oi.OrderID from tbOrderInfo as oi left join tbOrderWorkingLogInfo  as okl on oi.OrderID=okl.OrderID
	  where oi.oType=3 and oi.oState=0 and okl.oType=5 and oi.oSteps>=4 and datediff(MONTH,okl.pAppendTime,@bDate)=0) 
	  and oWorkType=2 group by ProductsID) as pp on pp.ProductsID=p.ProductsID left join 
	  (select ProductsID,isnull(sum(sNum),0) as sNum from tbSalesInfo where  datediff(MONTH,sDateTime,@bDate)=0 group by ProductsID ) as si
	  on si.ProductsID =p.ProductsID  where oQuantity!=0 or sNum !=0 order by oQuantity desc

	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_Graph_Details]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		angol
-- Create date: 2011-10-24
-- Description:	销量图表
-- =============================================
CREATE PROCEDURE [dbo].[sp_Products_Graph_Details]
	@inyGraphType int,			--统计类型：0=月销量；1=年销量
	@inySalesType int,			--销售类型：0=购销；1=联营
	@dtmDateTime datetime,		--日期
	@inyRegionID varchar(512),	--地区编号
	@inyStype int				--查询类型：0=地区；1=客户；2=商品
AS
	
	if(@inyGraphType=0)
	begin
		set @dtmDateTime=DATEADD(DAY,-DATEPART(day,@dtmDateTime)+1,@dtmDateTime)--获得每月的第一天
	end
	if(@inyGraphType=1)
	begin
		set @dtmDateTime=DATEADD(yy,DATEDIFF(yy,0,@dtmDateTime),0)  --获得每年的第一天
	end
	--==================================创建临时表==================================
	--存储每天或每月数据
	declare @tbProductsGraphDetails table(
								searchTime datetime,
								dataDetails varchar(128),
								moneyDetails varchar(128)
										)
	--存储总数
	declare @tbProductsSalesMonthDetails table(
								searchTime datetime,
								dataDetails varchar(128),
								moneyDetails varchar(128)
								)
	--存储传值进来的regionID	
	--删除原数据
	If object_id('tempdb..#tbRegionData_tmp') is  not null
	Drop table #tbRegionData_tmp								
	Create table #tbRegionData_tmp (regionData int)
	
	while CHARINDEX(',',@inyRegionID)>0
	begin
		insert   #tbRegionData_tmp select   cast(left(@inyRegionID,charindex( ',',@inyRegionID)-1)   as   int)
		select   @inyRegionID= stuff(@inyRegionID,1,charindex( ',',@inyRegionID), '') 
	end
	if   len(@inyRegionID)> 0 
	insert   #tbRegionData_tmp   select   cast(@inyRegionID   as   int) 
	--==================================创建临时字段================================
	declare @inyCount int;	--循环用
	set @inyCount=0;
	
	declare @inyDayCount int;	--每月的天数
	
	declare @dtmLastDayOfMonth datetime;	--每月的最后一天
	set @dtmLastDayOfMonth=dateadd(month,1,@dtmDateTime)-day(dateadd(month,1,@dtmDateTime));
	set @inyDayCount=DATEDIFF(DAY,@dtmDateTime,@dtmLastDayOfMonth)+1;


    
    

BEGIN
	
	--[1.购销统计]
	if(@inySalesType=0 and @inyStype=0)
	begin
		--1.1 按照月销量
		if(@inyGraphType=0)
		BEGIN
			--获得每月的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
			--没有区域
			if(@inyRegionID ='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oli.oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
						 
						 
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
			end
			--选择了区域
			if(@inyRegionID !='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oli.oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
					
						 
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
								--区域
								and oi.StoresID in(select StoresID from tbStoresInfo where RegionID in (select regionData from #tbRegionData_tmp))
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
				
			end
		END
		--1.2 按照年销量
		if(@inyGraphType=1)
		BEGIN
			--获得每年的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(YEAR,pAppendTime,@dtmDateTime)=0)
			--没有区域
			if(@inyRegionID='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
						
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
			--选择了区域
			if(@inyRegionID!='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
					
						
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
									--区域
									and oi.StoresID in(select StoresID from tbStoresInfo where RegionID in(select regionData from #tbRegionData_tmp))
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
		END
	end
	
	if(@inySalesType=0 and @inyStype=1)
	begin
		--1.1 按照月销量
		if(@inyGraphType=0)
		BEGIN
			--获得每月的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
			--没有客户
			if(@inyRegionID ='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oli.oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
						
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
			end
			--选择了客户
			if(@inyRegionID !='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oli.oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
				
						 
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
								--客户
								and oi.StoresID  in (select regionData from #tbRegionData_tmp)
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
				
			end
		END
		--1.2 按照年销量
		if(@inyGraphType=1)
		BEGIN
			--获得每年的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(YEAR,pAppendTime,@dtmDateTime)=0)
			--没有客户
			if(@inyRegionID='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
				
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
			--选择了客户
			if(@inyRegionID!='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oMoney),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						(isnull(sum(oMoney),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
			
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
									--客户
									and oi.StoresID in(select regionData from #tbRegionData_tmp)
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
		END
	end
	
	if(@inySalesType=0 and @inyStype=2)
	begin
		--1.1 按照月销量
		if(@inyGraphType=0)
		BEGIN
			--获得每月的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
			--没有商品
			if(@inyRegionID ='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oQuantity),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						--case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						isnull(sum(oli.oMoney),0)--/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
						
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
			end
			--选择了商品
			if(@inyRegionID !='')
			begin
				--循环一个月，取得每一天的数据
				while @inyCount<@inyDayCount
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oQuantity),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						--(isnull(sum(oli.oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						--case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						isnull(sum(oli.oMoney),0)--/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oMoney),0) end as oMoney
				
						 
						 from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(DAY,pAppendTime,@dtmDateTime)=0)
								--商品
								and oli.ProductsID  in (select ProductsID from tbProductsInfo where ProductsID in (select regionData from #tbRegionData_tmp) )
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=@dtmDateTime+1;
				end
				
			end
		END
		--1.2 按照年销量
		if(@inyGraphType=1)
		BEGIN
			--获得每年的销售总量
			insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
			select @dtmDateTime,isnull(sum(oQuantity),0),isnull(sum(oMoney),0) from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(YEAR,pAppendTime,@dtmDateTime)=0)
			--没有商品
			if(@inyRegionID='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oQuantity),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						--case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						isnull(sum(oMoney),0)--/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
				
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
			--选择了商品
			if(@inyRegionID!='')
			begin
				--循环一年，取得每一个月的数据
				while @inyCount<12
				begin
					insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
						select @dtmDateTime,isnull(sum(oli.oQuantity),0),
						--case when (select dataDetails from @tbProductsSalesMonthDetails) !='0.000000' then 
						--(isnull(sum(oQuantity),0)/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(oQuantity),0) end as oQuantity,
						--case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.000000' then
						isnull(sum(oMoney),0)--/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(oMoney),0) end as oMoney
			
						from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
							where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oli.OrderID in (select OrderID from 
								tbOrderWorkingLogInfo where oType=5 and DATEDIFF(MONTH,pAppendTime,@dtmDateTime)=0)
									--商品
									and oli.ProductsID  in (select ProductsID from tbProductsInfo where ProductsID in (select regionData from #tbRegionData_tmp) )
								
						set @inyCount=@inyCount+1;
						set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
				end
			end
		END
	end
	
	----[2.联营统计]
	--if(@inySalesType=1)
	--begin
	--	--1.1 按照月销量
	--	if(@inyGraphType=0)
	--	BEGIN
	--		--获得每月的销售总量
	--		insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
	--		select @dtmDateTime,convert(numeric(6,0),isnull(sum(sNum),0)),isnull(sum(sPrice),0) from tbSalesInfo 
	--		   where DATEDIFF(MONTH,sAppendTime,@dtmDateTime)=0 
			
			
	--		--select dataDetails from @tbProductsSalesMonthDetails
	--		--循环一个月，取得每一天的数据
	--		while @inyCount<@inyDayCount
	--		begin
	--			insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
	--			select @dtmDateTime,
	--			case when (select dataDetails from @tbProductsSalesMonthDetails) !='0' then
	--			(convert(numeric(6,0),isnull(sum(sNum),0))/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(sNum),0) end as sNum,
	--			case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.00' then
	--			(isnull(sum(sPrice),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100  else isnull(sum(sPrice),0) end as sPrice
				  
	--			  from tbSalesInfo 
	--				 where DATEDIFF(day,sAppendTime,@dtmDateTime)=0 
				
	--			set @inyCount=@inyCount+1;
	--			set @dtmDateTime=@dtmDateTime+1;
	--		end
	--	END
	--	--1.2 按照年销量
	--	if(@inyGraphType=1)
	--	BEGIN
	--		--获得年的销售总量
	--		insert into @tbProductsSalesMonthDetails(searchTime,dataDetails,moneyDetails)
	--		select @dtmDateTime,convert(numeric(6,0),isnull(sum(sNum),0)),isnull(sum(sPrice),0) from tbSalesInfo 
	--		   where DATEDIFF(YEAR,sAppendTime,@dtmDateTime)=0 
			
	--		--循环一年，取得每一个月的数据
	--		while @inyCount<12
	--		begin
	--			insert into @tbProductsGraphDetails(searchTime,dataDetails,moneyDetails)
	--			select @dtmDateTime,
	--			case when (select dataDetails from @tbProductsSalesMonthDetails) !='0' then
	--			(convert(numeric(6,0),isnull(sum(sNum),0))/(select dataDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(sNum),0) end as sNum,
	--			case when (select moneyDetails from @tbProductsSalesMonthDetails) !='0.00' then 
	--			(isnull(sum(sPrice),0)/(select moneyDetails from @tbProductsSalesMonthDetails))*100 else isnull(sum(sPrice),0) end as sPrice
				  
	--			  from tbSalesInfo 
	--				 where DATEDIFF(MONTH,sAppendTime,@dtmDateTime)=0 
				
	--			set @inyCount=@inyCount+1;
	--			set @dtmDateTime=dateadd(MONTH,1,@dtmDateTime);
	--		end
	--	END
	--end
	
	--取出数据:百分比--dataDetails销售总量；moneyDetails销售百分比
	select searchTime,dataDetails,moneyDetails from @tbProductsGraphDetails
	DROP TABLE #tbRegionData_tmp;
END
GO
/****** Object:  StoredProcedure [dbo].[tbgetlastexecutescheduledeventdatetime]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tbgetlastexecutescheduledeventdatetime]
(
	@key VARCHAR(100),
	@servername VARCHAR(100),
	@lastexecuted DATETIME OUTPUT
)
AS
SELECT @lastexecuted = MAX([lastexecuted]) FROM [tbscheduledevents] WHERE [key] = @key AND [servername] = @servername

IF(@lastexecuted IS NULL)
BEGIN
	SET @lastexecuted = DATEADD(YEAR,-1,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getCompanySales_Details]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YANGANGOL
-- Create date: 2011-7-18
-- Description:	公司销售
-- =============================================
CREATE PROCEDURE [dbo].[sp_getCompanySales_Details]
     @dtmbDate datetime,  
	 @inyType int		--人员类型
AS
     declare @StoresID int ;
     declare @sType int;
		 --人员列表
		declare @Staff Table(
			StaffID int,			--人员编号
			DepartmentsClassID int,	--部门编号
			StoresID int,			--客户/门店编号
			sName varchar(50),		--姓名
			sType int,				--类型
			bDate datetime,			--上岗时间
			eDate datetime			--离岗时间
		);
BEGIN
    ----创建新临时表1:保存销售数据
    If object_id('tempdb..#CompanySales_tmp') is  not null
	Drop table #CompanySales_tmp
	Create table #CompanySales_tmp(
	                            storesID int,
	                            quantity decimal,
	                            omoney money,
	                            appendtime datetime
	                            )
	 insert into  #CompanySales_tmp(storesID,quantity,omoney,appendtime)
	  --单据
	  select rm.StoresID,rm.oQuantity,rm.oMoney,owl.pAppendTime from (
	  select oi.StoresID,oi.OrderID,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oMoney,0) as oMoney from tbOrderInfo as oi 
	  left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2
	   ) as rm left join tbOrderWorkingLogInfo as owl on owl.OrderID=rm.OrderID  
	  where datediff(DAY,owl.pAppendTime,@dtmbDate)=0 and owl.oType=5 order by rm.StoresID asc
	 
	 --业务员
	 if(@inyType=3)
	 begin
	   set @sType=1;
	 end
	 --促销员
	 if(@inyType=4)
	 begin
	   set @sType=2;
	 end
	 
	 --人员上岗、离岗记录
		insert into @Staff(StaffID,DepartmentsClassID,sName,sType,bDate,eDate,StoresID)
				select s.StaffID, s.DepartmentsClassID,s.sName,s.sType,ss.bdate,ss.edate,ss.StoresID from 
				(select StaffID,StoresID,MIN(bdate) bdate,MAX(edate) edate from tbSales_Staff_StoresDataInfo group by StaffID,StoresID)  ss 
					left join tbStaffInfo s on ss.StaffID=s.StaffID
					where (@dtmbDate between ss.bdate and ss.edate) and s.sType=@sType;	
	
	 --业务员  
     if(@inyType=3)
     begin
          select si.StaffID,si.sName,isnull(pp.quantity,0) as quantity,isnull(pp.omoney,0) as omoney from (
		  select sss.StaffID,isnull(sum(cp.quantity),0) as quantity,isnull(sum(cp.omoney),0) as omoney from #CompanySales_tmp as cp
		  left join @Staff as sss on sss.StoresID=cp.storesID
		 group by sss.StaffID) as pp right join tbStaffInfo as si on pp.StaffID=si.StaffID where si.sState=0 and si.sType=1
     end
	--促销员
     if(@inyType=4)
     begin
          select si.StaffID,si.sName,isnull(pp.quantity,0) as quantity,isnull(pp.omoney,0) as omoney from (
		  select sss.StaffID,isnull(sum(cp.quantity),0) as quantity,isnull(sum(cp.omoney),0) as omoney from #CompanySales_tmp as cp
		  left join @Staff as sss on sss.StoresID=cp.storesID
		 group by sss.StaffID) as pp right join tbStaffInfo as si on pp.StaffID=si.StaffID where si.sState=0 and si.sType=2
     end
     --客户
     if(@inyType=0)
     begin
         select si.StoresID,si.sName,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from (
       select oi.StoresID,isnull(sum(oli.oQuantity),0) as oQuantity,isnull(sum(oli.oMoney),0) as oMoney from tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
       where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oi.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and 
        DATEDIFF(day,pAppendTime,@dtmbDate)=0) group by oi.StoresID) as qq right join tbStoresInfo as si on qq.StoresID=si.StoresID   where si.sState=0  order by si.StoresID asc

     end
     
     --商品
     if(@inyType=1)
     begin
         select p.ProductsID,p.pName,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from(
        select oli.ProductsID,isnull(sum(oli.oQuantity),0) as oQuantity,isnull(sum(oli.oMoney),0) as oMoney from tbOrderInfo as oi
        left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oi.OrderID
        in (select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmbDate)=0) group by oli.ProductsID)
        as qq right join tbProductsInfo as p  on p.ProductsID=qq.ProductsID where p.pState=0 order by p.ProductsID asc
     end
     --品牌
     if(@inyType=2)
     begin
         select p.pBrand,isnull(sum(qq.oQuantity),0) as oQuantity,isnull(sum(qq.oMoney),0) as oMoney from(
       select oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oMoney,0) as oMoney from tbOrderInfo as oi
       left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 and oi.OrderID
       in (select OrderID from tbOrderWorkingLogInfo where oType=5 and DATEDIFF(day,pAppendTime,@dtmbDate)=0))
       as qq right join tbProductsInfo as p  on p.ProductsID=qq.ProductsID where p.pState=0 group by p.pBrand order by p.pBrand asc
     end
     Drop table #CompanySales_tmp
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Fees_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Fees_analysis]
	/*
	费用分析
	*/
	@bDate datetime,			--开始时间
	@eDate datetime,			--结束时间
	@mType int=1				--费用类型,销售费用=0,公司管理费用=1
AS
begin

	if @mType=1
	begin
		select f.fName,(select isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where mIsIncomeExpenditure=0 and FeesSubjectID=f.FeesSubjectID and mDateTime>=@bDate and mDateTime<=@eDate) mFees,f.FeesSubjectID
			from tbFeesSubjectInfo f order by mFees desc;
	end

	if @mType=0
	begin
		select s.sName,(select isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where StoresID=s.StoresID and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate) mFees,s.StoresID
			from tbStoresInfo s order by mFees desc;
	end
	
	if @mType=-1
	begin
		select f.fName,(select isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where mIsIncomeExpenditure=1 and FeesSubjectID=f.FeesSubjectID and mDateTime>=@bDate and mDateTime<=@eDate) mFees
			from tbFeesSubjectInfo f order by mFees desc;
	end
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductCostValence]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetProductCostValence]
	/*
	返回产品变价后，产品成本列表
	*/
	@ProductID int = 0,		--产品编号
	@pDate	   datetime	= null	--发生时间
AS
begin
	
	declare @i int,@tCostVelenceID int,@tProductsID int ,@tcPrice money,@tcPriceB money ,@tbDate datetime,@teDate datetime,@tcDateTime datetime,@tcDateTimeB datetime;
	set @i = 0;
	
	--清理原数据
	delete tbProductCostPriceInfo where DATEDIFF(YEAR,GETDATE(),bdate)>-2;--保留两年前的默认价格数据,以下开始重建一年前到一年后的数据
	
	--删除原数据
	If object_id('tempdb..#ErpProductCostPrice_tmp') is  not null
	Drop table #ErpProductCostPrice_tmp
	--创建新临时表
	Create table #ErpProductCostPrice_tmp (CostVelenceID int,ProductsID int,		--产品编号
						cPrice money,			--成本
						bdate datetime,			--开始时间
						edate datetime			--结束时间
					)
	
	declare ocur cursor for select CostVelenceID,ProductsID,cPrice,cDateTime from tbCostValenceInfo order by CostVelenceID DESC;
	open ocur			
		FETCH NEXT FROM ocur INTO @tCostVelenceID,@tProductsID,@tcPrice,@tcDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			set @i = @i+1;
			
			--创建第一条
			if not exists(select * from #ErpProductCostPrice_tmp where ProductsID=@tProductsID)
			begin
				select @tcPriceB=pPrice from tbProductsInfo where ProductsID=@tProductsID;
				
				insert into #ErpProductCostPrice_tmp(CostVelenceID,ProductsID,cPrice,bdate,edate) 
						values(@i,@tProductsID,@tcPriceB,DATEADD(dd,-365,getdate()),@tcDateTime);
				set @i = @i+1;		
			end
			
			--当前记录之后一条			
			if exists( select top 1 cDateTime from tbCostValenceInfo where ProductsID=@tProductsID and CostVelenceID in(select top 1 CostVelenceID from tbCostValenceInfo where ProductsID=@tProductsID and CostVelenceID>@tCostVelenceID) )
			begin
				select top 1 @tcDateTimeB=cDateTime from tbCostValenceInfo where ProductsID=@tProductsID and CostVelenceID in(select top 1 CostVelenceID from tbCostValenceInfo where ProductsID=@tProductsID and CostVelenceID>@tCostVelenceID)
			
				insert into #ErpProductCostPrice_tmp(CostVelenceID,ProductsID,cPrice,bdate,edate) 
						values(@i,@tProductsID,@tcPrice,@tcDateTime,@tcDateTimeB);
				
			end
			else
			begin
				
				insert into #ErpProductCostPrice_tmp(CostVelenceID,ProductsID,cPrice,bdate,edate) 
						values(@i,@tProductsID,@tcPrice,@tcDateTime,DATEADD(dd,365,getdate()));
			end
		
		FETCH NEXT FROM ocur INTO @tCostVelenceID,@tProductsID,@tcPrice,@tcDateTime;
		end
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标
	
	--补充其他产品信息
	declare ocur cursor for select ProductsID,pPrice from tbProductsInfo order by ProductsID DESC;
	open ocur
		FETCH NEXT FROM ocur INTO @tProductsID,@tcPrice
		WHILE @@FETCH_STATUS = 0
		begin
			
			if not exists(select * from #ErpProductCostPrice_tmp where ProductsID=@tProductsID)
			begin
				set @i = @i+1;
				insert into #ErpProductCostPrice_tmp(CostVelenceID,ProductsID,cPrice,bdate,edate) 
						values(@i,@tProductsID,@tcPrice,DATEADD(dd,-365,getdate()),DATEADD(dd,365,getdate()));
						
			end
			
			FETCH NEXT FROM ocur INTO @tProductsID,@tcPrice
		end
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标
	
	insert into tbProductCostPriceInfo(CostVelenceID,ProductsID,cPrice,bdate,edate)
		select CostVelenceID,ProductsID,cPrice,bdate,edate from #ErpProductCostPrice_tmp;
	
	if @ProductID>0
	begin
		select @tcPrice=cPrice from #ErpProductCostPrice_tmp where ProductsID=@ProductID and bdate<=@pDate and edate>=@pDate;
		return @tcPrice;
	end
	else
	begin
		select * from #ErpProductCostPrice_tmp order by ProductsID desc;
	end
	
	Drop table #ErpProductCostPrice_tmp;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DayStorage]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DayStorage]
	(
	@dT datetime 
	)
AS
begin

declare @ProductsID int;
declare @StorageID int;
declare @Quantity Decimal;
declare @QuantityIn Decimal;
declare @QuantityOut Decimal;
declare @QuantityIn_t Decimal;
declare @QuantityOut_t Decimal;

declare @ProductsStorageID int;

set @Quantity=0;
set @QuantityIn=0;
set @QuantityOut=0;
set @QuantityIn_t=0;
set @QuantityOut_t=0;
set @ProductsStorageID = 0;

if @dT is null
begin
	set @dT = getdate();
end

--商品表
declare ocur cursor for select ProductsID from tbProductsInfo where pState<>1
open ocur
FETCH NEXT FROM ocur INTO @ProductsID
WHILE @@FETCH_STATUS = 0
	begin
			--仓库表
			declare ocur2 cursor for select StorageID from tbStorageInfo where sState=0
			open ocur2
			FETCH NEXT FROM ocur2 INTO @StorageID
			WHILE @@FETCH_STATUS = 0
				begin

				select @Quantity=vStorage.Quantity,
						@QuantityIn=vStorageIn.Quantity,
						@QuantityOut=vStorageOut.Quantity
				 from (select  isnull(sum(ps.pQuantity),0) as Quantity  from tbProductsStorageLogInfo as ps  where ps.StorageID=@StorageID and ps.ProductsID=@ProductsID and  ps.pAppendTime<=@dT and ps.pType<>-1) as vStorage,
				 (--入库
					select isnull(sum(ol.oQuantity),0) as Quantity from tbOrderListInfo as ol where oWorkType=1  
						and ol.OrderID in(select oll.OrderID from tbOrderInfo as oll where oll.oState=0 and oll.oType in(1,4,8)  and oll.oSteps>=4)
						and ol.StorageID=@StorageID and ol.ProductsID=@ProductsID and ol.oAppendTime<=@dT
				 ) as vStorageIn,--ol.oAppendTime<=@dT
				 (--出库
					select isnull(sum(ool.oQuantity),0) as Quantity from tbOrderListInfo as ool where oWorkType=1 
						and ool.OrderID in(select ooll.OrderID from tbOrderInfo as ooll where ooll.oState=0 and ooll.oType in(2,3,5,6,7,10,11)) 
						and ool.StorageID=@StorageID and ool.ProductsID=@ProductsID and ool.oAppendTime<=@dT
				 ) as vStorageOut ;--ool.oAppendTime<=@dT
				
				
				 --调拨单特殊处理
					--入库，正数
					select @QuantityIn_t = isnull(sum(ol.oQuantity),0) from tbOrderListInfo as ol where oWorkType=1  
						and ol.OrderID in(select oll.OrderID from tbOrderInfo as oll where oll.oState=0 and oll.oType=9  and oll.oSteps>=4)
						and ol.StorageID=@StorageID and ol.ProductsID=@ProductsID and ol.oAppendTime<=@dT and ol.oQuantity>0;
						set @QuantityIn = @QuantityIn + @QuantityIn_t;
						
					--出库，负数
					select @QuantityOut_t = isnull(sum(ool.oQuantity),0)*-1 from tbOrderListInfo as ool where oWorkType=1 
						and ool.OrderID in(select ooll.OrderID from tbOrderInfo as ooll where ooll.oState=0 and ooll.oType = 9) 
						and ool.StorageID=@StorageID and ool.ProductsID=@ProductsID and ool.oAppendTime<=@dT and ool.oQuantity<0;
						set @QuantityOut = @QuantityOut + @QuantityOut_t;
				
				 --当日是否已经记录
				 
				 
				 if exists(select ProductsStorageID from tbProductsStorageInfo where StorageID=@StorageID and ProductsID=@ProductsID and datediff(day,pUpdateTime,@dT)=0)
				 begin
					select top 1 @ProductsStorageID=ProductsStorageID from tbProductsStorageInfo where StorageID=@StorageID and ProductsID=@ProductsID and datediff(day,pUpdateTime,@dT)=0;
					update tbProductsStorageInfo set pStorage=@Quantity,pStorageIn=@QuantityIn,pStorageOut=@QuantityOut,pUpdateTime=@dT where ProductsStorageID=@ProductsStorageID and StorageID=@StorageID;
					
				 end
				 else
				 begin
					insert into tbProductsStorageInfo(StorageID,ProductsID,pStorage,pStorageIn,pStorageOut,pUpdateTime)
						values (@StorageID,@ProductsID,@Quantity,@QuantityIn,@QuantityOut,@dT);
						
				 end	 

				 FETCH NEXT FROM ocur2 INTO @StorageID
			end

			CLOSE ocur2--关闭游标
			DEALLOCATE ocur2--释放游标


		FETCH NEXT FROM ocur INTO @ProductsID
	end

CLOSE ocur--关闭游标
DEALLOCATE ocur--释放游标


end
GO
/****** Object:  StoredProcedure [dbo].[sp_Buy_Sales_Detals]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	angol
-- Create date: 2011-5-9
-- Description:	购销明细  客户为默认加载数据=-1；客户=0；品牌=1；单品=2；区域=3；业务员=4
-- =============================================
CREATE PROCEDURE [dbo].[sp_Buy_Sales_Detals]
     @inyBuySales int,       --购销类别
     @dtmbDate  datetime,    --开始日期
     @dtmeDate  datetime     --结束日期
AS
BEGIN
   
	 --购销类别为：客户
	 if(@inyBuySales=0)
	  begin
	    select si.sName,si.sType,isnull(sInfo.oQuantity,0) as oQuantity,isnull(sInfo.oMoney,0) as oMoney from (	
		select oi.StoresID,
		       sum(oli.oQuantity) as oQuantity,
		       sum(oli.oMoney) as  oMoney
		from tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 
		and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		group by oi.StoresID)as sInfo 
		left join tbStoresInfo as si on sInfo.StoresID=si.StoresID  
		where si.sState=0 order by sInfo.oMoney desc
	  end
	  --购销类别为：品牌
	  if(@inyBuySales=1)
	  begin
	   
		select p.pBrand,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(pInfo.oMoney),0) as oMoney  from
		(
		select oli.ProductsID,
		       oli.oQuantity,
		       oli.oMoney 
	    from tbOrderInfo as oi left join tbOrderListInfo as oli
		on oi.OrderID=oli.OrderID 
		where oi.oState=0 and oi.oType=3 and oli.oWorkType=2
		and oli.OrderID in (select okl.OrderID from tbOrderWorkingLogInfo as okl where okl.oType=5 and okl.pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		) as pInfo  left join tbProductsInfo  as p on pInfo.ProductsID=p.ProductsID
		where p.pState=0 group by  p.pBrand order by oMoney desc
	  end
	  --购销类别为：单品
	  if(@inyBuySales=2)
	  begin
		select p.pName,p.pBarcode,isnull(pInfo.oQuantity,0) as oQuantity,isnull(pInfo.oMoney,0) as oMoney from
		(select oli.ProductsID,sum(oli.oQuantity) as oQuantity,sum(oli.oMoney) as oMoney from tbOrderInfo as oi left join tbOrderListInfo as oli
		on oi.OrderID=oli.OrderID  
		where oi.oType=3 and oi.oState=0 and oli.oWorkType=2 
		and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		group by  oli.ProductsID) as pInfo 
		left join tbProductsInfo as p on pInfo.ProductsID=p.ProductsID where p.pState=0 order by oMoney desc
	  end
	  --购销类别为：区域
	  if(@inyBuySales=3)
	  begin
	    select rInfo.rName,isnull(sum(pInfo.oQuantity),0) as oQuantity ,isnull(sum(pInfo.oMoney),0) as oMoney from
		(select oi.StoresID,oli.oQuantity,oli.oMoney from tbOrderInfo as oi left join tbOrderListInfo as oli
		on oi.OrderID=oli.OrderID where  oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		 and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59') ) as pInfo left join
		 (select ri.rName,si.StoresID from tbStoresInfo as si left join tbRegionInfo as ri on si.RegionID=ri.RegionID) as rInfo
		 on rInfo.StoresID=pInfo.StoresID group by rInfo.rName order by oMoney desc
	  end
	  --购销类别为：业务员
	  if(@inyBuySales=4)
	  begin
	   select sInfo.sName,isnull(sum(pInfo.oQuantity),0) as oQuantity,isnull(sum(pInfo.oMoney),0) as oMoney from
		(select oi.StoresID,oli.oQuantity,oli.oMoney from tbOrderInfo as oi left join tbOrderListInfo as oli
		 on oi.OrderID=oli.OrderID where  oi.oType=3 and oi.oState=0 and oli.oWorkType=2
		 and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59') ) as pInfo left join
		 (select ssi.StoresID,si.sName from tbStaffStoresInfo as ssi left join  tbStaffInfo as si on ssi.StaffID=si.StaffID
		 where si.sType=1 and si.sState=0 and ssi.sType=0) as sInfo on pInfo.StoresID=sInfo.StoresID 
		 group by sInfo.sName order by oMoney desc
	  end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStorageNumByMonthAndYear_Staff]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 按店员年、每月门店数量统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStorageNumByMonthAndYear_Staff]
	@chvDate varchar(20),     --年份
	@inyStaffID int   --营业员编号
AS
--删除原数据
 If OBJECT_ID('tempdb..#tbGetStorageNumByMonthAndYear_Staff') is not null
 Drop table #tbGetStorageNumByMonthAndYear_Staff
 
--创建临时表
create table #tbGetStorageNumByMonthAndYear_Staff(
             countStorage_1 int,
             countStorage_2 int,
             countStorage_3 int,
             countStorage_4 int,
             countStorage_5 int,
             countStorage_6 int,
             countStorage_7 int,
             countStorage_8 int,
             countStorage_9 int,
             countStorage_10 int,
             countStorage_11 int,
             countStorage_12 int,
             )     
BEGIN
	 insert into #tbGetStorageNumByMonthAndYear_Staff
	 
	 select 
	        count(p.count_1),
	        count(p.count_2),
	        count(p.count_3),
	        count(p.count_4),
	        count(p.count_5),
	        count(p.count_6),
	        count(p.count_7),
	        count(p.count_8),
	        count(p.count_9),
	        count(p.count_10),
	        count(p.count_11),
	        count(p.count_12)
	        
	        
	 from( 
	 select 
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=1 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_1,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=2 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_2,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=3 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_3,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=4 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_4,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=5 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_5,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=6 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_6,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=7 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_7,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=8 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_8,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=9 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_9,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=10 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_10,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=11 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_11,
	 case when datepart(year,sAppendTime)=@chvDate and datepart(month,sAppendTime)=12 and StoresID in(select StoresID from tbStaffStoresInfo where sType=0 and StaffID=@inyStaffID) then sName  end  as count_12
	 
	 from tbStoresInfo) as p
	 
	 select * from #tbGetStorageNumByMonthAndYear_Staff
	 Drop table #tbGetStorageNumByMonthAndYear_Staff 
END


/****** Object:  StoredProcedure [dbo].[sp_ReprotOfStaffByStorehouse]    Script Date: 04/13/2011 15:42:25 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStaffSalesData]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetStaffSalesData]
	(
	@StaffType int,		--人员类型,1业务员,2促销员
	@sDate datetime			--时间点
	)
AS
begin

declare @tStoresID int;
declare @tStaffID int;
declare @tbDate datetime;
declare @teDate datetime;
declare @bDate datetime;
declare @eDate datetime;

if @sDate is null
begin
	set @sDate = getdate();
end

set @bDate = convert(datetime,convert(varchar,DATEPART(year,@sDate))+'-'+convert(varchar,DATEPART(month,@sDate))+'-'+convert(varchar,DATEPART(day,@sDate))+' 00:00:00');
set @eDate = convert(datetime,convert(varchar,DATEPART(year,@sDate))+'-'+convert(varchar,DATEPART(month,@sDate))+'-'+convert(varchar,DATEPART(day,@sDate))+' 23:59:59');

set @bDate = dateadd(month,-1,@bDate);

	declare ocur cursor for select StoresID,StaffID,bdate,edate from tbSales_Staff_StoresDataInfo  where StaffID in(select StaffID from tbStaffInfo where sType=@StaffType and sState=0) and ((bdate BETWEEN  @bDate and @eDate) or (edate BETWEEN @bDate and @eDate));
		open ocur
		FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		WHILE @@FETCH_STATUS = 0
		begin
			
			insert into tbStaff_Sales_DataInfo(SalesID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select s.SalesID,s.StoresID,s.ProductsID,@tStaffID,s.sDateTime,s.sNum,s.sPrice 
						from tbSalesInfo s 
							where s.StoresID=@tStoresID and (s.sDateTime BETWEEN @tbDate and @teDate) and (s.sDateTime BETWEEN @bDate and @eDate)  
								and  s.SalesID not in(select SalesID from tbStaff_Sales_DataInfo where StaffID=@tStaffID and ProductsID=s.ProductsID and StoresID=s.StoresID and sDateTime=s.sDateTime);

			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStaff_StoresList_All]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStaff_StoresList_All]

AS

	If object_id('tempdb..#Sales_Staff_StoresData_tmp_all') is  not null
	begin
		select * from #Sales_Staff_StoresData_tmp_all
	end
	else
	begin
	--创建新临时表
	Create table #Sales_Staff_StoresData_tmp_all (StaffStoresID int,StoresID int,		--门店编号
						StaffID int,			--人员编号
						bdate datetime,			--上岗时间
						edate datetime			--下岗时间
					)

		declare @tStaffStoresID int,@tStoresID int ,@tStaffID int ,@tsDateTime datetime,@tbDate datetime,@teDate datetime,@bDate datetime,@eDate datetime;

		set @bDate = DATEADD(dd,-365,getdate());
		set @eDate = DATEADD(dd,365,getdate());

		--所有人员所有上岗记录
		insert into #Sales_Staff_StoresData_tmp_all(StaffStoresID,StoresID,StaffID,bdate,edate) 
			select StaffStoresID,StoresID,StaffID,sDateTime,DATEADD(dd,365,getdate()) from tbStaffStoresInfo where sType=0 order by StaffStoresID DESC
		--该时间前下岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=1 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp_all set edate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		--更新该时间中上岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=0 and sDateTime<=@bDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp_all set bdate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标

		select * from #Sales_Staff_StoresData_tmp_all;
  end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStaff_StoresList]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetStaff_StoresList]
	/*人员上岗离岗记录*/
	@StaffID int = 0,			--人员编号
	@bDate datetime,			--开始时间
	@eDate datetime,			--结束时间
	@sType int	= -1,			--人员类型,公司=0,业务员=1,促销员=2,其他=3
	@StoresID int =0			--客户编号
AS
begin
SET NOCOUNT ON 

	declare @tStaffStoresID int,@tStoresID int ,@tStaffID int ,@tsDateTime datetime,@tbDate datetime,@teDate datetime;


	--清理原数据
	delete tbSales_Staff_StoresDataInfo where DATEDIFF(YEAR,GETDATE(),bdate)>-2;--保留两年前的数据,以下开始重建一年前到一年后的数据
	

	--删除原数据
	If object_id('tempdb..#Sales_Staff_StoresData_tmp') is  not null
	Drop table #Sales_Staff_StoresData_tmp
	--创建新临时表
	Create table #Sales_Staff_StoresData_tmp (StaffStoresID int,StoresID int,		--门店编号
						StaffID int,			--人员编号
						bdate datetime,			--上岗时间
						edate datetime			--下岗时间
					)
	
	--insert into #Sales_Staff_StoresData_tmp(StaffStoresID,StoresID,StaffID,bdate,edate) exec sp_GetStaff_StoresList_All;

	
	if @StaffID >0
	begin
		--该人员所有上岗记录
		insert into #Sales_Staff_StoresData_tmp(StaffStoresID,StoresID,StaffID,bdate,edate) 
			select StaffStoresID,StoresID,StaffID,sDateTime,DATEADD(dd,365,getdate()) from tbStaffStoresInfo where StaffID=@StaffID and sType=0 order by StaffStoresID DESC
		--该时间前下岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where StaffID=@StaffID and sType=1 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp set edate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		--更新该时间中上岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where StaffID=@StaffID and sType=0 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp set bdate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			update #Sales_Staff_StoresData_tmp set edate=@tsDateTime where StoresID=@tStoresID and edate>@tsDateTime and bdate<@tsDateTime and StaffID in(select StaffID from tbStaffInfo where sType in(select sType from tbStaffInfo where StaffID=@tStaffID));
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
	end
	else
	begin
		--所有人员所有上岗记录
		insert into #Sales_Staff_StoresData_tmp(StaffStoresID,StoresID,StaffID,bdate,edate) 
			select StaffStoresID,StoresID,StaffID,sDateTime,DATEADD(dd,365,getdate()) from tbStaffStoresInfo where sType=0 order by StaffStoresID DESC
		--该时间前下岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=1 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp set edate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
				
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		--更新该时间中上岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=0 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update #Sales_Staff_StoresData_tmp set bdate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			--更新未离岗但有人上岗的记录,以最新上岗记录为离岗时间
			
			update #Sales_Staff_StoresData_tmp set edate=@tsDateTime where StoresID=@tStoresID and edate>@tsDateTime and bdate<@tsDateTime and StaffID in(select StaffID from tbStaffInfo where sType in(select sType from tbStaffInfo where StaffID=@tStaffID));-- and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID);
		
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
	end
	
		insert into tbSales_Staff_StoresDataInfo(StaffStoresID,StoresID,StaffID,bdate,edate)
		select StaffStoresID,StoresID,StaffID,bdate,edate from #Sales_Staff_StoresData_tmp;
	
	if @StoresID >0
	begin
		if @sType > -1
		begin
			select s.StaffStoresID,s.StoresID,s.StaffID,s.bdate,s.edate,(select sName from tbStoresInfo where StoresID=s.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=s.StaffID) as StaffName from #Sales_Staff_StoresData_tmp as s,tbStaffInfo as si where s.StaffID=si.StaffID and si.sType=@sType and s.StoresID=@StoresID ;	
		end
		else
		begin
			select StaffStoresID,StoresID,StaffID,bdate,edate,(select sName from tbStoresInfo where StoresID=#Sales_Staff_StoresData_tmp.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=#Sales_Staff_StoresData_tmp.StaffID) as StaffName from #Sales_Staff_StoresData_tmp where StoresID=@StoresID ;	
		end
	end
	else
	begin
		if @sType > -1
		begin
			select s.StaffStoresID,s.StoresID,s.StaffID,s.bdate,s.edate,(select sName from tbStoresInfo where StoresID=s.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=s.StaffID) as StaffName from #Sales_Staff_StoresData_tmp as s,tbStaffInfo as si where s.StaffID=si.StaffID and si.sType=@sType ;	
		end
		else
		begin
			select StaffStoresID,StoresID,StaffID,bdate,edate,(select sName from tbStoresInfo where StoresID=#Sales_Staff_StoresData_tmp.StoresID) as StoresName,(select sName from tbStaffInfo where StaffID=#Sales_Staff_StoresData_tmp.StaffID) as StaffName from #Sales_Staff_StoresData_tmp  ;	
		end
	end

	Drop table #Sales_Staff_StoresData_tmp;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRegionNodeTable]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRegionNodeTable] 

@nodeid int,
@nodename varchar(50),
@reType int--获取方式,0返回子集,1返回父集

AS
BEGIN
	if(@nodeid=0)
		select @nodeid=RegionID from tbRegionInfo where rName=@nodename

	declare  @nodetable table(nodeid int,nodename varchar(50),nextnodeid int)

	if @reType=0
	begin
		insert @nodetable select a.RegionID as nodeid ,a.rName,a.rUpID from tbRegionInfo as a where RegionID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.RegionID,a.rName,a.rUpID
				from tbRegionInfo a,@nodetable b
				where a.rUpID = b.nodeid and a.RegionID not in(select nodeid from  @nodetable)
		end

	end

	if @reType=1
	begin
		insert @nodetable select a.rUpID as nodeid ,a.rName,a.RegionID from tbRegionInfo as a where RegionID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.rUpID,a.rName,a.RegionID
				from tbRegionInfo a,@nodetable b
				where a.RegionID = b.nodeid and  a.rUpID not in(select nodeid from  @nodetable)
		end
	end

	select * from @nodetable


END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPurchaseReport]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPurchaseReport]
	(
	--进货时间:采购单收货
	--出货时间:采购退货单发货
	@ReType int = 1,		--商品=1,供应商=2
	@bDate datetime,		--开始时间
	@eDate datetime		--结束时间
	)
AS
begin

set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');
set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

declare @tBDate datetime,@tEDate datetime;

set @tBDate = dateadd(DAY,-365,getdate());
set @tEDate = dateadd(DAY,365,getdate());

	--商品
	if @ReType = 1
	begin
		select ppp.* from (
			select p.*,pc.pClassName,
					isnull(oo.oQuantity,0) oQuantity,
					isnull(oo.oMoney,0) oMoney,
					isnull(ool.oQuantity_t,0) oQuantity_t,
					isnull(ool.oMoney_t,0) oMoney_t,
					isnull(ooo.oQuantity,0) ooQuantity,
					isnull(ooo.oMoney,0) ooMoney,
					isnull(oool.oQuantity_t,0) ooQuantity_t,
					isnull(oool.oMoney_t,0) ooMoney_t
			 from tbProductsInfo as p
			--进货,已核销
			left join(
				select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=1 and oState=0 and oSteps>=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=4) ) and ol.oWorkType=2 group by ol.ProductsID
			) as oo on p.ProductsID=oo.ProductsID
			--退货,已核销
			left join(
				select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=2 and oState=0 and oSteps>=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=3)) and oll.oWorkType=2 group by oll.ProductsID
			) as ool on p.ProductsID=ool.ProductsID
			--进货,未核销
			left join(
				select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=1 and oState=0 and oSteps=4 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=4) ) and ol.oWorkType=1 group by ol.ProductsID
			) as ooo on p.ProductsID=ooo.ProductsID
			--退货,未核销
			left join(
				select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=2 and oState=0 and oSteps in (3,4) and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType in(3,4))) and oll.oWorkType=1 group by oll.ProductsID
			) as oool on p.ProductsID=oool.ProductsID
			left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID) ppp 
		where 
			ppp.oQuantity<>0 or 
			ppp.oMoney<>0 or 
			ppp.oQuantity_t<>0 or 
			ppp.oMoney_t<>0 or
			ppp.ooQuantity<>0 or 
			ppp.ooMoney<>0 or 
			ppp.ooQuantity_t<>0 or 
			ppp.ooMoney_t<>0
		order by  ppp.ProductClassID,ppp.ProductsID desc;
	end

	--供应商
	if @ReType = 2
	begin
		select ppp.* from (
			select p.*,pc.pClassName,
					isnull(oo.oQuantity,0) oQuantity,
					isnull(oo.oMoney,0) oMoney,
					isnull(ool.oQuantity_t,0) oQuantity_t,
					isnull(ool.oMoney_t,0) oMoney_t,
					isnull(ooo.oQuantity,0) ooQuantity,
					isnull(ooo.oMoney,0) ooMoney,
					isnull(oool.oQuantity_t,0) ooQuantity_t,
					isnull(oool.oMoney_t,0) ooMoney_t
			 from (select _s.SupplierID,_s.SupplierClassID,_s.sName,_s.sCode,_p.* from tbSupplierInfo _s, tbProductsInfo _p) as p
			--进货,已核销
			left join(
				select ol.ProductsID,_o.StoresID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tborderinfo _o on _o.OrderID=ol.OrderID and _o.oType=1 and _o.oState=0 and _o.oSteps>=5 where  ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=4) and ol.oWorkType=2 group by ol.ProductsID,_o.StoresID
			) as oo on p.ProductsID=oo.ProductsID and p.SupplierID=oo.StoresID
			--退货,已核销
			left join(
				select oll.ProductsID,_o.StoresID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tborderinfo _o on _o.OrderID=oll.OrderID and _o.oType=2 and _o.oState=0 and _o.oSteps>=5 where oll.OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=3) and oll.oWorkType=2 group by oll.ProductsID,_o.StoresID
			) as ool on p.ProductsID=ool.ProductsID and p.SupplierID=ool.StoresID
			--进货,未核销
			left join(
				select ol.ProductsID,_o.StoresID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tborderinfo _o on _o.OrderID=ol.OrderID and _o.oType=1 and _o.oState=0 and _o.oSteps=4 where ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=4) and ol.oWorkType=1 group by ol.ProductsID,_o.StoresID
			) as ooo on p.ProductsID=ooo.ProductsID and p.SupplierID=ooo.StoresID
			--退货,未核销
			left join(
				select oll.ProductsID,_o.StoresID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tborderinfo _o on _o.OrderID=oll.OrderID and _o.oType=2 and _o.oState=0 and _o.oSteps in(2,3,4) where oll.OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType in(3,4)) and oll.oWorkType=1 group by oll.ProductsID,_o.StoresID
			) as oool on p.ProductsID=oool.ProductsID and p.SupplierID=oool.StoresID
			left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID) ppp 
		where 
			ppp.oQuantity<>0 or 
			ppp.oMoney<>0 or 
			ppp.oQuantity_t<>0 or 
			ppp.oMoney_t<>0 or
			ppp.ooQuantity<>0 or 
			ppp.ooMoney<>0 or 
			ppp.ooQuantity_t<>0 or 
			ppp.ooMoney_t<>0
		order by  ppp.ProductClassID,ppp.ProductsID desc;
	end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductPoolList]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetProductPoolList]
/*产品联营时间表*/
	@ProductsID int = 0,		--产品编号
	@bDate datetime,			--开始时间
	@eDate datetime				--结束时间
AS

	declare @tProductPoolID int,@tProductsID int,@tpDateTime datetime;
	
	
	--清理原数据
	delete tbProductPoolDataInfo where DATEDIFF(YEAR,GETDATE(),Bdate)>-2;--保留两年前的数据,以下开始重建一年前到一年后的数据
	
	
	If object_id('tempdb..#ProductPoolData_tmp') is  not null
	Drop table #ProductPoolData_tmp
	--创建新临时表
	Create table #ProductPoolData_tmp (
						ProductPoolID int,
						ProductsID int,			--产品编号
						bdate datetime,			--开始时间
						edate datetime			--结束时间
					)
	--开始联营
	insert into #ProductPoolData_tmp(ProductPoolID,ProductsID,bdate,edate) 
			select ProductPoolID,ProductsID,pDateTime,DATEADD(dd,365,getdate()) from tbProductPoolInfo where pType=0 order by ProductPoolID DESC
	
	--该时间前结束联营记录
	declare ocur cursor for select ProductPoolID,ProductsID,pDateTime from tbProductPoolInfo where pType=1 and pDateTime<=@eDate order by ProductPoolID DESC
	open ocur			
	FETCH NEXT FROM ocur INTO @tProductPoolID,@tProductsID,@tpDateTime
	WHILE @@FETCH_STATUS = 0
	begin
		update #ProductPoolData_tmp set edate=@tpDateTime where ProductsID=@tProductsID and ProductPoolID in(select top 1 ProductPoolID from tbProductPoolInfo where ProductPoolID<@tProductPoolID and ProductsID=@tProductsID order by ProductPoolID DESC)  ;
		
		FETCH NEXT FROM ocur INTO @tProductPoolID,@tProductsID,@tpDateTime;
	end

	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标

	--更新该时间中开始联营记录
	declare ocur cursor for select ProductPoolID,ProductsID,pDateTime from tbProductPoolInfo where pType=0 and pDateTime<=@bDate order by ProductPoolID DESC
	open ocur			
	FETCH NEXT FROM ocur INTO @tProductPoolID,@tProductsID,@tpDateTime
	WHILE @@FETCH_STATUS = 0
	begin
		update #ProductPoolData_tmp set bdate=@tpDateTime where ProductsID=@tProductsID and ProductPoolID in(select top 1 ProductPoolID from tbProductPoolInfo where ProductPoolID<@tProductPoolID and ProductsID=@tProductsID order by ProductPoolID DESC) ;
		
		FETCH NEXT FROM ocur INTO @tProductPoolID,@tProductsID,@tpDateTime;
	end

	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标


	insert into tbProductPoolDataInfo(ProductPoolID,ProductsID,Bdate,Edate)
		select ProductPoolID,ProductsID,Bdate,Edate from #ProductPoolData_tmp;

	if @ProductsID>0
	begin
		select ProductPoolID,ProductsID,bdate,edate from #ProductPoolData_tmp where ProductsID=@ProductsID;
	end
	else
	begin
		select ProductPoolID,ProductsID,bdate,edate from #ProductPoolData_tmp;
	end
	
	
	Drop table #ProductPoolData_tmp;
	
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTagClassNodeTable]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTagClassNodeTable] 

@nodeid int,
@nodename varchar(50),
@reType int--获取方式,0返回子集,1返回父集

AS
BEGIN
	if(@nodeid=0)
		select @nodeid=RegionID from tbRegionInfo where rName=@nodename

	declare  @nodetable table(nodeid int,nodename varchar(50),nextnodeid int)

	if @reType=0
	begin
		insert @nodetable select a.TagClassID as nodeid ,a.tcName,a.tcPaterID from tbTagClassInfo as a where TagClassID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.TagClassID,a.tcName,a.tcPaterID
				from tbTagClassInfo a,@nodetable b
				where a.tcPaterID = b.nodeid and a.TagClassID not in(select nodeid from  @nodetable)
		end

	end

	if @reType=1
	begin
		insert @nodetable select a.tcPaterID as nodeid ,a.tcName,a.TagClassID from tbTagClassInfo as a where TagClassID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.tcPaterID,a.tcName,a.TagClassID
				from tbTagClassInfo a,@nodetable b
				where a.TagClassID = b.nodeid and  a.tcPaterID not in(select nodeid from  @nodetable)
		end
	end

	select * from @nodetable


END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStorehouseReport]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 门店进销存表:自动计算(查询日期截止距离现在前2日的23:59:59)
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStorehouseReport]
	@dt datetime           --时间点
AS   
    if @dt is null
       begin 
       set @dt=GETDATE();
       end
    --=======查询局部变量=======
    declare @pApendtime datetime       --接收时间变换
    declare @inyCount int              --获取日期间隔
    declare @i  int                    --执行循环
    declare @IniReality numeric(18,6)
    --=======更新局部变量======
    declare @Money  money
    declare @StoresID int
    set @IniReality=0;
BEGIN
    --=================================
    --门店[期初]表
    declare @tbInitial table(
            inykey int primary key identity(1,1),     --期初编码 
            storesID int,                             --门店编码
			productID int,                            --产品编号
			InitialQuantity numeric(18,6),            --期初数量
			InitialMoney  money,                      --期初金额
			upDateTime datetime                       --更新日期
    );
    --游标循环门店编号
    DECLARE cuor cursor for select StoresID from tbStoresInfo where StoresID in (select StoresID from tbStoreStorehouseInfo)
    OPEN cuor
    FETCH NEXT FROM cuor into @StoresID
    WHILE @@FETCH_STATUS=0
    BEGIN
      
         set @i=0;
         --找到某个门店距离2天前最近的一个库存日期
         select @pApendtime= max(pAppendTime) from tbStoreStorehouseInfo_calculate  where StoresID=@StoresID group by pAppendTime
         
         --set @inyCount=datepart(DAY,@dt)-DATEPART(DAY,@pApendtime)
         set @inyCount=DATEDIFF(DAY,@pApendtime,@dt)
		 while @i<=@inyCount
		     begin
			 --计算找到日期距离2天前日期的天数
			 set @dt=@pApendtime
			      insert into @tbInitial(storesID,productID,InitialQuantity,InitialMoney,upDateTime)
							select @StoresID,allquantity.ProductsID,isnull(allquantity.realquantity,0) as realquantity,isnull(allquantity.sPrice,0) as oMoney,@dt from
							
							(select p.ProductsID,(isnull(reality.pRelityStorage,0)+isnull(inquantity.InQuantity,0)-isnull(sales.outquantity,0)) as realquantity,isnull(salesPrice.sPrice,0) as sPrice from tbProductsInfo as p left join
							 --期初
							(select ProductsID,isnull(sum(pRelityStorage),0) as pRelityStorage
							 from tbStoreStorehouseInfo_calculate where datediff(day,pAppendTime,@dt)=0 and StoresID=@StoresID group by ProductsID) as reality on reality.ProductsID=p.ProductsID left join
							 --进货
							(select oli.ProductsID,isnull(sum(oli.oQuantity),0) as InQuantity
							 from tbOrderListInfo as oli left join 
							 (select oi.StoresID,oi.OrderID,okl.pAppendTime from tbOrderInfo as oi left join tbOrderWorkingLogInfo as okl on oi.OrderID=okl.OrderID
							 where oi.oType in (3,4) and oi.oState=0 and oi.oSteps>=4 and okl.oType=4 and oi.StoresID=@StoresID ) as orderQuantity   
							 on oli.OrderID=orderQuantity.OrderID  
							 where datediff(day,orderQuantity.pAppendTime,@dt)=0 and oli.oWorkType>=1 group by oli.ProductsID) as inquantity on inquantity.ProductsID=p.ProductsID  left join
							 --销售
							  (select ProductsID,isnull(sum(sNum),0) as outquantity
							   from tbSalesInfo where StoresID=@StoresID  and datediff(day,sDateTime,@dt)=0
							   group by ProductsID) as sales on sales.ProductsID=p.ProductsID left join
							 --当日该产品销售价格
							   (select ProductsID,sPrice from tbSalesInfo
							   where StoresID=@StoresID  and datediff(day,sDateTime,@dt)=0) as salesPrice on salesPrice.ProductsID=p.ProductsID)
							   as allquantity     
				  
			 set @pApendtime=@pApendtime+1;
			 set @i=@i+1
             end  
       FETCH NEXT FROM cuor into @StoresID
	END
	
	--select * from @tbInitial where InitialQuantity !=0 and storesID=658
	--==========================================================================
    --操作临时数据：进货、销售、期初
    --==========================================================================
	--删除原数据
	If object_id('tempdb..#StorehouseStorageReport_tmp') is  not null
	Drop table #StorehouseStorageReport_tmp
	----创建新临时表
	Create table #StorehouseStorageReport_tmp
                   (
                    StoresID int ,                 --门店编号
                    ProductsID int,                --产品编号   
					LastQuantity numeric(18,6),    --结存
					LastMoney money                --金额
					)
     insert into #StorehouseStorageReport_tmp(StoresID,ProductsID,LastQuantity,LastMoney)
		 select pMoney.storesID,pMoney.productID,isnull(quantity.InitialQuantity,0) as InitialQuantity,isnull(quantity.InitialQuantity*pMoney.InitialMoney,0) as InitialMoney from 
		(select storesID,productID,max(upDateTime) as upDateTime,max(InitialMoney) as InitialMoney  from @tbInitial group by storesID,productID) as pMoney  
		 left join 
		(select storesID,productID,SUM(InitialQuantity) as InitialQuantity from @tbInitial  group by storesID,productID) as quantity
		on pMoney.storesID=quantity.storesID and pMoney.productID=quantity.productID
	
	 
         --更新表中期初
		 update tbStoreStorehouseInfo_calculate
		 set  tbStoreStorehouseInfo_calculate.pRelityStorage=#StorehouseStorageReport_tmp.LastQuantity 
			  ,tbStoreStorehouseInfo_calculate.pMoney=#StorehouseStorageReport_tmp.LastMoney
			  ,tbStoreStorehouseInfo_calculate.pAppendTime=@dt
		 from #StorehouseStorageReport_tmp 
		 where tbStoreStorehouseInfo_calculate.StoresID= #StorehouseStorageReport_tmp.StoresID  and tbStoreStorehouseInfo_calculate.ProductsID=#StorehouseStorageReport_tmp.ProductsID 
	    
	     --插入表值
	     insert into tbStoreStorehouseInfo
	   
	     select '',pp.sName,pp.StoresID,'morenzhi','morenzhi',pp.ProductsID,p.pCode,p.pBarcode,p.pName,p.pBrand,p.pStandard
	     ,pp.LastQuantity,pp.LastMoney,@dt,GETDATE() from(
	     select si.sName,ssr.StoresID,ssr.ProductsID,ssr.LastQuantity,ssr.LastMoney
	      from #StorehouseStorageReport_tmp as ssr left join tbStoresInfo  as si on ssr.StoresID=si.StoresID) as pp left join tbProductsInfo
	      as p on pp.ProductsID=p.ProductsID
	     
	DROP TABLE #StorehouseStorageReport_tmp;
	CLOSE cuor--关闭游标
    DEALLOCATE cuor--释放游标
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getStorehouseProductsOfAssociatedDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- @author yangangol
-- 获得仓库联营产品的情况
-- 包含：-1
-- 剔除：0
-- 仅包含：1
-- =============================================
CREATE PROCEDURE [dbo].[sp_getStorehouseProductsOfAssociatedDetails]
	@inyAssociated int,      --联营 -1=包含；0=剔除；1=仅联营
	@inyStorageID int,       --仓库编号
	@dtmDate datetime,       --查询日期
	@dtmEdate datetime
AS
BEGIN
	--仓库报损产品 联营：包含
	if(@inyAssociated=-1)
	begin
	  select ProductsID,pName,pBarcode,pBrand from tbProductsInfo 
	  where ProductsID in (select ProductsID from tbProductsStorageInfo where StorageID=@inyStorageID)
	  and ProductsID in(select distinct(oli.ProductsID) from tbOrderInfo as oi left join tbOrderListInfo as oli on
	  oi.OrderID=oli.OrderID where oi.oType=10  and oi.oState=0 and oli.oWorkType=2 and oli.oQuantity<>0
	  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmDate+' 00:00:00' and @dtmEdate+' 23:59:59'))
	end
	--仓库报损产品 联营：剔除
	if(@inyAssociated=0)
	begin
	  select ProductsID,pName,pBarcode,pBrand from tbProductsInfo 
	  where ProductsID in (select ProductsID from tbProductsStorageInfo where StorageID=@inyStorageID)
	  and ProductsID in(select distinct(oli.ProductsID) from tbOrderInfo as oi left join tbOrderListInfo as oli on
	  oi.OrderID=oli.OrderID where oi.oType=10  and oi.oState=0 and oli.oWorkType=2 and oli.oQuantity<>0
	  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmDate+' 00:00:00' and @dtmEdate+' 23:59:59'))
	  and ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDate)
	end
	--仓库报损产品 联营：仅包含
	if(@inyAssociated=1)
	begin
	  select ProductsID,pName,pBarcode,pBrand from tbProductsInfo 
	  where ProductsID in (select ProductsID from tbProductsStorageInfo where StorageID=@inyStorageID)
	  and ProductsID in(select distinct(oli.ProductsID) from tbOrderInfo as oi left join tbOrderListInfo as oli on
	  oi.OrderID=oli.OrderID where oi.oType=10  and oi.oState=0 and oli.oWorkType=2  and oli.oQuantity<>0
	  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmDate+' 00:00:00' and @dtmEdate+' 23:59:59'))
	  and ProductsID in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDate)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_APARMoney_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_APARMoney_analysis]
/*应收应付统计*/
	
	(
	@gettype int = 0,		--客户应收=1,人员应收=2,供货商应付=3,人员应付=4,结算系统=5
	@eDate datetime = null,	--截止时间点
	@ObjID	int = 0			--指定对象编号
	)
	
AS
begin
	
	declare @AObjType int;	--对象类型
	
	--应收
	if @gettype=1 or @gettype=2 or @gettype=5
	begin
	
		If object_id('tempdb..#ARMoney_tmp') is  not null
		Drop table #ARMoney_tmp
		Create table #ARMoney_tmp (ARObjID int,
							ASumAMoney money,		--新增(发生)应收金额
							ASumBMoney money,		--实际对账金额
							ASumActualMoney money,	--实际已收款金额
							
							BSumAMoney money,		--(已完成)新增(发生)应收金额
							BSumBMoney money,		--(已完成)实际对账金额
							BSumActualMoney money,	--(已完成)实际已收款金额
							
							SYMoney money			--剩余
						)
						/*
		If object_id('tempdb..#ProductPoolList_tmp') is  not null
		Drop table #ProductPoolList_tmp
		--创建新临时表
		Create table #ProductPoolList_tmp (
							ProductPoolID int,
							ProductsID int,			--产品编号
							bdate datetime,			--上岗时间
							edate datetime			--下岗时间
						)
	*/
		if @gettype=1
		begin
			set @AObjType = 0;	--门店
		end
		if @gettype=2
		begin
			set @AObjType = 1;	--个人
		end
		if @gettype=5
		begin
			set @AObjType = 2;	--结算系统
		end
		
		--截止时间内所有产品联营记录
		--insert into #ProductPoolList_tmp(ProductPoolID,ProductsID,bdate,edate) exec sp_GetProductPoolList 0,'1984-9-24',@eDate;
		
		insert into #ARMoney_tmp(ARObjID,ASumAMoney,ASumBMoney,ASumActualMoney,BSumAMoney,BSumBMoney,BSumActualMoney,SYMoney)
			select ARObjID,
				isnull(sum(case
					when aSteps=1 then isnull(aAMoney,0)
					when aSteps=2 then 0
				end),0) as ASumAMoney,
				isnull(sum(case
					when aSteps=1 then isnull(aBMoney,0)
					when aSteps=2 then 0
				end),0) as ASumBMoney,
				isnull(sum(case
					when aSteps=1 then isnull(aActualMoney,0)
					when aSteps=2 then 0
				end),0) as ASumActualMoney,
				isnull(sum(case
					when aSteps=1 then 0
					when aSteps=2 then isnull(aAMoney,0)
				end),0) as BSumAMoney,
				isnull(sum(case
					when aSteps=1 then 0
					when aSteps=2 then isnull(aBMoney,0)
				end),0) as BSumAMoney,
				isnull(sum(case
					when aSteps=1 then 0
					when aSteps=2 then isnull(aActualMoney,0)
				end),0) as BSumActualMoney,
				isnull((sum(isnull(aAMoney,0))-sum(isnull(aActualMoney,0))),0) as SYMoney
				from tbARMoneyInfo where ARObjType=@AObjType and aUpdateTime<=@eDate
				group by ARObjID

		--门店
		if @AObjType = 0
		begin
			if @ObjID>0
			begin
				select s.StoresID,s.sName,s.sDoDay,s.sDoDayMoney,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
				 from tbStoresInfo as s,#ARMoney_tmp as r where s.StoresID=r.ARObjID and s.StoresID = @ObjID
					order by r.SYMoney,s.StoresID desc
			end
			else
			begin
				select s.StoresID,s.sName,s.sDoDay,s.sDoDayMoney,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
					 from tbStoresInfo as s,#ARMoney_tmp as r where s.StoresID=r.ARObjID
						order by r.SYMoney,s.StoresID desc
			end
		end
		
		--个人
		if @AObjType = 1
		begin
			if @ObjID>0
			begin
				select s.StaffID,s.sName,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
				 from tbStaffInfo as s,#ARMoney_tmp as r where s.StaffID=r.ARObjID and s.StaffID=@ObjID
					order by r.SYMoney,s.StaffID desc
			end
			else
			begin
				select s.StaffID,s.sName,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
				 from tbStaffInfo as s,#ARMoney_tmp as r where s.StaffID=r.ARObjID
					order by r.SYMoney,s.StaffID desc
			end
		end
		
		--结算系统
		if @AObjType = 2
		begin
			if @ObjID>0
			begin
				select p.PaymentSystemID,p.pName,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
				 from tbPaymentSystemInfo as p,#ARMoney_tmp as r where p.PaymentSystemID=r.ARObjID and p.PaymentSystemID=@ObjID
					order by r.SYMoney,p.PaymentSystemID desc
			end
			else
			begin
				select p.PaymentSystemID,p.pName,r.ASumAMoney,r.ASumBMoney,r.ASumActualMoney,r.BSumAMoney,r.BSumBMoney,r.BSumActualMoney,r.SYMoney
				 from tbPaymentSystemInfo as p,#ARMoney_tmp as r where p.PaymentSystemID=r.ARObjID 
					order by r.SYMoney,p.PaymentSystemID desc
			end
		end
		
		Drop table #ARMoney_tmp
		--Drop table #ProductPoolList_tmp;
	end
	
	--应付
	if @gettype=3 or @gettype=4
	begin
	
		If object_id('tempdb..#APMoney_tmp') is  not null
		Drop table #APMoney_tmp
		Create table #APMoney_tmp (APObjID int,
							SumPMoney money,		--应付金额
							SumPayMoney money,		--已付金额
							SumOtherMoney money,	--其他已付金额
							
							SYMoney money,			--剩余
							SumNPMoney money		--新增应付金额
						)
	
		if @gettype=3
		begin
			set @AObjType = 2;	--供货商
		end
		if @gettype=4
		begin
			set @AObjType = 1;	--个人
		end
		
		insert into #APMoney_tmp(APObjID,SumPMoney,SumPayMoney,SumOtherMoney,SYMoney,SumNPMoney)
			select APObjID,sum(isnull(aPMoney,0)) as SumPMoney,sum(isnull(aPayMoney,0)) as SumPayMoney,sum(isnull(aOtherMoney,0)) as SumOtherMoney,sum(isnull(aNPMoney,0))-sum(isnull(aPayMoney,0))-sum(isnull(aOtherMoney,0)),sum(isnull(aNPMoney,0))
			 from tbAPMoneyInfo where APObjType=@AObjType and aDoDateTime<=@eDate
				group by APObjID
		
		if @AObjType = 2
		begin
			if @ObjID>0
			begin
				select s.SupplierID,s.sName,s.sDoDay,s.sDoDayMoney,p.SumPMoney,p.SumPayMoney,p.SumOtherMoney,p.SYMoney,p.SumNPMoney
				 from tbSupplierInfo as s,#APMoney_tmp as p where s.SupplierID=p.APObjID and s.SupplierID=@ObjID
					order by p.SYMoney,s.SupplierID desc
			end
			else
			begin
				select s.SupplierID,s.sName,s.sDoDay,s.sDoDayMoney,p.SumPMoney,p.SumPayMoney,p.SumOtherMoney,p.SYMoney,p.SumNPMoney
					 from tbSupplierInfo as s,#APMoney_tmp as p where s.SupplierID=p.APObjID
						order by p.SYMoney,s.SupplierID desc
			end
		end
		
		if @AObjType = 1
		begin
			if @ObjID>0
			begin
				select s.StaffID,s.sName,p.SumPMoney,p.SumPayMoney,p.SumOtherMoney,p.SYMoney,p.SumNPMoney
				 from tbStaffInfo as s,#APMoney_tmp as p where s.StaffID=p.APObjID and s.StaffID = @ObjID
					order by p.SYMoney,s.StaffID desc
			end
			else
			begin
				select s.StaffID,s.sName,p.SumPMoney,p.SumPayMoney,p.SumOtherMoney,p.SYMoney,p.SumNPMoney
					 from tbStaffInfo as s,#APMoney_tmp as p where s.StaffID=p.APObjID
						order by p.SYMoney, s.StaffID desc
			end
		end
		
		Drop table #APMoney_tmp;
	end
	
end
GO
/****** Object:  UserDefinedFunction [dbo].[fun_YHData]    Script Date: 10/11/2016 09:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fun_YHData]
(
	@bDate datetime,
	@eDate datetime
	)
RETURNS @tTable TABLE (StoresID int,sName varchar(256),tValue money)
AS
	BEGIN
		insert into @tTable(StoresID,sName,tValue)
			select si.StoresID,si.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
				from tbStoresInfo as si left join tbSalesInfo as s on si.StoresID=s.StoresID 
				where s.sIsYH=1 and si.sIsFZYH=1 and s.sDateTime>=@bDate and s.sDateTime<=@eDate 
				group by si.StoresID,si.sName order by tvalue desc
	RETURN
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetStaff_StoresList_All]    Script Date: 10/11/2016 09:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fun_GetStaff_StoresList_All]
	(
	)
RETURNS  @Sales_Staff_StoresData_tmp_all TABLE (StaffStoresID int,StoresID int,		--门店编号
						StaffID int,			--人员编号
						bdate datetime,			--上岗时间
						edate datetime			--下岗时间
						) 
as
	BEGIN
		declare @tStaffStoresID int,@tStoresID int ,@tStaffID int ,@tsDateTime datetime,@tbDate datetime,@teDate datetime,@bDate datetime,@eDate datetime;

		set @bDate = DATEADD(dd,-365,getdate());
		set @eDate = DATEADD(dd,365,getdate());

		--所有人员所有上岗记录
		insert into @Sales_Staff_StoresData_tmp_all(StaffStoresID,StoresID,StaffID,bdate,edate) 
			select StaffStoresID,StoresID,StaffID,sDateTime,DATEADD(dd,365,getdate()) from tbStaffStoresInfo where sType=0 order by StaffStoresID DESC
		--该时间前下岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=1 and sDateTime<=@eDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update @Sales_Staff_StoresData_tmp_all set edate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		--更新该时间中上岗记录
		declare ocur cursor for select StaffStoresID,StoresID,StaffID,sDateTime from tbStaffStoresInfo where sType=0 and sDateTime<=@bDate order by StaffStoresID DESC
		open ocur			
		FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime
		WHILE @@FETCH_STATUS = 0
		begin
			update @Sales_Staff_StoresData_tmp_all set bdate=@tsDateTime where StoresID=@tStoresID and StaffStoresID in(select top 1 StaffStoresID from tbStaffStoresInfo where sDateTime<@tsDateTime and StoresID=@tStoresID and StaffID=@tStaffID order by sDateTime DESC) and StaffID=@tStaffID ;
			
			FETCH NEXT FROM ocur INTO @tStaffStoresID,@tStoresID,@tStaffID,@tsDateTime;
		end
		
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标

	RETURN
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetProductPriceXP_b]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fun_GetProductPriceXP_b]
(
	@pid int,							--产品编号
	@dT_b datetime,						--时间点
	@dT_e datetime,						--时间点
	@rType int							--类型
)
RETURNS money
AS
begin
	DECLARE @Price numeric(18,6);		--返回的成本
	declare @eMoney  numeric(18,6);
	declare @eQuantity numeric(18,6);
	
	--日
	if @rType = 0
	begin

		set @dT_b = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT_b)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT_b)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT_b)))+' 00:00:00');
		set @dT_e = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT_e)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT_e)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT_e)))+' 23:59:59');
	end
	--月
	if @rType = 1 
	begin
	--上期
		set @dT_b = dateadd(dd,-datepart(dd,DATEADD(month, -1, @dT_b))+1,DATEADD(month, -1, @dT_b));--本月第一天
		set @dT_e = convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,DATEADD(month, -1, @dT_e)-day(DATEADD(month, -1, @dT_e))+1)),23)+' 23:59:59');--本月最后一天
	end
	--年
	if @rType = 2 
	begin
	--上期
		set @dT_b = DATEADD(year, DATEDIFF(year, '', DATEADD(year, -1, @dT_b)), '');--本年第一天
		set @dT_e = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,DATEADD(year, -1, @dT_e))+1, 0));--本年最后一天
	end
	
	
	select @eMoney=isnull(sum(isnull(eMoney,0)),0),@eQuantity=isnull(sum(isnull(eQuantity,0)),0) from tbReportInvoicingDataInfo where ProductsID=@pid and rType=@rType and rBDateTime>=@dT_b and rEdateTime<=@dT_e group by ProductsID;

	if @eQuantity<>0 
	begin
		SET	@Price = @eMoney/@eQuantity;
	end
	else
	begin
		set @Price = 0;
	end

	return @Price;
end
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetProductPriceXP]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fun_GetProductPriceXP]
	(
	@pid int,								--产品编号
	@dT_b datetime,						--时间点
	@dT_e datetime						--时间点
	)
RETURNS money
AS
begin
	DECLARE @Price numeric(20,6);		--返回的成本
	declare @eMoney  numeric(20,6);
	declare @eQuantity numeric(20,6);
	
	select @eMoney=isnull(sum(isnull(eMoney,0)),0),@eQuantity=isnull(sum(isnull(eQuantity,0)),0) from tbReportInvoicingDataInfo where ProductsID=@pid and rType=0 and rBDateTime>=@dT_b and rEdateTime<=@dT_e group by ProductsID;

	if @eQuantity<>0 
	begin
		SET	@Price = @eMoney/@eQuantity;
	end
	else
	begin
		set @Price = 0;
	end

	return @Price;
end
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetProductPrice]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fun_GetProductPrice]
/*
取指定产品指定时间段成本
计算方法:
		取该产品相对时间点最近一次进价成本,并加权平均.
		公式:
			销售成本=	(期初总金额+本期增加总金额)/(期初总数量+本期增加总数量)
			期末成本=	(期初总金额+本期增加总金额-本期减少总金额)/(期初总数量+本期增加总数量-本期减少总数量)
*/
	(
	@pid int,								--产品编号
	@StorageID	int = 0,				--仓库编号,0=全部参考,已废除
	@dT_b datetime,		--开始时间
	@dt_e datetime,		--结束时间
	@ReType	int = 0,					--统计时间区间类型,0=日,1=月,2=年
	@sType	int = 0,					--统计类型,0=本期成本,1=期末成本
	@DataType	int =0				--统计数据方式,0=取上期结存成本,1=取本期发生成本
	)
RETURNS money
AS
	BEGIN
		DECLARE @Price numeric(18,6);		--返回的成本
		declare @u_bDate datetime;	--上期开始时间
		declare @u_eDate datetime;	--上期结束时间
		declare @bDate datetime;		--本期开始时间
		declare @eDate datetime;		--本期结束时间

		declare @u_sum_money	numeric(18,6);				--期初总金额
		declare @add_sum_money		numeric(18,6);		--本期增加总金额
		declare	@cut_sum_money		numeric(18,6);		--本期减少总金额

		declare @u_sum_quantity			numeric(18,6);	--期初总数量
		declare @add_sum_quantity		numeric(18,6);	--本期增加总数量
		declare	@cut_sum_quantity		numeric(18,6);	--本期减少总数量

		declare @thisCut_price numeric(18,6);	--上期结存成本,本期出库成本
		--日
		if @ReType = 0
		begin
			--上期			
			set @u_bDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT_b)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT_b)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT_b)))+' 00:00:00');
			set @u_eDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT_e)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT_e)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT_e)))+' 23:59:59');

			--本期
			set @bDate = convert(datetime,convert(varchar,DATEPART(year,@dT_b))+'-'+convert(varchar,DATEPART(month,@dT_b))+'-'+convert(varchar,DATEPART(day,@dT_b))+' 00:00:00');
			set @eDate = convert(datetime,convert(varchar,DATEPART(year,@dT_e))+'-'+convert(varchar,DATEPART(month,@dT_e))+'-'+convert(varchar,DATEPART(day,@dT_b))+' 23:59:59');
		end
		
		--月
		if @ReType = 1 
		begin
			--上期
			set @u_bDate = dateadd(dd,-datepart(dd,DATEADD(month, -1, @dT_b))+1,DATEADD(month, -1, @dT_b));--本月第一天
			set @u_eDate = convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,DATEADD(month, -1, @dT_e)-day(DATEADD(month, -1, @dT_e))+1)),23)+' 23:59:59');--本月最后一天

			--本期
			set @bDate = dateadd(dd,-datepart(dd,@dT_b)+1,@dT_b);--本月第一天
			set @eDate = convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,@dT_e-day(@dT_e)+1)),23)+' 23:59:59');--本月最后一天
		end
		
		--年
		if @ReType = 2 
		begin
			--上期
			set @u_bDate = DATEADD(year, DATEDIFF(year, '', DATEADD(year, -1, @dT_b)), '');--本年第一天
			set @u_eDate = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,DATEADD(year, -1, @dT_e))+1, 0));--本年最后一天

			--本期
			set @bDate = DATEADD(year, DATEDIFF(year, '', @dT_b), '');--本年第一天
			set @eDate = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT_e)+1, 0));--本年最后一天
		end

		--本期最后一天是今天的未来
		if datediff(day,GETDATE(),@eDate)>0
		begin
			set @eDate = getdate();
		end

		set @u_sum_money = 0;
		set @u_sum_quantity = 0;

		--本期期初,上期期末,所有仓库合计
		declare @fun_GetProductPrice_bdata_tmp table (ReportInvoicingID int ,
		ProductsID int,
		eQuantity numeric(18,8),
		eMoney numeric(18,8),
		rEdateTime datetime);

		insert into @fun_GetProductPrice_bdata_tmp(ReportInvoicingID,ProductsID,eQuantity,eMoney,rEdateTime)
			select ReportInvoicingID,ProductsID,eQuantity,eMoney,rEdateTime from tbReportInvoicingDataInfo where ProductsID=@pid and rEdateTime<=@u_eDate and rType=@ReType order by rEdateTime desc;

		select  @u_sum_money=sum(isnull(eMoney,0)),@u_sum_quantity=sum(isnull(eQuantity,0)) from @fun_GetProductPrice_bdata_tmp where datediff(day,rEdateTime,(select top 1 ptp.rEdateTime from @fun_GetProductPrice_bdata_tmp as ptp order by ptp.rEdateTime desc)) =0 group by ProductsID;

		--本期期初成本
		if @u_sum_quantity>0
		begin
			set @thisCut_price = @u_sum_money/@u_sum_quantity;
		end
		else
		begin
			set @thisCut_price = 0;
		end

		--本期新增
		declare @fun_GetProductPrice_tmp table (ProductsID int PRIMARY KEY,
		--StorageID int,
		Quantity numeric(18,8),sMoney money);
		
		insert into @fun_GetProductPrice_tmp(ProductsID,--StorageID,
		Quantity,sMoney)
			select ol.ProductsID,--ol.StorageID,
				isnull(sum(
					case o.oType 
						when 2 then 0-ol.oQuantity--退货为负数
						else ol.oQuantity
					end),0) as Quantity,--数量
					isnull(sum(
					case o.oType 
						when 2 then 0-ol.oMoney--退货为负数
						else  ol.oMoney
					end),0) sMoney --金额
					 from tbOrderListInfo ol left join tbOrderInfo o on ol.OrderID=o.OrderID 
					 where ol.oWorkType>=1 and  o.oState=0 and o.oType in(1,2) and o.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and pAppendTime between @bDate and @eDate ) and o.oSteps>=4
					  and ol.ProductsID=@pid 
					 group by --ol.StorageID,
					 ol.ProductsID;


		select @add_sum_quantity=sum(isnull(Quantity,0)), @add_sum_money=sum(isnull(sMoney,0)) from @fun_GetProductPrice_tmp group by ProductsID;
		
		delete from @fun_GetProductPrice_tmp;

		--本期成本,销售成本
		if @sType=0
		begin
			if (@u_sum_quantity+@add_sum_quantity)<>0
			begin
				set @Price=(@u_sum_money+@add_sum_money)/(@u_sum_quantity+@add_sum_quantity);
			end
		end

		--期末成本
		if @sType=1
		begin
			insert into @fun_GetProductPrice_tmp(ProductsID,--StorageID,
			Quantity,sMoney)
				select ol.ProductsID,--ol.StorageID,
				isnull(sum(
				case o.oType 
					when 4 then 0-ol.oQuantity--退货为负数
					else ol.oQuantity 
				end),0) as Quantity,	--数量
				isnull(sum(
				case o.oType 
					when 4 then 0-(ol.oQuantity)--退货为负数
				else (ol.oQuantity) 
				end)*@thisCut_price--dbo.fun_GetProductPrice(ol.ProductsID,0,@bDate,@eDate,@ReType,@sType,@DataType)
				,0) as sMoney	--金额
				 from tbOrderListInfo ol left join tbOrderInfo o on ol.OrderID=o.OrderID 
				 where ol.oWorkType>=1 and o.oType in(3,4,5,6,7,10) and  o.oState=0 and o.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and pAppendTime between @bDate and @eDate) and o.oSteps>=3
				 and ol.ProductsID=@pid
				 group by --ol.StorageID,
				 ol.ProductsID;


			select @cut_sum_quantity=isnull(sum(Quantity),0), @cut_sum_money=isnull(sum(sMoney),0) from @fun_GetProductPrice_tmp group by ProductsID;

			if (@u_sum_quantity+@add_sum_quantity-@cut_sum_quantity)>0
			begin
				set @Price=(@u_sum_money+@add_sum_money-@cut_sum_quantity)/(@u_sum_quantity+@add_sum_quantity-@cut_sum_quantity);
			end
			else
			begin
				set @Price=0;
			end

		end

		delete from @fun_GetProductPrice_tmp;

		RETURN @Price;
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetProductCostPrice]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 取指定时间,指定产品成本
-- 执行该函数前需执行存储过程 sp_GetProductCostValence
-- =============================================
CREATE FUNCTION [dbo].[fun_GetProductCostPrice]
(
	@ProductsID	int = 0,	--产品编号
	@sDate		datetime	--时间点
)
RETURNS money
AS
BEGIN

	DECLARE @CostPrice money

	select @CostPrice=cPrice from tbProductCostPriceInfo where ProductsID=@ProductsID and bdate<=@sDate and edate>=@sDate;

	RETURN @CostPrice;

END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetNameForObjID]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fun_GetNameForObjID]
	(
	@StoresID int = 0,
	@ObjType int = 0
	)
RETURNS varchar(128)
AS
	BEGIN
	declare @reValue varchar(128);
	
	--门店客户
	if @ObjType=0
	begin
		select @reValue=sName from tbStoresInfo where StoresID=@StoresID;
	end
	
	--人员
	if @ObjType=1
	begin
		select @reValue=sName from tbStaffInfo where StaffID=@StoresID;
	end
	
	--供货商
	if @ObjType=2
	begin
		select @reValue=sName from tbSupplierInfo where SupplierID=@StoresID;
	end
	
	--结算系统
	if @ObjType=3
	begin
		select @reValue=pName from tbPaymentSystemInfo where PaymentSystemID=@StoresID;
	end
	
	RETURN @reValue;
	END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetFeesSubjectNodeTable]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[fun_GetFeesSubjectNodeTable]
(
	@nodeid int,
	@nodename varchar(50),
	@reType int--获取方式,0返回子集,1返回父集
)
RETURNS 
@nodetable TABLE 
(
	nodeid int,nodename varchar(50),nextnodeid int
)
AS
BEGIN
	if(@nodeid=0)
		select @nodeid=RegionID from tbRegionInfo where rName=@nodename


	if @reType=0
	begin
		insert @nodetable select a.FeesSubjectClassID as nodeid ,a.cClassName,a.cParentID from tbFeesSubjectClassInfo as a where FeesSubjectClassID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.FeesSubjectClassID,a.cClassName,a.cParentID
				from tbFeesSubjectClassInfo a,@nodetable b
				where a.cParentID = b.nodeid and a.FeesSubjectClassID not in(select nodeid from  @nodetable)
		end

	end

	if @reType=1
	begin
		insert @nodetable select a.cParentID as nodeid ,a.cClassName,a.FeesSubjectClassID from tbFeesSubjectClassInfo as a where FeesSubjectClassID = @nodeid
		while @@rowcount > 0
		begin
			insert @nodetable select a.cParentID,a.cClassName,a.FeesSubjectClassID
				from tbFeesSubjectClassInfo a,@nodetable b
				where a.FeesSubjectClassID = b.nodeid and  a.cParentID not in(select nodeid from  @nodetable)
		end
	end
	
	RETURN ;
END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_CheckProductIsPool]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 指定时间,指定商品,判断是否为联营期内商品
-- 执行该函数前需执行存储过程 sp_GetProductPoolList
-- =============================================
CREATE FUNCTION [dbo].[fun_CheckProductIsPool]
(
	@ProductsID	int=0,		--产品编号
	@sDate	datetime		--时间点
)
RETURNS int--是=1,否=0
AS
BEGIN
	DECLARE @ReValue int;

	if not exists(select ProductPoolID from tbProductPoolDataInfo where ProductsID=@ProductsID and Bdate<=@sDate and Edate>=@sDate)
	begin
		set @ReValue=0;
	end
	else
	begin
		set @ReValue=1;
	end

	RETURN @ReValue;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CostDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-6-15
-- Description:	费用统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_CostDetails]
	@inyStoresID int,         --门店编号
	@chvKtype varchar(20),    --科目选择
	@inyType int,             --借贷关系
	@dtmBdate datetime,       --开始日期
	@dtmEdate datetime        --结束日期
AS
    --删除原数据
	If object_id('tempdb..#costDetails_tmp') is  not null
	Drop table #StorehouseStorageReport_tmp
	----创建新临时表
	Create table #costDetails_tmp
	     (
	       storesID int,         --门店编号
	       storesName varchar(50),
	       appendCost money      --发生金额
	     ) 
BEGIN
    --借方
    if @inyType=0 and @inyStoresID>0
    begin
		insert into #costDetails_tmp(storesID,storesName,appendCost)
		select pp.toObjectID,si.sName,isnull(pp.cdMoney,0) from (
		select cfi.toObjectID,isnull(sum(cfi.cdMoney),0) as cdMoney from tbCertificateDataInfo as cfi where CertificateID in (
		select ci.CertificateID from tbCertificateInfo as ci left join tbCertificateWorkingLogInfo as ckl
		on ci.CertificateID=ckl.CertificateID where ckl.cType=2 and ci.cState=0 and cDateTime
		between @dtmBdate and @dtmEdate)  and cfi.toObject=0 and cfi.FeesSubjectID=@chvKtype and cfi.toObjectID=@inyStoresID
		group by cfi.toObjectID  ) as pp left join tbStoresInfo as si on pp.toObjectID=si.StoresID
    end
    --贷方
    if @inyType=1 and  @inyStoresID>0
    begin
		insert into #costDetails_tmp(storesID,storesName,appendCost)
		
		select pp.toObjectID,si.sName,isnull(pp.cdMoneyB,0) from (
		select cfi.toObjectID,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as cfi where CertificateID in (
		select ci.CertificateID from tbCertificateInfo as ci left join tbCertificateWorkingLogInfo as ckl
		on ci.CertificateID=ckl.CertificateID where ckl.cType=2 and ci.cState=0 and cDateTime
		between @dtmBdate and @dtmEdate)  and cfi.toObject=0 and cfi.FeesSubjectID=@chvKtype and cfi.toObjectID=@inyStoresID
		group by cfi.toObjectID ) as pp left join tbStoresInfo as si on pp.toObjectID=si.StoresID
    end
    
     --借方
    if @inyType=0 and @inyStoresID<0
    begin
	    insert into #costDetails_tmp(storesID,storesName,appendCost)
		select pp.toObjectID,si.sName,isnull(pp.cdMoney,0) from (
		select cfi.toObjectID,isnull(sum(cfi.cdMoney),0) as cdMoney from tbCertificateDataInfo as cfi where CertificateID in (
		select ci.CertificateID from tbCertificateInfo as ci left join tbCertificateWorkingLogInfo as ckl
		on ci.CertificateID=ckl.CertificateID where ckl.cType=2 and ci.cState=0 and cDateTime
		between @dtmBdate and @dtmEdate)  and cfi.toObject=0 and cfi.FeesSubjectID=@chvKtype 
		group by cfi.toObjectID  ) as pp left join tbStoresInfo as si on pp.toObjectID=si.StoresID
    end
    --贷方
    if @inyType=1 and  @inyStoresID<0
    begin
		insert into #costDetails_tmp(storesID,storesName,appendCost)
		
		select pp.toObjectID,si.sName,isnull(pp.cdMoneyB,0) from (
		select cfi.toObjectID,isnull(sum(cfi.cdMoneyB),0) as cdMoneyB from tbCertificateDataInfo as cfi where CertificateID in (
		select ci.CertificateID from tbCertificateInfo as ci left join tbCertificateWorkingLogInfo as ckl
		on ci.CertificateID=ckl.CertificateID where ckl.cType=2 and ci.cState=0 and cDateTime
		between @dtmBdate and @dtmEdate)  and cfi.toObject=0 and cfi.FeesSubjectID=@chvKtype 
		group by cfi.toObjectID ) as pp left join tbStoresInfo as si on pp.toObjectID=si.StoresID
    end
    --获取门店所有发生的金额
    select storesID,storesName,isnull(sum(appendCost),0) as appendCost from #costDetails_tmp  group by storesID,storesName
    
    
    DROP TABLE #costDetails_tmp;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_checkpasswordbyusername]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_checkpasswordbyusername]
@uName nchar(20),
@uPWD char(32)
AS
SELECT TOP 1 [UserID] FROM [tbUserInfo] WHERE [uName]=@uName AND [uPWD]=@uPWD
GO
/****** Object:  StoredProcedure [dbo].[sp_checkpasswordbyuid]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_checkpasswordbyuid]
@UserID int,
@uPWD char(32)
AS
SELECT TOP 1 [UserID] FROM [tbUserInfo] WHERE [UserID]=@UserID AND [uPWD]=@uPWD
GO
/****** Object:  StoredProcedure [dbo].[sp_checkpassword]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_checkpassword]
@uName varchar(50),
@uPWD char(32)
AS
SELECT TOP 1 [UserID] FROM [tbUserInfo] WHERE [uName]=@uName AND [uPWD]=@uPWD
GO
/****** Object:  StoredProcedure [dbo].[sp_DayBankMoney]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		cxty
-- 每日账户金额
-- =============================================
CREATE PROCEDURE [dbo].[sp_DayBankMoney]
	@sDate datetime=getdate	----计算时间点,日期,默认为当时时间
AS
BEGIN
	
	declare @BankID int;
	
	declare ocur cursor for select BankID from tbBankInfo
	open ocur			
		FETCH NEXT FROM ocur INTO @BankID
		WHILE @@FETCH_STATUS = 0
		begin
			if exists(select 0 from tbBankMoneyInfo where BankID=@BankID and datediff(day,bUpdateTime,@sDate)=0)
			begin
				update tbBankMoneyInfo set bMoney=(select 
					isnull(sum(isnull((case c.cType
					when 0 then cd.cdMoney		--收款
					when 1 then -cd.cdMoney		--付款
					end),0)),0) as cdMoney					
					 from tbCertificateDataInfo as cd left join tbCertificateInfo as c on cd.CertificateID=c.CertificateID where c.BankID=@BankID and c.cDateTime<=@sDate),
					 bUpdateTime=GETDATE() where BankID=@BankID and datediff(day,bUpdateTime,@sDate)=0;
			end
			else
			begin
				insert into tbBankMoneyInfo(BankID,bMoney,bUpdateTime,bAppendTime,isBegin)
					select @BankID,
					isnull(sum(isnull((case c.cType
					when 0 then cd.cdMoney		--收款
					when 1 then -cd.cdMoney		--付款
					end),0)),0) as cdMoney					
					,GETDATE(),GETDATE(),0 from tbCertificateDataInfo as cd left join tbCertificateInfo as c on cd.CertificateID=c.CertificateID where c.BankID=@BankID and c.cDateTime<=@sDate;
			end
			FETCH NEXT FROM ocur INTO @BankID;
		end
		
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customers_DataAnlysis_Export]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customers_DataAnlysis_Export]
	@dtmBdate  datetime,     --导出日期
	@inyType  int,           --导出类型  1=客户；2=业务员；3=促销员;4=单品；5=品牌
	@inycheckValue int       --导出类型  0=日；1=周；2=月
AS
BEGIN
	 --客户
	 if(@inyType=1)
	   begin 
	    --按日
	    if(@inycheckValue=0)
	    begin
			select si.StoresID,si.sName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select StoresID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(DAY,sDateTime,@dtmBdate)=0 group by StoresID) as pp right join tbStoresInfo as si 
			on pp.StoresID=si.StoresID where si.sState=0 order by si.StoresID asc
		end
		 --按周
	    if(@inycheckValue=1)
	    begin
			select si.StoresID,si.sName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select StoresID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(WEEK,sDateTime,@dtmBdate)=0 group by StoresID) as pp right join tbStoresInfo as si 
			on pp.StoresID=si.StoresID where si.sState=0 order by si.StoresID asc
		end
		 --按月
	    if(@inycheckValue=2)
	    begin
			select si.StoresID,si.sName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select StoresID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(MONTH,sDateTime,@dtmBdate)=0 group by StoresID) as pp right join tbStoresInfo as si 
			on pp.StoresID=si.StoresID where si.sState=0 order by si.StoresID asc
		end
	   end
	--业务员
	  if(@inyType=2)
	  begin
	    --按日
	    if(@inycheckValue=0)
	    begin
	            select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(DAY,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=1  group by si.StaffID,si.sName order by si.StaffID asc
	    
	    end
	     --按周
	    if(@inycheckValue=1)
	    begin
	            select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(WEEK,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=1 group by si.StaffID,si.sName order by si.StaffID asc
	    end
	     --按月
	    if(@inycheckValue=2)
	    begin
	            select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(MONTH,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=1  group by si.StaffID,si.sName order by si.StaffID asc
	    end
	  end
	--促销员
	  if(@inyType=3)
	  begin
	    --按日
	    if(@inycheckValue=0)
	    begin
			  select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(DAY,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=2 group by si.StaffID,si.sName order by si.StaffID asc
		end 
		 --按周
	    if(@inycheckValue=1)
	    begin
		 select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(WEEK,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=2 group by si.StaffID,si.sName order by si.StaffID asc
		end
		 --按月
	    if(@inycheckValue=2)
	    begin
		  select si.StaffID,si.sName,isnull(sum(mm.sNum),0) as sNum,isnull(sum(mm.sPrice),0) as sPrice from(
                select (select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss right join 
                tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and 
                s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID,isnull(s.sNum,0) as sNum,isnull(s.sPrice,0) as sPrice from tbSalesInfo s where 
                DATEDIFF(MONTH,sDateTime,@dtmBdate)=0 ) as mm right join tbStaffInfo as si on mm.StaffID=si.StaffID
                where si.sState=0 and si.sType=2 group by si.StaffID,si.sName order by si.StaffID asc
		end
	  end
	--单品
	   if(@inyType=4)
	   begin
	    --按日
	    if(@inycheckValue=0)
	    begin
			select p.ProductsID,p.pName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select ProductsID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(DAY,sDateTime,@dtmBdate)=0 group by ProductsID) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 order by p.ProductsID asc
	    end
	     --按周
	    if(@inycheckValue=1)
	    begin
			select p.ProductsID,p.pName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select ProductsID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(WEEK,sDateTime,@dtmBdate)=0 group by ProductsID) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 order by p.ProductsID asc
	    end
	     --按月
	    if(@inycheckValue=2)
	    begin
			select p.ProductsID,p.pName,isnull(pp.sNum,0) as sNum,isnull(pp.sPrice,0) as sPrice from(
			select ProductsID,isnull(sum(sNum),0) as sNum,isnull(sum(sPrice),0) as sPrice 
			from tbSalesInfo where DATEDIFF(MONTH,sDateTime,@dtmBdate)=0 group by ProductsID) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 order by p.ProductsID asc
	    end
	   end  
	--品牌
	  if(@inyType=5)
	  begin
	    --按日
	    if(@inycheckValue=0)
	    begin
	        select p.pBrand,isnull(sum(pp.sNum),0) as sNum,isnull(sum(pp.sPrice),0) as sPrice from(
			select ProductsID,isnull(sNum,0) as sNum,isnull(sPrice,0) as sPrice 
			from tbSalesInfo  where DATEDIFF(DAY,sDateTime,@dtmBdate)=0) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 group by p.pBrand order by p.pBrand asc
	    end
	    --按周
	    if(@inycheckValue=1)
	    begin
	       select p.pBrand,isnull(sum(pp.sNum),0) as sNum,isnull(sum(pp.sPrice),0) as sPrice from(
			select ProductsID,isnull(sNum,0) as sNum,isnull(sPrice,0) as sPrice 
			from tbSalesInfo  where DATEDIFF(WEEK,sDateTime,@dtmBdate)=0) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 group by p.pBrand order by p.pBrand asc
	    end
	    --按月
	    if(@inycheckValue=2)
	    begin
	       select p.pBrand,isnull(sum(pp.sNum),0) as sNum,isnull(sum(pp.sPrice),0) as sPrice from(
			select ProductsID,isnull(sNum,0) as sNum,isnull(sPrice,0) as sPrice 
			from tbSalesInfo  where DATEDIFF(MONTH,sDateTime,@dtmBdate)=0) as pp right join  tbProductsInfo
			as p on p.ProductsID=pp.ProductsID where p.pState=0 group by p.pBrand order by p.pBrand asc
	    end
	  end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_VerifyOrder]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_VerifyOrder]
	(
	@OrderID int = 0
	)
AS
begin
	declare @OrderListID int;
	declare @OrderListIDNew int;
	update tbOrderInfo set oSteps=2 where OrderID=@OrderID ;
	declare ocur cursor for select OrderListID from tbOrderListInfo where OrderID=@OrderID and oWorkType=0;
	open ocur;
	FETCH NEXT FROM ocur INTO @OrderListID;
	WHILE @@FETCH_STATUS = 0
		begin

			insert into tbOrderListInfo(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,oWorkType,oAppendTime,IsGifts)
				select OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresSupplierID,IsPromotions,1,Getdate(),IsGifts from tbOrderListInfo where OrderID=@OrderID and OrderListID=@OrderListID ;
				SET @OrderListIDNew = SCOPE_IDENTITY();

				insert into tbOrderFieldValueInfo(OrderFieldID,OrderListID,oFieldValue,IsVerify,oAppendTime)
					select OrderFieldID,@OrderListIDNew,oFieldValue,1,getdate() from tbOrderFieldValueInfo where OrderListID=@OrderListID;

			FETCH NEXT FROM ocur INTO @OrderListID

		end
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标

end;
GO
/****** Object:  StoredProcedure [dbo].[sp_updateuserpassword]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_updateuserpassword]
	@UserID int,
	@uPWD char(32)
AS
UPDATE [tbUserInfo] SET [uPWD]=@uPWD WHERE [UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[sp_SyncSalesInfo]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SyncSalesInfo]
AS
BEGIN
declare @error int,@counts int
declare @temp int
declare @sStoresName varchar(128)
declare @StoresID int
declare @sProductsName varchar(128)
declare @ProductsID int

set @counts=0;
set @error=0;

	BEGIN TRAN --申明事务
	declare scur cursor for select SalesID,sStoresName from tbSalesInfo where StoresID=0 
    open scur 
		--开始循环游标变量
		FETCH NEXT FROM scur INTO @temp,@sStoresName
		WHILE @@FETCH_STATUS = 0
		begin
			if exists(select StoresID from tbStoresInfo where sName=@sStoresName)
			begin
				update tbSalesInfo set tbSalesInfo.StoresID=(select StoresID from tbStoresInfo where sName=@sStoresName) where tbSalesInfo.SalesID=@temp
				set @counts=@counts+1
			end

			
			set @error=@error+@@error
			FETCH NEXT FROM scur INTO @temp,@sStoresName
		end

	if @error=0--没有错误 统一提交事务
	 begin
		 commit tran--提交
	 end
	else
	 begin
		 rollback tran--回滚
	 end
	CLOSE scur--关闭游标
	DEALLOCATE scur--释放游标

	BEGIN TRAN --申明事务
	declare scur cursor for select SalesID,sProductsName from tbSalesInfo where ProductsID=0
    open scur 
		--开始循环游标变量
		FETCH NEXT FROM scur INTO @temp,@sProductsName
		WHILE @@FETCH_STATUS = 0
		begin

		if exists(select ProductsID from tbProductsInfo where pName=@sProductsName)
			begin
				update tbSalesInfo set tbSalesInfo.ProductsID=(select ProductsID from tbProductsInfo where pName=@sProductsName) where tbSalesInfo.SalesID=@temp
				set @counts=@counts+1
			end

			
			set @error=@error+@@error
			FETCH NEXT FROM scur INTO @temp,@sProductsName
		end

	if @error=0--没有错误 统一提交事务
	 begin
		 commit tran--提交
	 end
	else
	 begin
		 rollback tran--回滚
	 end
	CLOSE scur--关闭游标
	DEALLOCATE scur--释放游标


select @counts as counts,@error as error;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_SyncErpOrderInfo]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SyncErpOrderInfo]
AS
BEGIN
declare @error int,@counts int
declare @temp int,@tR_ID int

set @counts=0;
set @error=0;

	BEGIN TRAN --申明事务
	declare ocur cursor for select ErpOrderID,R_ID from tbErpOrderInfo 
    open ocur 
		--开始循环游标变量
		FETCH NEXT FROM ocur INTO @temp,@tR_ID
		WHILE @@FETCH_STATUS = 0
		begin
			update tbErpOrderInfo set tbErpOrderInfo.ProductsID=p.ProductsID 
				from tbProductsInfo as p 
				where p.pName=tbErpOrderInfo.P_NAME and tbErpOrderInfo.ErpOrderID=@temp
			
			if @tR_ID=4 or @tR_ID=8
			begin
				update tbErpOrderInfo set tbErpOrderInfo.StoresID=s.SupplierID 
					from tbSupplierInfo as s where s.sCode=tbErpOrderInfo.C_CODE and tbErpOrderInfo.ErpOrderID=@temp
			end
			else
			begin
			
				update tbErpOrderInfo set tbErpOrderInfo.StoresID=s.StoresID 
					from tbStoresInfo as s where s.sCode=tbErpOrderInfo.C_CODE and tbErpOrderInfo.ErpOrderID=@temp
					
			end

			update tbErpOrderInfo set tbErpOrderInfo.StaffID=s.StaffID 
				from tbStaffInfo as s where s.sName=tbErpOrderInfo.SA_NAME and tbErpOrderInfo.ErpOrderID=@temp
		
			set @counts=@counts+1
			set @error=@error+@@error
			FETCH NEXT FROM ocur INTO @temp,@tR_ID
		end

	if @error=0--没有错误 统一提交事务
	 begin
		 commit tran--提交
	 end
	else
	 begin
		 rollback tran--回滚
	 end
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标

select @counts as counts,@error as error;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_StorehouseStorageSynInfo]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 匹配门店中未匹配的数据
-- =============================================
CREATE PROCEDURE [dbo].[sp_StorehouseStorageSynInfo]	
AS
BEGIN
declare @error int
declare @counts int
declare @temp int
declare @pBarcode varchar(50)

set @counts=0;
set @error=0;
	BEGIN TRAN --申明事务
	declare scur cursor for select ProductsID from tbStoreStorehouseInfo where ProductsID=0
    open scur 
		--开始循环游标变量
		FETCH NEXT FROM scur INTO @temp
		WHILE @@FETCH_STATUS = 0 
		begin  
			update tbStoreStorehouseInfo  set tbStoreStorehouseInfo.ProductsID=p.ProductsID 
				from tbProductsInfo as p  
				where p.pName=tbStoreStorehouseInfo.pName or p.pBarcode=tbStoreStorehouseInfo.pBarcode
				
		    update tbStoreStorehouseInfo_calculate  set tbStoreStorehouseInfo_calculate.ProductsID=p.ProductsID 
				from tbProductsInfo as p  
				where p.pName=tbStoreStorehouseInfo_calculate.pName or p.pBarcode=tbStoreStorehouseInfo_calculate.pBarcode
			set @counts=@counts+1
			set @error=@error+@@error
			FETCH NEXT FROM scur INTO @temp
		end
	if @error=0--没有错误 统一提交事务
	 begin
		 commit tran--提交
	 end
	else
	 begin
		 rollback tran--回滚
	 end
	CLOSE scur--关闭游标
	DEALLOCATE scur--释放游标

   select @counts as counts,@error as error;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StorehouseProductsLoss]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 仓库产品报损数据统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_StorehouseProductsLoss]
	@dtmbDate datetime,      --开始日期
	@dtmeDate datetime,      --结束日期
	@inyAssociated int,      --联营 -1=包含；0=剔除；1=仅联营
	@inyStorageID int,       --仓库编号
	@inyExport int			 --导出标志
AS
BEGIN
    --联营：包含
    if(@inyAssociated=-1 and @inyExport>0)
    begin
	   select p.pBrand,p.pName,p.pBarcode,pp.ProductsID,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from(
	select pInfo.ProductsID,
       isnull(sum(pInfo.oQuantity),0)  as oQuantity,
       isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
       from (
	    select oli.ProductsID,
			   oi.OrderID,
			   oli.oQuantity
	    from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			  and oli.StorageID=@inyStorageID
			  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		  ) pInfo where pInfo.oQuantity <>0 group by pInfo.ProductsID) as pp left join tbProductsInfo as p 
		  on pp.ProductsID=p.ProductsID where p.pState=0 order by pp.oQuantity desc
	end
	--联营：剔除
	if(@inyAssociated=0 and @inyExport>0)
	begin
	     select p.pBrand,p.pName,p.pBarcode,pp.ProductsID,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from(
	select pInfo.ProductsID,
       isnull(sum(pInfo.oQuantity),0)  as oQuantity,
       isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
       from (
	    select oli.ProductsID,
			   oi.OrderID,
			   oli.oQuantity
	    from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			  and oli.StorageID=@inyStorageID
			  and oli.ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeDate)
			  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		  ) pInfo where pInfo.oQuantity <>0 group by pInfo.ProductsID) as pp left join tbProductsInfo as p 
		  on pp.ProductsID=p.ProductsID where p.pState=0 order by pp.oQuantity desc
	end
	--联营：仅包含
	if(@inyAssociated=1 and @inyExport>0)
	begin
	      select p.pBrand,p.pName,p.pBarcode,pp.ProductsID,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from(
	select pInfo.ProductsID,
       isnull(sum(pInfo.oQuantity),0)  as oQuantity,
       isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
       from (
	    select oli.ProductsID,
			   oi.OrderID,
			   oli.oQuantity
	    from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			  and oli.StorageID=@inyStorageID
			  and oli.ProductsID in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeDate)
			  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
		  ) pInfo where pInfo.oQuantity <>0 group by pInfo.ProductsID) as pp left join tbProductsInfo as p 
		  on pp.ProductsID=p.ProductsID where p.pState=0 order by pp.oQuantity desc
	end
	
	--导出数据：包含联营
	if(@inyAssociated=-1 and @inyExport=0)
    begin
     select si.sName,qq.pName,qq.pBrand,qq.pBarcode,qq.pToBoxNo,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from (
	  select pp.StorageID,p.pName,p.pBrand,p.pBarcode,p.pToBoxNo,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from (
	  select pInfo.StorageID,pInfo.ProductsID,
		   isnull(sum(pInfo.oQuantity),0)  as oQuantity,
		   isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
		   from (
			select oli.ProductsID,
				   oi.OrderID,
				   oli.oQuantity,
				   oli.StorageID
				  
			from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			
				  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
			  ) pInfo where pInfo.oQuantity <>0 group by pInfo.StorageID,pInfo.ProductsID)
			  as pp left join tbProductsInfo as p on pp.ProductsID=p.ProductsID where p.pState=0
			  ) as qq left join tbStorageInfo as  si on qq.StorageID=si.StorageID
			  order by qq.oQuantity desc
    end
    --导出数据：剔除联营
    if(@inyAssociated=0 and @inyExport=0)
    begin
     select si.sName,qq.pName,qq.pBrand,qq.pBarcode,qq.pToBoxNo,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from (
	  select pp.StorageID,p.pName,p.pBrand,p.pBarcode,p.pToBoxNo,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from (
	  select pInfo.StorageID,pInfo.ProductsID,
		   isnull(sum(pInfo.oQuantity),0)  as oQuantity,
		   isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
		   from (
			select oli.ProductsID,
				   oi.OrderID,
				   oli.oQuantity,
				   oli.StorageID
				  
			from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			and oli.ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeDate)
				  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
			  ) pInfo where pInfo.oQuantity <>0 group by pInfo.StorageID,pInfo.ProductsID)
			  as pp left join tbProductsInfo as p on pp.ProductsID=p.ProductsID where p.pState=0
			  ) as qq left join tbStorageInfo as  si on qq.StorageID=si.StorageID
			  order by qq.oQuantity desc
    end
     --导出数据：仅联营
    if(@inyAssociated=1 and @inyExport=0)
    begin
     select si.sName,qq.pName,qq.pBrand,qq.pBarcode,qq.pToBoxNo,isnull(qq.oQuantity,0) as oQuantity,isnull(qq.oMoney,0) as oMoney from (
	  select pp.StorageID,p.pName,p.pBrand,p.pBarcode,p.pToBoxNo,isnull(pp.oQuantity,0) as oQuantity,isnull(pp.oMoney,0) as oMoney from (
	  select pInfo.StorageID,pInfo.ProductsID,
		   isnull(sum(pInfo.oQuantity),0)  as oQuantity,
		   isnull(sum(dbo.fun_GetProductPriceXP(pInfo.ProductsID,@dtmbDate+' 00:00:00',@dtmeDate+' 23:59:59')*pInfo.oQuantity),0)  as oMoney
		   from (
			select oli.ProductsID,
				   oi.OrderID,
				   oli.oQuantity,
				   oli.StorageID
				  
			from  tbOrderInfo as oi left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
			where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
			and oli.ProductsID in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmeDate)
				  and oli.OrderID in (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate+' 00:00:00' and @dtmeDate+' 23:59:59')
			  ) pInfo where pInfo.oQuantity <>0 group by pInfo.StorageID,pInfo.ProductsID)
			  as pp left join tbProductsInfo as p on pp.ProductsID=p.ProductsID where p.pState=0
			  ) as qq left join tbStorageInfo as  si on qq.StorageID=si.StorageID
			  order by qq.oQuantity desc
    end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Stock_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Stock_analysis]
/*库存分析*/
	(
	@storageid int = 0,		--仓库
	@eDate datetime = null,	--结束时间,库存点
	@ProductID	int	=0		--产品编号
	)
	
AS
begin

/*
销售发货=1
销售退货=5
赠品=2
样品=3
代购=7
采购入库=4
采购退货=8
调拨=10
库存调整=9
坏货=6
*/

if @eDate = null
begin
	set @eDate = getdate();
end

/*产品动态成本*/
If object_id('tempdb..#ErpProductCostPrice_antmp') is  not null
Drop table #ErpProductCostPrice_antmp
--创建新临时表
Create table #ErpProductCostPrice_antmp (CostVelenceID int,ProductsID int,		--产品编号
					cPrice money,			--成本
					bdate datetime,			--开始时间
					edate datetime			--结束时间
				)
--产品变价后，产品成本列表
insert into #ErpProductCostPrice_antmp exec sp_GetProductCostValence;

If object_id('tempdb..#ErpStockData') is  not null
	Drop table #ErpStockData
	--创建新临时表
	Create table #ErpStockData (ProductsID int,S_QUANTITY int,sumPrice money,
						pName varchar(128),	
						pBarcode varchar(50),
						pBrand varchar(128),
						pStandard varchar(50),
						pUnits	varchar(50),
						pToBoxNo	int,
						pDoDayQuantity	decimal(18,2)
					)
if @storageid>0
begin

	insert into #ErpStockData(ProductsID,S_QUANTITY,sumPrice,pName,pBarcode,pBrand,pStandard,pUnits,pToBoxNo,pDoDayQuantity)
	select pp.ProductsID,isnull(tt.S_QUANTITY,0) as S_QUANTITY,isnull(tt.sumPrice,0) as sumPrice,pp.pName,pp.pBarcode,pp.pBrand,pp.pStandard,pp.pUnits,pp.pToBoxNo,pp.pDoDayQuantity from tbProductsInfo as pp left join (
		select t.ProductsID,isnull(sum(isnull(t.S_QUANTITY,0)),0) as S_QUANTITY,
		isnull(sum((case 
						when t.R_ID in(1,2,3,6,7,8) then t.Price
						when t.R_ID in(4,5) then t.Price
						else 0
					end)*isnull(t.S_QUANTITY,0)),0) sumPrice
		 from (
			select p.*,o.R_ID,
				isnull((case when o.R_ID in(1,2,3,6,7,8) then -o.S_QUANTITY
						when o.R_ID in(4,5) then o.S_QUANTITY	
					end),0) S_QUANTITY,o.storageid,(select cPrice from #ErpProductCostPrice_antmp where ProductsID=p.ProductsID and bdate<=@eDate and edate>=@eDate) Price
			 from tbErpOrderInfo as o INNER join tbProductsInfo as p on p.ProductsID=o.ProductsID where o.O_CREATETIME<=@eDate and o.storageid=@storageid
			 ) as t 
		 group by t.ProductsID
	 ) as tt on pp.ProductsID=tt.ProductsID;
	 
end
else
begin

	insert into #ErpStockData(ProductsID,S_QUANTITY,sumPrice,pName,pBarcode,pBrand,pStandard,pUnits,pToBoxNo,pDoDayQuantity)
	select pp.ProductsID,isnull(tt.S_QUANTITY,0) as S_QUANTITY,isnull(tt.sumPrice,0) as sumPrice,pp.pName,pp.pBarcode,pp.pBrand,pp.pStandard,pp.pUnits,pp.pToBoxNo,pp.pDoDayQuantity from tbProductsInfo as pp left join (
		select t.ProductsID,isnull(sum(isnull(t.S_QUANTITY,0)),0) as S_QUANTITY,
		isnull(sum((case 
			when t.R_ID in(1,2,3,6,7,8) then t.Price
			when t.R_ID in(4,5) then t.Price
			else 0
		end)*isnull(t.S_QUANTITY,0)),0) sumPrice
		 from (
			select p.*,o.R_ID,
				isnull((case when o.R_ID in(1,2,3,6,7,8) then -o.S_QUANTITY
						when o.R_ID in(4,5) then o.S_QUANTITY	
					end),0) S_QUANTITY,o.storageid,(select cPrice from #ErpProductCostPrice_antmp where ProductsID=p.ProductsID and bdate<=@eDate and edate>=@eDate) Price
			 from tbErpOrderInfo as o INNER join tbProductsInfo as p on p.ProductsID=o.ProductsID where o.O_CREATETIME<=@eDate 
			 ) as t 
		 group by t.ProductsID
	 ) as tt on pp.ProductsID=tt.ProductsID;
	 
end

	if @ProductID>0
	begin
	
		select s.*,isnull((select top 1 ssp.isOK from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),0) as isOK
					,isnull((select top 1 ssp.isBad from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),0) as isBad
					,isnull((select top 1 ssp.sAppendTime from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),DATEADD(mm,-1,getdate())) as sAppendTime from #ErpStockData as s where s.ProductsID=@ProductID order by s.S_QUANTITY desc;
					
	end
	else
	begin
	
		select s.*,isnull((select top 1 ssp.isOK from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),0) as isOK
					,isnull((select top 1 ssp.isBad from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),0) as isBad
					,isnull((select top 1 ssp.sAppendTime from tbStockProductInfo as ssp where ssp.ProductsID=s.ProductsID order by ssp.sAppendTime desc),DATEADD(mm,-1,getdate())) as sAppendTime from #ErpStockData as s order by s.S_QUANTITY desc;

	end

	Drop table #ErpProductCostPrice_antmp;
	Drop table #ErpStockData;
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Sales_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Sales_analysis] 
	@StoresID int = 0,			--门店客户编号
	@StaffID int = 0,			--业务员编号
	@StaffIDB int = 0,			--促销员编号
	@Brand varchar(128) = '',	--品牌名称,模糊
	@RegionID int = 0,			--地区编号
	@bDate datetime,			--开始时间
	@eDate datetime,			--结束时间
	@ShowType int = 1,			--显示类型,1=按门店,2=业务员,3=促销员,4=产品,5=品牌,6=系统
	@DateType int = 1,			--暂时无用
	@ProductID int = 0,			--产品编号
	@YHsysID int = 0			--系统编号
AS
BEGIN
SET NOCOUNT ON

declare @tSQL varchar(3000);	--临时sql
declare @tSQLwhere varchar(3000);
declare @tStaffStoresID int,@tStoresID int ,@tStaffID int ,@tsDateTime datetime,@tbDate datetime,@teDate datetime;
declare @AllSumValue money;

set @tSQL = '';
set @tSQLwhere = '';
set @AllSumValue = 0;

--删除原数据
If object_id('tempdb..#Sales_Staff_StoresData') is  not null
Drop table #Sales_Staff_StoresData
--创建新临时表
Create table #Sales_Staff_StoresData (StaffStoresID int,StoresID int,		--门店编号
					StaffID int,			--人员编号
					bdate datetime,			--上岗时间
					edate datetime,			--下岗时间
					StoresName varchar(128),	--门店名称
					StaffName varchar(50)			--人员名称
				)
--删除原数据
If object_id('tempdb..#Sales_Staff_StoresRegion') is  not null
Drop table #Sales_Staff_StoresRegion
--创建新临时表
Create table #Sales_Staff_StoresRegion (nodeid int,tname varchar(50),pnodeid int)

--删除原数据
If object_id('tempdb..#Sales_Staff_StoresSum') is  not null
Drop table #Sales_Staff_StoresSum
--创建新临时表
Create table #Sales_Staff_StoresSum (tName varchar(128),tValue money)

--删除原数据
If object_id('tempdb..#Sales_Staff_StoresSumB') is  not null
Drop table #Sales_Staff_StoresSumB
--创建新临时表
Create table #Sales_Staff_StoresSumB (tName varchar(128),tValue money,tValueB int)

--删除原数据
If object_id('tempdb..#Sales_Staff_StoresData_List') is  not null
Drop table #Sales_Staff_StoresData_List
--创建新临时表
Create table #Sales_Staff_StoresData_List (
					SalesID int,		--销售数据编号
					StoresID int,		--门店编号
					ProductsID int,		--产品
					StaffID int,			--人员编号
					sdate datetime,			--发生时间
					sNum int,				--数量
					sPrice money			--金额
				)
--删除原数据
If object_id('tempdb..#Sales_Staff_StoresData_ListB') is  not null
Drop table #Sales_Staff_StoresData_ListB
--创建新临时表
Create table #Sales_Staff_StoresData_ListB (
					SalesID int,		--销售数据编号
					StoresID int,		--门店编号
					ProductsID int,		--产品
					StaffID int,			--人员编号
					sdate datetime,			--发生时间
					sNum int,				--数量
					sPrice money			--金额
				)

	--指定门店,客户
	if @StoresID > 0 
		begin
			set @tSQLwhere = ' and s.StoresID='+CONVERT(varchar(50),@StoresID);
		end
	--指定地区
	if @RegionID > 0
		begin
			insert into #Sales_Staff_StoresRegion exec sp_GetRegionNodeTable @RegionID,'',0;
			set @tSQLwhere = @tSQLwhere + ' and s.StoresID in(select StoresID from tbStoresInfo where RegionID in(select nodeid from #Sales_Staff_StoresRegion))';
	
		end
	--指定业务员,取业务员各门店编号集合,去业务员各门店上岗时间集合
	if @StaffID > 0 
		begin
			
			--该人员所有上下岗记录
			insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList @StaffID,@tbDate,@teDate,1;
			
			--组织销售数据
			declare ocur cursor for select StoresID,StaffID,bdate,edate from #Sales_Staff_StoresData 
			open ocur
			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
			WHILE @@FETCH_STATUS = 0
			begin
				insert into #Sales_Staff_StoresData_List(SalesID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select s.SalesID,s.StoresID,s.ProductsID,ss.StaffID,s.sDateTime,s.sNum,s.sPrice 
					from tbSalesInfo s left join #Sales_Staff_StoresData ss on s.StoresID=ss.StoresID where s.StoresID=@tStoresID and s.sDateTime>=@tbDate and s.sDateTime<=@teDate
				
				FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
			end
			CLOSE ocur--关闭游标
			DEALLOCATE ocur--释放游标
			
			set @tSQLwhere = @tSQLwhere+' and s.SalesID in(select SalesID from #Sales_Staff_StoresData_List where sdate>='''+CONVERT(varchar(30),@bDate)+''' and sdate<='''+CONVERT(varchar(30),@edate)+''')';
		end
	
	--指定促销员
	if @StaffIDB > 0 
		begin
			
			--该人员所有上下岗记录
			insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList @StaffID,@tbDate,@teDate,2;
			
			--组织销售数据
			declare ocur cursor for select StoresID,StaffID,bdate,edate from #Sales_Staff_StoresData 
			open ocur
			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
			WHILE @@FETCH_STATUS = 0
			begin
				insert into #Sales_Staff_StoresData_List(SalesID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select s.SalesID,s.StoresID,s.ProductsID,ss.StaffID,s.sDateTime,s.sNum,s.sPrice 
					from tbSalesInfo s left join #Sales_Staff_StoresData ss on s.StoresID=ss.StoresID where s.StoresID=@tStoresID and s.sDateTime>=@tbDate and s.sDateTime<=@teDate
				
				FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
			end
			CLOSE ocur--关闭游标
			DEALLOCATE ocur--释放游标
			
			set @tSQLwhere = @tSQLwhere+' and s.SalesID in(select SalesID from #Sales_Staff_StoresData_List where sdate>='''+CONVERT(varchar(30),@bDate)+''' and sdate<='''+CONVERT(varchar(30),@edate)+''')';

		end
	if @Brand != '' 
		begin
			set @tSQLwhere = @tSQLwhere+' and s.ProductsID in(select ProductsID from tbProductsInfo where pBrand like ''%'+CONVERT(varchar(128),@Brand)+'%'')'
		end
	if @ProductID > 0
		begin
			set @tSQLwhere = @tSQLwhere+' and s.ProductsID='+CONVERT(varchar(50),@ProductID);
		end
	if @YHsysID >0 
		begin
			set @tSQLwhere = @tSQLwhere+' and s.StoresID in(select StoresID from tbStoresInfo where YHsysID='++CONVERT(varchar(50),@YHsysID)+')';
		end
		
	if @ShowType = 1
	begin		
		set @tSQL = 'select si.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue '+
					'from tbStoresInfo as si left join tbSalesInfo as s on si.StoresID=s.StoresID '+
					'where s.sIsYH=1 '+ @tSQLwhere +' and s.sDateTime>='''+CONVERT(varchar(30),@bDate,120)+''' and s.sDateTime<='''+CONVERT(varchar(30),@eDate,120)+''' '+
					'group by si.sName order by tvalue desc';
	end

	if @ShowType = 2
	begin
		--所有人员所有上下岗记录
		delete #Sales_Staff_StoresData;
		
		insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList 0,@tbDate,@teDate,1;

		--组织销售数据
		declare ocur cursor for select StoresID,StaffID,bdate,edate from #Sales_Staff_StoresData 
		open ocur
		FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		WHILE @@FETCH_STATUS = 0
		begin
			insert into #Sales_Staff_StoresData_ListB(SalesID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
				select s.SalesID,s.StoresID,s.ProductsID,ss.StaffID,s.sDateTime,s.sNum,s.sPrice 
				from tbSalesInfo s left join #Sales_Staff_StoresData ss on s.StoresID=ss.StoresID where s.StoresID=@tStoresID and s.sDateTime>=@tbDate and s.sDateTime<=@teDate
			
			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		--select * from #Sales_Staff_StoresData_ListB
		set @tSQL = 'select sf.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue '+
					'from tbStaffInfo sf left join #Sales_Staff_StoresData_ListB as s on sf.StaffID=s.StaffID '+
					'where s.SalesID<>0 '+ @tSQLwhere +' and sf.sType=1 and s.sdate>='''+CONVERT(varchar(30),@bDate,120)+''' and s.sdate<='''+CONVERT(varchar(30),@eDate,120)+''' '+
					'group by sf.sName order by tvalue desc';
	end

	if @ShowType = 3
	begin
		--所有人员所有上下岗记录
		delete #Sales_Staff_StoresData;
		
		insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList 0,@tbDate,@teDate,2;
		--组织销售数据
		declare ocur cursor for select StoresID,StaffID,bdate,edate from #Sales_Staff_StoresData 
		open ocur
		FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		WHILE @@FETCH_STATUS = 0
		begin
			insert into #Sales_Staff_StoresData_ListB(SalesID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
				select s.SalesID,s.StoresID,s.ProductsID,ss.StaffID,s.sDateTime,s.sNum,s.sPrice 
				from tbSalesInfo s left join #Sales_Staff_StoresData ss on s.StoresID=ss.StoresID where s.StoresID=@tStoresID and s.sDateTime>=@tbDate and s.sDateTime<=@teDate
			
			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
	
		set @tSQL = 'select sf.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue '+
					'from tbStaffInfo sf left join #Sales_Staff_StoresData_ListB as s on sf.StaffID=s.StaffID '+
					'where s.SalesID<>0 '+ @tSQLwhere +' and sf.sType=2 and s.sdate>='''+CONVERT(varchar(30),@bDate,120)+''' and s.sdate<='''+CONVERT(varchar(30),@eDate,120)+''' '+
					'group by sf.sName order by tvalue desc';
	end

	if @ShowType = 4
	begin
		set @tSQL = 'select p.pName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue,isnull(sum(isnull(s.sNum,0)),0) as tvalueb '+
				'from tbProductsInfo as p left join tbSalesInfo as s on p.ProductsID=s.ProductsID '+
				'where s.sIsYH=1 '+ @tSQLwhere +' and s.sDateTime>='''+CONVERT(varchar(30),@bDate)+''' and s.sDateTime<='''+CONVERT(varchar(30),@eDate)+''' '+
				'group by p.pName order by tvalue desc';
		
	end

	if @ShowType = 5
	begin
		set @tSQL = 'select pp.pBrand,isnull(sum(isnull(pp.tvalue,0)),0) as tvalue from viProductBrand as vp left join (select p.pName,p.pBrand,sum(isnull(s.sPrice,0)) as tvalue '+
				'from tbProductsInfo as p left join tbSalesInfo as s on p.ProductsID=s.ProductsID '+
				'where s.sIsYH=1 '+ @tSQLwhere +' and s.sDateTime>='''+CONVERT(varchar(30),@bDate)+''' and s.sDateTime<='''+CONVERT(varchar(30),@eDate)+''' '+
				'group by p.pName,p.pBrand) as pp on vp.pBrand=pp.pBrand group by pp.pBrand order by tvalue desc';
		
	end
	if @ShowType = 6
	begin
		set @tSQL = 'select y.yName,isnull(sum(isnull(sss.tvalue,0)),0) as tvalue,(select count(0) from tbStoresInfo where tbStoresInfo.YHsysID=y.YHsysID) as StoresCount from tbYHsysInfo as y left join (select si.StoresID,si.YHsysID,isnull(sum(isnull(s.sPrice,0)),0) as tvalue '+
					'from tbStoresInfo as si left join tbSalesInfo as s on si.StoresID=s.StoresID '+
					'where s.sIsYH=1 '+ @tSQLwhere +' and s.sDateTime>='''+CONVERT(varchar(30),@bDate,120)+''' and s.sDateTime<='''+CONVERT(varchar(30),@eDate,120)+''' '+
					'group by si.StoresID,si.YHsysID) as sss on y.YHsysID=sss.YHsysID group by y.yName,y.YHsysID order by tvalue desc';
	end

	if @tSQL!=''
	begin
		if @DateType=0
		begin
			exec(@tSQL);
		end
		else
		begin
			if @ShowType=4 or @ShowType=6
			begin
				exec('insert into #Sales_Staff_StoresSumB '+@tSQL);
				select @AllSumValue=isnull(sum(isnull(tValue,0)),0) from #Sales_Staff_StoresSumB;
				select @AllSumValue as AllSumValue;
			end
			else
			begin
				exec('insert into #Sales_Staff_StoresSum '+@tSQL);
				select @AllSumValue=isnull(sum(isnull(tValue,0)),0) from #Sales_Staff_StoresSum;
				select @AllSumValue as AllSumValue;
			end
			exec(@tSQL);
		end
		
		
	end

Drop table #Sales_Staff_StoresData
Drop table #Sales_Staff_StoresRegion
Drop table #Sales_Staff_StoresSum
Drop table #Sales_Staff_StoresSumB
Drop table #Sales_Staff_StoresData_List
Drop table #Sales_Staff_StoresData_ListB

return @AllSumValue;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Customers_DataAnlysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Customers_DataAnlysis]
	(
	@ShowType int = 1,				--显示类型,1=按客户,2=业务员,3=促销员,4=产品,5=品牌(产品分类),6=系统,7=客户与商品
	@bDate datetime,				--开始时间
	@eDate datetime,				--结束时间
	@storesID int,					--门店编号
	@isIsPool int=0					--是否为联营,0=全部,1=仅联营,2=排除联营
	)
AS
begin

declare @tStoresID int;
declare @tStaffID int;
declare @tbDate datetime;
declare @teDate datetime;


--临时表用于合计
If object_id('tempdb..#Customers_DataAnlysis_ListA') is  not null
Drop table #Customers_DataAnlysis_ListA
--创建新临时表
Create table #Customers_DataAnlysis_ListA (
					sName varchar(128),
					tName varchar(128),		--对象名
					tMoney money,			--金额
					tNum int
				)

--人员销售数据临时表
If object_id('tempdb..#Sales_Staff_StoresData_List') is  not null
Drop table #Sales_Staff_StoresData_List
--创建新临时表
Create table #Sales_Staff_StoresData_List (
					SalesID int,		--销售数据编号
					StoresID int,		--门店编号
					ProductsID int,		--产品
					StaffID int,			--人员编号
					sdate datetime,			--发生时间
					sNum int,				--数量
					sPrice money			--金额
				)

set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');
set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

	--按客户统计
	if @ShowType=1
	begin
		delete #Customers_DataAnlysis_ListA;
		
		if @isIsPool = 0
		begin
			insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select si.sName,si.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
						where (s.sDateTime BETWEEN  @bDate and @eDate) group by si.sName order by tvalue desc;
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select si.sName,si.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
						where (s.sDateTime BETWEEN  @bDate and @eDate) 
						and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
						group by si.sName order by tvalue desc;
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select si.sName,si.sName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
						where (s.sDateTime BETWEEN  @bDate and @eDate) 
						and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
						group by si.sName order by tvalue desc;
			end
		end
		select tName,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
	end

	--按业务员统计
	if @ShowType=2
	begin
		delete #Customers_DataAnlysis_ListA;

	if @isIsPool = 0
	begin
		insert into #Customers_DataAnlysis_ListA(si.sName,tName,tMoney,tNum)

		select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
			select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
			select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
				from tbSalesInfo s 
			where (s.sdatetime BETWEEN @bDate and @eDate) 
			) as sss group by sss.StaffID
		) as ssss on ssss.StaffID = sf.StaffID where sf.stype=1 order by  ssss.tvalue desc
	end
	else
	begin
		if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(si.sName,tName,tMoney,tNum)
				select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
					select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
					select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
						from tbSalesInfo s 
					where (s.sdatetime BETWEEN @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
					) as sss group by sss.StaffID
				) as ssss on ssss.StaffID = sf.StaffID where sf.stype=1 order by  ssss.tvalue desc
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(si.sName,tName,tMoney,tNum)
				select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
					select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
					select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=1 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
						from tbSalesInfo s 
					where (s.sdatetime BETWEEN @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
					) as sss group by sss.StaffID
				) as ssss on ssss.StaffID = sf.StaffID where sf.stype=1 order by  ssss.tvalue desc
			end
	end
		select tName,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
	end
	--按促销员统计
	if @ShowType=3
	begin
		delete #Customers_DataAnlysis_ListA;

		if @isIsPool = 0
		begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				
				select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
					select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
					select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
						from tbSalesInfo s 
					where (s.sdatetime BETWEEN @bDate and @eDate) 
					) as sss group by sss.StaffID
				) as ssss on ssss.StaffID = sf.StaffID where sf.stype=2 order by  ssss.tvalue desc
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				
				select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
					select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
					select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
						from tbSalesInfo s 
					where (s.sdatetime BETWEEN @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
					) as sss group by sss.StaffID
				) as ssss on ssss.StaffID = sf.StaffID where sf.stype=2 order by  ssss.tvalue desc
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				
				select '',sf.sname,isnull(ssss.tvalue,0) tvalue,0 from tbStaffInfo sf left join (
					select isnull(sum(isnull(sss.sprice,0)),0) tvalue,sss.staffid  from (
					select s.sprice,(select top 1 ss.StaffID from tbSales_Staff_StoresDataInfo ss left join tbStaffInfo _ss on ss.StaffID=_ss.StaffID where _ss.stype=2 and ss.StoresID=s.StoresID and s.sdatetime BETWEEN ss.bdate and ss.edate) as StaffID 
						from tbSalesInfo s 
					where (s.sdatetime BETWEEN @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
					) as sss group by sss.StaffID
				) as ssss on ssss.StaffID = sf.StaffID where sf.stype=2 order by  ssss.tvalue desc
			end
		end
		
		select tName,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
	end

	--按产品统计
	if @ShowType=4
	begin
		delete #Customers_DataAnlysis_ListA;

		if @isIsPool = 0
		begin
			insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select '',p.pName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
						where (s.sDateTime BETWEEN  @bDate and @eDate) group by p.pName order by tvalue desc;
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select '',p.pName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
						where (s.sDateTime BETWEEN  @bDate and @eDate)
						and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
						 group by p.pName order by tvalue desc;
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select '',p.pName,isnull(sum(isnull(s.sPrice,0)),0) as tvalue ,0
					from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
						where (s.sDateTime BETWEEN  @bDate and @eDate)
						and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
						 group by p.pName order by tvalue desc;
			end
		end
		select tName,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
	end
	--按产品分类统计
	if @ShowType=5
	begin
		delete #Customers_DataAnlysis_ListA;
		if @isIsPool = 0
		begin
			insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
			select '',pc.pClassName,isnull(ps.tvalue,0) as tvalue,0 from tbProductClassInfo pc left join (
				select p.ProductClassID,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
					from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
						where  (s.sDateTime BETWEEN  @bDate and @eDate) group by p.ProductClassID
						) as ps on pc.ProductClassID=ps.ProductClassID and pc.pparentid>=0 order by tvalue desc;
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select '',pc.pClassName,isnull(ps.tvalue,0) as tvalue,0 from tbProductClassInfo pc left join (
					select p.ProductClassID,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
							where  (s.sDateTime BETWEEN  @bDate and @eDate)
							and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
							 group by p.ProductClassID
							) as ps on pc.ProductClassID=ps.ProductClassID and pc.pparentid>=0 order by tvalue desc;
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				select '',pc.pClassName,isnull(ps.tvalue,0) as tvalue,0 from tbProductClassInfo pc left join (
					select p.ProductClassID,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbProductsInfo as p right join tbSalesInfo as s on p.ProductsID=s.ProductsID
							where  (s.sDateTime BETWEEN  @bDate and @eDate)
							and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
							 group by p.ProductClassID
							) as ps on pc.ProductClassID=ps.ProductClassID and pc.pparentid>=0 order by tvalue desc;
			end
		end
		select tName,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
	end
    
    --按客户商品统计
    if @ShowType=7 and @storesID>0
    begin
		delete #Customers_DataAnlysis_ListA;
		if @isIsPool = 0
		begin
			insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
			   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
				select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
					from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
						where (s.sDateTime BETWEEN  @bDate and @eDate)
						 and si.StoresID=@storesID group by si.sName,s.ProductsID) as mm
						  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
							 order by tvalue desc
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
					select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
							where (s.sDateTime BETWEEN  @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
							 and si.StoresID=@storesID group by si.sName,s.ProductsID) as mm
							  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
								 order by tvalue desc
			end
			else
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
					select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
							where (s.sDateTime BETWEEN  @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
							 and si.StoresID=@storesID group by si.sName,s.ProductsID) as mm
							  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
								 order by tvalue desc
			end
		end
		
		select sName,tName,tNum,tMoney from #Customers_DataAnlysis_ListA;
		select sum(tMoney) from #Customers_DataAnlysis_ListA;
    end
    
    --导出数据
    if @ShowType=7 and @storesID=0
    begin
		delete #Customers_DataAnlysis_ListA;
		if @isIsPool = 0
		begin
			insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
			   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
				select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
					from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
						where (s.sDateTime BETWEEN  @bDate and @eDate) group by si.sName,s.ProductsID) as mm
						  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
							order by sName desc
		end
		else
		begin
			if @isIsPool = 1
			begin
				insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
					select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
							where (s.sDateTime BETWEEN  @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=1
							 group by si.sName,s.ProductsID) as mm
							  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
								order by sName desc
			end
			else
			begin
					insert into #Customers_DataAnlysis_ListA(sName,tName,tMoney,tNum)
				   select mm.sName,p.pName,isnull(mm.tvalue,0),isnull(mm.sNum,0) from(
					select si.sName,s.ProductsID,isnull(sum(s.sNum),0) as sNum,isnull(sum(isnull(s.sPrice,0)),0) as tvalue 
						from tbStoresInfo as si right join tbSalesInfo as s on si.StoresID=s.StoresID
							where (s.sDateTime BETWEEN  @bDate and @eDate) and [dbo].[fun_CheckProductIsPool](s.ProductsID,s.sDateTime)=0
							 group by si.sName,s.ProductsID) as mm
							  left join tbProductsInfo as p on p.ProductsID=mm.ProductsID  where p.pState=0
								order by sName desc
			end
		end
		
		select sName,tName,tNum,tMoney from #Customers_DataAnlysis_ListA;
    end

	Drop table #Customers_DataAnlysis_ListA;
	Drop table #Sales_Staff_StoresData_List;

end
GO
/****** Object:  StoredProcedure [dbo].[sp_CostOfGifts_Details]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YANGANGOL
-- Create date: 2011-6-21
-- Description:	赠品费用明细统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_CostOfGifts_Details]
	@inysID int, 
	@inypID int,
	@dtmBdate datetime,
	@dtmEdate datetime
	
AS
    set @dtmBdate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmBdate))+'-'+convert(varchar,DATEPART(MONTH,@dtmBdate))+'-'+convert(varchar,DATEPART(DAY,@dtmBdate))+' 00:00:00')
    set @dtmEdate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmEdate))+'-'+convert(varchar,DATEPART(MONTH,@dtmEdate))+'-'+convert(varchar,DATEPART(DAY,@dtmEdate))+' 23:59:59')

	 --赠品单数量
    declare @tbGiveNum table(
							storesID int,
							productID int,
							giveNum int,
							pAppendTime datetime
    )
    --销售赠品数量
    declare @tbListGiveNum table(
						    storesID int,
							productID int,
							giveListNum int,
							pAppendTime datetime
    
    )


	--找到赠品单数量及成本
	insert into @tbGiveNum(storesID,productID,giveNum,pAppendTime)
	
	select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity,
	 (select pAppendTime from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate and OrderID=oi.OrderID) as pAppendTime
	 from tbOrderInfo as oi 
	left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
	where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oi.StoresID=@inysID and oli.ProductsID=@inypID and  oi.OrderID
	  in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate)
	   order by oi.StoresID,oli.ProductsID asc
	   
	 
    
	--找到销售单赠品数量及成本
	insert into @tbListGiveNum(storesID,productID,giveListNum,pAppendTime)
	  select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as SoQuantity,
	  (select pAppendTime from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate and OrderID=oi.OrderID) as pAppendTime
	   from tbOrderInfo as oi 
		 left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		   where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oi.StoresID=@inysID and oli.ProductsID=@inypID and oli.IsGifts <>0  and  oi.OrderID
			  in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate)
           order by oi.StoresID,oli.ProductsID asc

BEGIN
	
	select p.ProductsID,isnull(gm.giveNum,0) as oQuantity,isnull(gml.giveListNum,0) as SoQuantity
	,isnull((isnull(gm.giveNum,0)+isnull(gml.giveListNum,0))*dbo.fun_GetProductPriceXP(p.ProductsID,@dtmBdate,@dtmEdate),0) as oMoney 
	,convert(varchar,datepart(year,gm.pAppendTime))+'-'+convert(varchar,datepart(MONTH,gm.pAppendTime))+'-'+convert(varchar,datepart(DAY,gm.pAppendTime)) as gAppendTime
	,convert(varchar,datepart(year,gml.pAppendTime))+'-'+convert(varchar,datepart(MONTH,gml.pAppendTime))+'-'+convert(varchar,datepart(DAY,gml.pAppendTime)) as zpAppendTime
	from  tbProductsInfo as p 
	 left join(
	    select productID,giveNum,pAppendTime from @tbGiveNum ) as gm
	  
	  on gm.productID=p.ProductsID 
	 left join(
		select productID,giveListNum,pAppendTime from @tbListGiveNum) as gml
	  on gml.productID=p.ProductsID
	 where p.pState=0 and gm.giveNum<>0 or gml.giveListNum<>0

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CostDetailsOfGifts]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YANGANGOL	
-- Create date: 2011-6-21
-- Description:	赠品费用统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_CostDetailsOfGifts] 
	@dtmBdate  datetime,     --开始日期
	@dtmEdate  datetime      --结束日期           
AS
    set @dtmBdate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmBdate))+'-'+convert(varchar,DATEPART(MONTH,@dtmBdate))+'-'+convert(varchar,DATEPART(DAY,@dtmBdate))+' 00:00:00')
    set @dtmEdate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmEdate))+'-'+convert(varchar,DATEPART(MONTH,@dtmEdate))+'-'+convert(varchar,DATEPART(DAY,@dtmEdate))+' 23:59:59')
    
    --赠品单数量
    declare @tbGiveNum table(
							storesID int,
							productID int,
							giveNum int
    )
    --销售赠品数量
    declare @tbListGiveNum table(
						    storesID int,
							productID int,
							giveListNum int
    
    )


	--找到赠品单数量及成本
	insert into @tbGiveNum(storesID,productID,giveNum)
	
	select oi.StoresID,oli.ProductsID,isnull(sum(oli.oQuantity),0) as oQuantity from tbOrderInfo as oi 
	left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
	where oi.oType=5 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2  and  oi.OrderID
	  in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate)
	   group by oi.StoresID,oli.ProductsID order by oi.StoresID,oli.ProductsID asc
	   
	 
    
	--找到销售单赠品数量及成本
	insert into @tbListGiveNum(storesID,productID,giveListNum)
	  select oi.StoresID,oli.ProductsID,isnull(sum(oli.oQuantity),0) as SoQuantity from tbOrderInfo as oi 
		 left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		   where oi.oType=3 and oi.oState=0 and oi.oSteps>=4 and oli.oWorkType=2 and oli.IsGifts <>0  and  oi.OrderID
			  in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmBdate and @dtmEdate)
           group by oi.StoresID,oli.ProductsID order by oi.StoresID,oli.ProductsID asc

BEGIN
	   select COUNT(si.StoresID) as s_count,si.StoresID,si.sName,si.ProductsID,si.pName,si.pBarcode
	     ,isnull(zp.giveNum,0) as oQuantity,isnull(zpd.giveListNum,0) as SoQuantity,
	     (isnull(zp.giveNum,0)+isnull(zpd.giveListNum,0))*dbo.fun_GetProductPriceXP(si.ProductsID,@dtmBdate,@dtmEdate) oMoney
	    from
       (select _s.StoresID,_s.sName,_p.ProductsID,_p.pName,_p.pBarcode from tbStoresInfo _s,tbProductsInfo _p) as si 
       left join(
		 select storesID,productID,sum(giveNum) as giveNum from @tbGiveNum group by storesID,productID
       ) as zp on si.StoresID=zp.storesID and zp.productID=si.ProductsID
       left join(
		 select storesID,productID,sum(giveListNum) as giveListNum from @tbListGiveNum group by storesID,productID
       ) as zpd on si.StoresID=zpd.storesID and si.ProductsID=zpd.productID
       
       where zp.giveNum <>0 or zpd.giveListNum <>0 group by si.StoresID,si.sName,si.ProductsID,si.pName,si.pBarcode
       ,zp.giveNum,zpd.giveListNum  order by si.StoresID asc
       

END
GO
/****** Object:  StoredProcedure [dbo].[sp_certificate_summary]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 凭证汇总
-- =============================================
CREATE PROCEDURE [dbo].[sp_certificate_summary]
	@bDate datetime = null,		--开始时间
	@eDate datetime = null		--结束时间
AS
BEGIN
	
	set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');
	set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

	--所有时间段内数据
	declare @CertificateDataList Table(
				keyid int primary key IDENTITY(1,1),
				CertificateDataID int ,
				CertificateID int,
				FeesSubjectID int,
				FeesSubjectClassIDParentID int,
				cdMoney numeric(18,6),
				cdMoneyB numeric(18,6),
				cCode varchar(50),
				cDateTime datetime,
				cSteps int
			);
			
	insert into @CertificateDataList(CertificateDataID,CertificateID,FeesSubjectID,cdMoney,cdMoneyB,cCode,cDateTime,cSteps,FeesSubjectClassIDParentID)		
	select cd.CertificateDataID,cd.CertificateID,cd.FeesSubjectID,cd.cdMoney,cd.cdMoneyB,c.cCode,c.cDateTime,c.cSteps,
	(select nextnodeid from dbo.fun_GetFeesSubjectNodeTable(cd.FeesSubjectID,null,1) where nodeid=0)
	 from tbCertificateDataInfo cd left join tbCertificateInfo c on c.CertificateID=cd.CertificateID
		where (c.cDateTime between @bDate and @eDate) and c.cSteps=1 and c.cState=0 ;
	
	
	select @bDate as bDate,@eDate as eDate,--时间
	(select COUNT(0) from tbCertificateInfo where (cDateTime between @bDate and @eDate) and cSteps=1 and cState=0 ) as cCount,--凭证数
	(select top 1 cCode from tbCertificateInfo where (cDateTime between @bDate and @eDate) and cSteps=1 and cState=0 order by CertificateID asc) as bCode,--开始凭证号
	(select top 1 cCode from tbCertificateInfo where (cDateTime between @bDate and @eDate) and cSteps=1 and cState=0 order by CertificateID desc) as eCode;--结束凭证号

	
	select f.FeesSubjectClassID,f.cCode,f.cClassName,isnull(cc.cdMoney,0) cdMoney,isnull(cc.cdMoneyB,0) cdMoneyB from tbFeesSubjectClassInfo as f left join
	(select FeesSubjectClassIDParentID,SUM(isnull(cdMoney,0)) cdMoney,SUM(isnull(cdMoneyB,0)) cdMoneyB
	 from @CertificateDataList as c group by FeesSubjectClassIDParentID	) as cc on f.FeesSubjectClassID=cc.FeesSubjectClassIDParentID
	where cParentID=0
	order by f.FeesSubjectClassID,f.cOrder desc;

	
	
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[fun_GetProductInOutByDate]    Script Date: 10/11/2016 09:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fun_GetProductInOutByDate]
(	
	@bdT datetime,		--开始时间
	@edT datetime,		--结束时间
	@sDataType int		--统计数据方式,0=取上期结存成本,1=取本期发生成本
)
RETURNS TABLE 
AS

RETURN 
(
	select ps.*,
		isnull(
		--case when ISNULL(ProductInAll.SumQuantity,0)<>0 then
		--	(ISNULL(ProductInAll.SumMoney,0)/ISNULL(ProductInAll.SumQuantity,0))*isnull(ProductIn.oQuantity,0)
		--else
		--	0
		--end
		ProductIn.oMoney
		,0) as InMoney,
		isnull(ProductIn.oQuantity,0) as InQuantity,
		--0 as OutMoney,
		isnull(ProductOut.sumCost,0) as OutMoney,
		isnull(ProductOut.oQuantity,0) as OutQuantity,
		ISNULL(ProductInAll.SumQuantity,0) as AllQuantity ,
		ISNULL(ProductInAll.SumMoney,0) as AllMoney 
	from 
	(
		select p.*,s.StorageID from tbProductsInfo as p ,tbStorageInfo as s where p.pState=0
	) as ps left join
	(
	--入库
	select ol.ProductsID,ol.StorageID,isnull(sum(
	case o.oType
		when 2 then 0-ol.oQuantity -- 退货
		
		else ol.oQuantity
	end),0) as oQuantity,
	SUM(isnull(
	case o.oType
		when 2 then (0-ol.oQuantity)*ol.oPrice -- 退货
		when 9 then ol.oQuantity*dbo.fun_GetProductPriceXP(ol.ProductsID,@bdT,@edT)--库存调拨,同期成本
		else ol.oQuantity*ol.oPrice
	end
	,0)) as oMoney
	 from tbOrderListInfo as ol left join tbOrderInfo as o on ol.OrderID=o.OrderID 
		where ol.oWorkType>=1 and o.oType in(1,2,8,9) and oSteps>=4 and o.oState=0 and
			o.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and pAppendTime between @bdT and @edT)
		group by ol.ProductsID,ol.StorageID
	) as ProductIn on ps.ProductsID = ProductIn.ProductsID and ps.StorageID = ProductIn.StorageID
	left join
	(
	--总入库
	select tol.ProductsID,
			isnull(SUM(
			case too.oType
				when 2 then 0-tol.oQuantity
				else tol.oQuantity
			end),0) as  SumQuantity,
			isnull(SUM(
			case too.oType
				when 2 then (0-tol.oQuantity)*tol.oPrice 
				else tol.oQuantity*tol.oPrice 
			end),0) as SumMoney
			from tbOrderListInfo as tol left join tbOrderInfo as too on too.OrderID=tol.OrderID left join tbOrderWorkingLogInfo toow on too.OrderID=toow.OrderID 
			where tol.oWorkType>=1 and too.oType in(1,2) and too.oSteps>=4 and too.oState=0 and toow.oType=4 and toow.pAppendTime between @bdT and @edT
			group by tol.ProductsID
	) as ProductInAll on ps.ProductsID = ProductInAll.ProductsID
	left join 
	(
	--出库
	select ol.ProductsID,ol.StorageID,isnull(sum(
	case o.oType
		when 4 then 0-ol.oQuantity -- 退货
		
		else ol.oQuantity
	end),0) as oQuantity,
	isnull(sum(
	case o.oType
		when 4 then 0-ol.oQuantity -- 退货
		else ol.oQuantity
	end)*dbo.fun_GetProductPrice(ol.ProductsID,ol.StorageID,@bdT,@edT,1,0,@sDataType),0) as sumCost,--按月成本计算
	SUM(isnull(ol.oMoney,0)) as oMoney from tbOrderListInfo as ol left join tbOrderInfo as o on ol.OrderID=o.OrderID 
		where ol.oWorkType>=1 and o.oType in(3,4,5,6,7,10) and oSteps>=3 and  o.oState=0 and
			o.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and pAppendTime between @bdT and @edT)
		group by ol.ProductsID,ol.StorageID
	) as ProductOut on ps.ProductsID =ProductOut.ProductsID  and ps.StorageID=ProductOut.StorageID
)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStorehouseLossDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
--对仓库报损产品进行统计
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStorehouseLossDetails]
	@dtmbDate   datetime,      --开始日期参数
	@dtmeDate   datetime,      --结束日期参数
	@inypID     int,           --产品编号
	@inysID     int            --门店编号
AS
BEGIN
	select oi.OrderID,oi.oOrderNum,oi.oOrderDateTime,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oQuantity*dbo.fun_GetProductPriceXP(@inypID,@dtmbDate,@dtmeDate),0) as oMoney,
	(select pAppendTime from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate and OrderID=oi.OrderID) as oAppendTime from tbOrderInfo  as oi left join tbOrderListInfo as oli 
	on oi.OrderID=oli.OrderID  where oi.oType=10 and oi.oState=0 and oli.oWorkType=2
	and oli.ProductsID=@inypID
	and oli.StorageID=@inysID
	and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
	order by oi.oAppendTime desc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductLogDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductLogDetails] 
		@bDate datetime,		--开始时间
		@eDate datetime,		--结束时间
		@ProductsID int=0,	--产品
		@CostPrice int=1,	--是否计算成本,0=显示,1=不显示
		
		@StorageID int=0	--仓库编号
AS
BEGIN
	declare @Product_UPYear numeric(18,6)=0;	--上年结转数量
	--整理查询单据
	declare @OrderList Table(
				OrderID int ,
				oOrderNum varchar(50),
				StorageID int,
				ProductsID int,
				oQuantity numeric(18,6),
				oPrice numeric(18,6),
				oMoney numeric(18,6),
				StoresID int,
				StoresSupplierID int,
				oType int,
				oOrderDateTime datetime,
				oWorkingDateTime datetime,
				IsGifts	int,
				StaffID int,
				oCustomersName varchar(128),
				oState int,
				owYear int,
				owMonth int,
				owDay int
			);
	
	--上期结存
	declare @OrderList_b Table(
				StorageID int,
				ProductsID int,
				oQuantity numeric(18,6),
				oPrice numeric(18,6),
				oMoney numeric(18,6),
				StoresID int,
				StoresSupplierID int,
				oType int,
				oOrderDateTime datetime,
				oWorkingDateTime datetime,
				IsGifts	int,
				StaffID int,

				oState int
			);
	
	--年累计，截止查询开始时间
	declare @OrderList_c Table(
				OrderID int ,
				oOrderNum varchar(50),
				StorageID int,
				ProductsID int,
				oQuantity numeric(18,6),
				oPrice numeric(18,6),
				oMoney numeric(18,6),
				StoresID int,
				StoresSupplierID int,
				oType int,
				oOrderDateTime datetime,
				oWorkingDateTime datetime,
				IsGifts	int,
				StaffID int,
				oCustomersName varchar(128),
				oState int
			);
	--开始时间所在月，月累计，截止查询开始时间的当月1日，至开始时间
	declare @OrderList_d Table(
				OrderID int ,
				oOrderNum varchar(50),
				StorageID int,
				ProductsID int,
				oQuantity numeric(18,6),
				oPrice numeric(18,6),
				oMoney numeric(18,6),
				StoresID int,
				StoresSupplierID int,
				oType int,
				oOrderDateTime datetime,
				oWorkingDateTime datetime,
				IsGifts	int,
				StaffID int,
				oCustomersName varchar(128),
				oState int
			);
	
	--结束时间所在月，月累计，截止查询结束时间，至月末
	declare @OrderList_e Table(
				OrderID int ,
				oOrderNum varchar(50),
				StorageID int,
				ProductsID int,
				oQuantity numeric(18,6),
				oPrice numeric(18,6),
				oMoney numeric(18,6),
				StoresID int,
				StoresSupplierID int,
				oType int,
				oOrderDateTime datetime,
				oWorkingDateTime datetime,
				IsGifts	int,
				StaffID int,
				oCustomersName varchar(128),
				oState int
			);
	
	--商品列表,含成本
	declare @Products Table(
		--keyid	int	primary key identity(1,1),
		ProductsID	int,
		pPrice			numeric(18,6),
		CoPrice			numeric(18,6),
		pBarcode		varchar(50),
		pName			varchar(128),
		ProductClassID	int,
		pBrand			varchar(128),
		pStandard	varchar(50),
		pUnits			varchar(50),
		pMaxUnits	varchar(50),
		pToBoxNo	int
	);
	
	if @CostPrice=0
	begin
		insert into @Products(ProductsID,pPrice,CoPrice,pBarcode,pName,ProductClassID,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo)
						select p.ProductsID,p.pPrice,(dbo.fun_GetProductPriceXP(p.ProductsID,@bDate,@eDate)),p.pBarcode,p.pName,p.ProductClassID,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo from tbProductsInfo p where p.pState=0 and p.ProductsID=@ProductsID;
	end
	else
	begin
		insert into @Products(ProductsID,pPrice,CoPrice,pBarcode,pName,ProductClassID,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo)
						select p.ProductsID,p.pPrice,0,p.pBarcode,p.pName,p.ProductClassID,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo from tbProductsInfo p where p.pState=0 and p.ProductsID=@ProductsID;

	end

--整理查询单据
	--有效单据,审核后时间,oState=0
	insert into @OrderList(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState,owYear,owMonth,owDay)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,
						(case o.oType 
							when 1 then (select sName from tbSupplierInfo where SupplierID=ol.StoresSupplierID)
							when 2 then (select sName from tbSupplierInfo where SupplierID=ol.StoresSupplierID)
							when 3 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 4 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 5 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 6 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 7 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 8 then '库存调整'
							when 9 then '调拨'
							when 10 then '坏货'
							when 11 then '换货'
						end),0,0,0,0
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products)  and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime between @bDate and @eDate)
							and ol.oWorkType>=1;
	
	--作废单据，打作废标记时间,oState=1
	insert into @OrderList(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState,owYear,owMonth,owDay)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=-1 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,
					(case o.oType 
							when 1 then (select sName from tbSupplierInfo where SupplierID=ol.StoresSupplierID)
							when 2 then (select sName from tbSupplierInfo where SupplierID=ol.StoresSupplierID)
							when 3 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 4 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 5 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 6 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 7 then (select sName from tbStoresInfo where StoresID=ol.StoresSupplierID)
							when 8 then '库存调整'
							when 9 then '调拨'
							when 10 then '坏货'
							when 11 then '换货'
						end)
					,1,0,0,0
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products) and o.oState=1 and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = -1 and pAppendTime between @bDate and @eDate)
							and ol.oWorkType>=1;
	update @OrderList set owYear=DATEPART(yy,oWorkingDateTime),owMonth=DATEPART(mm,oWorkingDateTime),owDay=DATEPART(dd,oWorkingDateTime);

--计算上期结存
	--有效单据，审核后时间,oState=0
	insert into @OrderList_B(StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oState)
							select ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
											(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
											,ol.IsGifts,o.StaffID,0
												from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
													where ol.ProductsID in(select ProductsID from @Products)  and ol.StorageID=@StorageID
													and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime <= @bDate)
													and ol.oWorkType>=1;
	--作废单据，打作废标记时间,oState=1
	insert into @OrderList_B(StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oState)
					select ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=-1 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,1
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products) and o.oState=1 and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = -1 and pAppendTime <= @bDate )
							and ol.oWorkType>=1;
	
	
				
--计算上期结存
	select @Product_UPYear=sum(
			case ob.oState
				when 0 then--正常单据
						case 
							when ob.oType in(1,4,8,9,11) then ob.oQuantity
							when ob.oType in(2,3,5,6,7,10) then -ob.oQuantity
						end
				when 1 then--作废单据
						case 
							when ob.oType in(1,4,8,9,11) then -ob.oQuantity
							when ob.oType in(2,3,5,6,7,10) then ob.oQuantity
						end
			end
			
			) from @OrderList_b	ob	
	
	select @Product_UPYear=@Product_UPYear+pQuantity from tbProductsStorageLogInfo where StorageID=@StorageID and ProductsID=@ProductsID and pType=-1 and pState=0;
	
	
--年累计
	--有效单据,审核后时间,oState=0
	insert into @OrderList_c(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,0
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products)  and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime between DATEADD(yy,DATEDIFF(yy,0,@eDate),0) and dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@eDate)+1, 0)))
							and ol.oWorkType>=1;
	
	--作废单据，打作废标记时间,oState=1
	insert into @OrderList_c(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=-1 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,1
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products) and o.oState=1 and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = -1 and pAppendTime between DATEADD(yy,DATEDIFF(yy,0,@eDate),0) and dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@eDate)+1, 0)))
							and ol.oWorkType>=1;

--计算月累计，开始月
	--有效单据,审核后时间,oState=0
	insert into @OrderList_d(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,0
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products)  and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime between DATEADD(mm, DATEDIFF(mm,0,@bDate), 0) and @bDate)
							and ol.oWorkType>=1;
	
	--作废单据，打作废标记时间,oState=1
	insert into @OrderList_d(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=-1 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,1
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products) and o.oState=1 and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = -1 and pAppendTime between DATEADD(mm, DATEDIFF(mm,0,@bDate), 0) and @bDate)
							and ol.oWorkType>=1;

--计算月累计，结束月
	--有效单据,审核后时间,oState=0
	insert into @OrderList_e(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,0
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products)  and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime between @eDate and dateadd(ms,-3,DATEADD(mm,DATEDIFF(m,0,@eDate)+1,0)))
							and ol.oWorkType>=1;
	
	--作废单据，打作废标记时间,oState=1
	insert into @OrderList_e(OrderID,oOrderNum,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,oCustomersName,oState)
					select ol.OrderID,o.oOrderNum,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
					(select max(pAppendTime) from tbOrderWorkingLogInfo where oType=-1 and OrderID=o.OrderID) as pAppendTime
					,ol.IsGifts,o.StaffID,o.oCustomersName,1
						from tbOrderListInfo ol left join tbOrderInfo as o on o.OrderID=ol.OrderID 
							where ol.ProductsID in(select ProductsID from @Products) and o.oState=1 and ol.StorageID=@StorageID
							and ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = -1 and pAppendTime between @eDate and dateadd(ms,-3,DATEADD(mm,DATEDIFF(m,0,@eDate)+1,0)))
							and ol.oWorkType>=1;

--输出上期结存总数
	select isnull(@Product_UPYear,0);
	
--输出本期列表						
	select * from @OrderList order by oWorkingDateTime asc;
	
--输出年度累计
	select isnull(sum(case oType when 1 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pA,--进货
			isnull(sum(case oType when 2 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pB,--进货退
			isnull(sum(case oType when 3 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pC,--销售
			isnull(sum(case oType when 4 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pD,--销售退
			isnull(sum(case oType when 5 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pE,--赠品
			isnull(sum(case oType when 6 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pF,--样品
			isnull(sum(case oType when 7 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pG,--代购
			isnull(sum(case oType when 8 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pH,--调整
			
			isnull(sum(case oType when 10 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pJ,--报损
			isnull(sum(case oType when 11 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pK,--换货
			
			isnull(sum(case oType when 9 then case when oQuantity>0 then case oState when 0 then oQuantity when 1 then -oQuantity end end end),0) as [pI],--调拨入库
			isnull(sum(case oType when 9 then case when oQuantity<0 then case oState when 0 then -oQuantity when 1 then oQuantity end end end),0) as [pO]--调拨出库
			
			 from @OrderList_c;

--输出月累计,开始月
	select isnull(sum(case oType when 1 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pA,--进货
			isnull(sum(case oType when 2 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pB,--进货退
			isnull(sum(case oType when 3 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pC,--销售
			isnull(sum(case oType when 4 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pD,--销售退
			isnull(sum(case oType when 5 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pE,--赠品
			isnull(sum(case oType when 6 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pF,--样品
			isnull(sum(case oType when 7 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pG,--代购
			isnull(sum(case oType when 8 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pH,--调整
			
			isnull(sum(case oType when 10 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pJ,--报损
			isnull(sum(case oType when 11 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pK,--换货
			
			isnull(sum(case oType when 9 then case when oQuantity>0 then case oState when 0 then oQuantity when 1 then -oQuantity end end end),0) as [pI],--调拨入库
			isnull(sum(case oType when 9 then case when oQuantity<0 then case oState when 0 then -oQuantity when 1 then oQuantity end end end),0) as [pO]--调拨出库
			 from @OrderList_d;
			 
--输出月累计,结束月
	select isnull(sum(case oType when 1 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pA,--进货
			isnull(sum(case oType when 2 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pB,--进货退
			isnull(sum(case oType when 3 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pC,--销售
			isnull(sum(case oType when 4 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pD,--销售退
			isnull(sum(case oType when 5 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pE,--赠品
			isnull(sum(case oType when 6 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pF,--样品
			isnull(sum(case oType when 7 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pG,--代购
			isnull(sum(case oType when 8 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pH,--调整
			
			isnull(sum(case oType when 10 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pJ,--报损
			isnull(sum(case oType when 11 then case oState when 0 then oQuantity when 1 then -oQuantity end end),0) as pK,--换货
			
			isnull(sum(case oType when 9 then case when oQuantity>0 then case oState when 0 then oQuantity when 1 then -oQuantity end end end),0) as [pI],--调拨入库
			isnull(sum(case oType when 9 then case when oQuantity<0 then case oState when 0 then -oQuantity when 1 then oQuantity end end end),0) as [pO]--调拨出库
		 from @OrderList_e;
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSalesReport_XP]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSalesReport_XP]

    (
    
    @ReDateType int = 1,    --统计类型，按操作时间统计=1,按单据时间统计=2
    
    @ReType int = 1,        --商品销售=1,客户销售=2,结算系统=3,业务员（岗位变动）=4,促销员=5,地区统计=6,业务员（单据）=7,出货统计(商品)=8，出货统计(客户)=9

    @bDate datetime,        --开始时间

    @eDate datetime,        --结束时间

    @NOJoinSales int = 0,    --剔除联营数据,不剔除=0,剔除=1,仅联营=2

    @StoresID int=0,        --指定客户

    @PaymentSystemID int=0,    --指定结算系统

    @oSteps int=5,            --单据状态,默认=5,为已验收确认单据

    @dType int=0,            --统计类型,

                            --0=销售统计按区间统计,1=发出商品按区间统计,

                            --2=备货商品统计(审核后发货前),

                            --3=销售统计按时间点,4=发出商品按时间点统计,

                            --5=业务员单据统计,

                            --6=出货商品统计按区间统计,7=出货商品统计按时间点统计

    @CostPrice int=0,        --是否计算成本,0=显示,1=不显示
    
    @SingleMemberID int =0,    --指定开单员
    
    @OrderNumber varchar(1024)=''--指定单据
    
    )

AS

begin

    set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');

    set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

    declare @tBDate datetime,@tEDate datetime;

    set @tBDate = dateadd(DAY,-365,getdate());

    set @tEDate = dateadd(DAY,365,getdate());

    --整理单据,初级范围
    declare @Orders Table(

                    OrderID int ,

                    oOrderNum varchar(50),

                    oType int,

                    StoresID int,

                    oCustomersName varchar(128),

                    oCustomersContact varchar(50),

                    oCustomersTel varchar(50),

                    oCustomersAddress varchar(512),

                    oCustomersOrderID varchar(50),

                    oCustomersNameB varchar(128),
                    
                    StaffID int,
                    
                    UserID int,

                    oAppendTime datetime,
                    
                    oOrderDateTime datetime,

                    oState    int,

                    oPrepay int,
                    
                    oSteps int,
                    
                    oReMake varchar(512)

            );

    --整理单据
    declare @OrderList Table(

                --keyid int primary key IDENTITY(1,1),

                OrderID int ,

                StorageID int,

                ProductsID int,

                oQuantity numeric(18,6),

                oPrice numeric(18,6),

                oMoney numeric(18,6),

                StoresID int,

                StoresSupplierID int,

                oType int,

                oOrderDateTime datetime,

                oWorkingDateTime datetime,

                IsGifts    int,

                StaffID int,
                SingleMemberID int

            );
            
        

    --商品列表,含成本

    declare @Products Table(

        --keyid    int    primary key identity(1,1),

        ProductsID    int,

        pPrice            numeric(18,6),

        CoPrice            numeric(18,6),

        pBarcode        varchar(50),

        pName            varchar(128),

        ProductClassID    int,

        pBrand            varchar(128),

        pStandard    varchar(50),

        pUnits            varchar(50),

        pMaxUnits    varchar(50),

        pToBoxNo    int

    );

    --人员列表

    declare @Staff Table(

        StaffID int,            --人员编号

        DepartmentsClassID int,    --部门编号

        StoresID int,            --客户/门店编号

        sName varchar(50),        --姓名

        sType int,                --类型

        bDate datetime,            --上岗时间

        eDate datetime            --离岗时间

    );

    

    if @CostPrice=0

    begin

        insert into @Products(ProductsID,pPrice,CoPrice,pBarcode,pName,ProductClassID,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo)

                        select p.ProductsID,p.pPrice,(dbo.fun_GetProductPriceXP(p.ProductsID,@bDate,@eDate)),p.pBarcode,p.pName,p.ProductClassID,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo from tbProductsInfo p ;--where p.pState=0;

    end

    else

    begin

        insert into @Products(ProductsID,pPrice,CoPrice,pBarcode,pName,ProductClassID,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo)

                        select p.ProductsID,p.pPrice,0,p.pBarcode,p.pName,p.ProductClassID,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo from tbProductsInfo p ;--where p.pState=0;

    end


    --初级过滤统计数据
    
        if @OrderNumber != ''
        begin
            
            --set @OrderNumber = ''''+REPLACE(@OrderNumber,',',''',''')+'''';
            
            if @ReDateType =1
            begin
                insert into @Orders(OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake)
                    --select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where oOrderNum in(@OrderNumber) and oState=0 and OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate);
                    select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where CHARINDEX(oOrderNum,@OrderNumber)>0 and oState=0 and OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate);
    
            end
            else
            begin
                insert into @Orders(OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake)
                    --select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where oOrderNum in(@OrderNumber) and oState=0 and oOrderDateTime between @bDate and @eDate;
                    select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where CHARINDEX(oOrderNum,@OrderNumber)>0 and oState=0 and oOrderDateTime between @bDate and @eDate;
    
            end
            
        end
        else
        begin
        
            if @ReDateType =1
            begin
                insert into @Orders(OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake)
                    select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where oState = 0 and OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate);
            end
            else
            begin
                insert into @Orders(OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake)
                    select OrderID,oOrderNum,oType,StoresID,oCustomersName,oCustomersContact,oCustomersTel,oCustomersAddress,oCustomersOrderID,oCustomersNameB,StaffID,UserID,oAppendTime,oOrderDateTime,oState,oPrepay,oSteps,oReMake from tbOrderInfo where oState = 0 and oOrderDateTime between @bDate and @eDate;
        
            end
            
        end
    
--select * from @Orders;

    --销售统计,既指定单据步骤内数据
    if @dType=0
    begin

        if @ReDateType =1
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=5 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,4,5,6,10) 
                                and o.oState=0 
                                and o.oSteps>=@oSteps
                                and ol.oWorkType=2
                            where 
								--ol.ProductsID in(select ProductsID from @Products)  and
								ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate and oType=5) ;
        end
        else
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=5 and OrderID=o.OrderID) as pAppendTime
                ,ol.IsGifts,o.StaffID,o.UserID
                from tbOrderListInfo ol left join @Orders as o on 
                    o.OrderID=ol.OrderID 
                    and o.oType in(3,4,5,6,10) 
                    and o.oState=0 
                    and o.oSteps>=@oSteps
                    and ol.oWorkType=2 
                --where 
					--ol.ProductsID in(select ProductsID from @Products)  and 
					--ol.OrderID in(select OrderID from @Orders) 
					;
        end

    end  


    --发出商品统计,既指定单据步骤前数据(发货后,收货中,核销前)

    if @dType=1
    begin
        if @ReDateType =1
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType in(3,4) and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,4,5,6,10) 
                                and o.oState=0
                                and ol.oWorkType >= 1
                            where 
                                --ol.ProductsID in(select ProductsID from @Products) and 
                                --and o.oSteps>=@oSteps 
                                ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType in(3,4) and pAppendTime between @bDate and @eDate) 
                                ;
        end
        else
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType in(3,4) and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,4,5,6,10) 
                                and o.oState=0
                                and ol.oWorkType >= 1
                            --where 
                                --ol.ProductsID in(select ProductsID from @Products) and 
                                --and o.oSteps>=@oSteps 
                                --ol.OrderID in(select OrderID from @Orders) 
                                ;
        end

    end



    

    --备货商品统计

    if @dType=2
    begin

        if @ReDateType =1
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                    select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                    (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
                    ,ol.IsGifts,o.StaffID,o.UserID
                        from tbOrderListInfo ol left join @Orders as o on 
                            o.OrderID=ol.OrderID 
                            and o.oType in(3,4,5,6,10) 
                            and o.oState=0
                            and ol.oWorkType>=1
                        where 
                            --ol.ProductsID in(select ProductsID from @Products) and  
                            --and o.oSteps>=@oSteps 
                            ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType = 2 and pAppendTime between @bDate and @eDate) 
                            and ol.OrderID not in(select OrderID from tbOrderWorkingLogInfo where oType in (3,4,5) and pAppendTime between @bDate and @eDate )
                            ;
        end
        else
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                    select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                    (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=2 and OrderID=o.OrderID) as pAppendTime
                    ,ol.IsGifts,o.StaffID,o.UserID
                        from tbOrderListInfo ol left join @Orders as o on 
                            o.OrderID=ol.OrderID 
                            and o.oType in(3,4,5,6,10) 
                            and o.oState=0
                            and ol.oWorkType>=1
                        --where 
                            --ol.ProductsID in(select ProductsID from @Products)  and
                            --and o.oSteps>=@oSteps 
                            --ol.OrderID in(select OrderID from @Orders) 
                            ;
        end
    end

    

    --销售统计,按时间点

    if @dType=3
    begin

        if @ReDateType =1
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                    select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                    (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=5 and OrderID=o.OrderID) as pAppendTime
                    ,ol.IsGifts,o.StaffID,o.UserID
                        from tbOrderListInfo ol left join @Orders as o on 
                            o.OrderID=ol.OrderID 
                            and o.oType in(3,4,5,6,10) 
                            and o.oState=0 
                            and o.oSteps>=@oSteps
                            and ol.oWorkType=2
                        where 
                            --ol.ProductsID in(select ProductsID from @Products) and 
                            ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime <= @eDate and oType=5) 
                            ;
        end
        else
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                    select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                    (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=5 and OrderID=o.OrderID) as pAppendTime
                    ,ol.IsGifts,o.StaffID,o.UserID
                        from tbOrderListInfo ol left join @Orders as o on 
                            o.OrderID=ol.OrderID 
                            and o.oType in(3,4,5,6,10) 
                            and o.oState=0 
                            and o.oSteps>=@oSteps
                            and ol.oWorkType=2
                       -- where 
                           -- ol.ProductsID in(select ProductsID from @Products)  
                           -- and ol.OrderID in(select OrderID from @Orders) 
                            ;
        end
    end

    

    --发出商品统计,按时间点

    if @dType=4
    begin

        if @ReDateType =1
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                            (select max(pAppendTime) from tbOrderWorkingLogInfo where oType in(3,4) and OrderID=o.OrderID) as pAppendTime
                            ,ol.IsGifts,o.StaffID,o.UserID
                                from tbOrderListInfo ol left join @Orders as o on 
                                    o.OrderID=ol.OrderID 
                                    and o.oType in(3,4,5,6,10) and o.oState=0
                                    and ol.oWorkType>=1
                                where 
                                    --ol.ProductsID in(select ProductsID from @Products) and
                                    --and o.oSteps>=@oSteps 
                                    ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType in(3,4) and pAppendTime <= @eDate) 
                                    and ol.OrderID not in(select OrderID from tbOrderWorkingLogInfo where oType in(5,11,12,13,14,15) and pAppendTime <= @eDate )
                                    ;
        end
        else
        begin
            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                            (select max(pAppendTime) from tbOrderWorkingLogInfo where oType in(3,4) and OrderID=o.OrderID) as pAppendTime
                            ,ol.IsGifts,o.StaffID,o.UserID
                                from tbOrderListInfo ol left join @Orders as o on 
                                    o.OrderID=ol.OrderID 
                                    and o.oType in(3,4,5,6,10) 
                                    and o.oState=0
                                    and ol.oWorkType>=1
                                --where 
                                    --ol.ProductsID in(select ProductsID from @Products)  --and o.oSteps>=@oSteps 
                                    --and ol.OrderID in(select OrderID from @Orders) 
                                    ;
        end

    end

    

    --出货商品统计,按区间

    if @dType=6

    begin

        if @ReDateType =1
        begin
            --出货时间:销售,赠品,样品,坏货 单据的发货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=3 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,5,6,10) 
                                and o.oState=0 
                                and o.oSteps>=3
                                and ol.oWorkType in(1,2)
                            where 
                                --ol.ProductsID in(select ProductsID from @Products)  and
                                ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate and oType=3) 
                                ;

            --退货时间:退货单的 收货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=4 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType=4 
                                and o.oState=0 
                                and o.oSteps>=4 
                                and ol.oWorkType in(1,2)
                            where 
                                --ol.ProductsID in(select ProductsID from @Products) and 
                                ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime between @bDate and @eDate and oType=4) 
                                ;
        
        end
        else
        begin
            --出货时间:销售,赠品,样品,坏货 单据的发货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=3 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,5,6,10) 
                                and o.oState=0 
                                and o.oSteps>=3 
                                and ol.oWorkType in(1,2)
                           -- where 
                                --ol.ProductsID in(select ProductsID from @Products) and  
                                --ol.OrderID in(select OrderID from @Orders) 
                                ;

            --退货时间:退货单的 收货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=4 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType=4 
                                and o.oState=0 
                                and o.oSteps>=4
                                and ol.oWorkType in(1,2)
                            --where 
                                --ol.ProductsID in(select ProductsID from @Products)  
                                --and ol.OrderID in(select OrderID from @Orders) 
                                ;
        
        end
    end

    

    --出货统计,按时间点

    if @dType=7

    begin

        if @ReDateType =1
        begin
            --出货时间:销售,赠品,样品,坏货 单据的发货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=3 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,5,6,10) 
                                and o.oState=0 
                                and o.oSteps>=3
                                and ol.oWorkType in(1,2)
                            where 
                                --ol.ProductsID in(select ProductsID from @Products)  and
                                ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime <= @eDate and oType=3) 
                                ;

            --退货时间:退货单的 收货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=4 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID
                                and o.oType=4
                                and o.oState=0 
                                and o.oSteps>=4 
                                and ol.oWorkType in(1,2)
                            where 
                                --ol.ProductsID in(select ProductsID from @Products) and 
                                ol.OrderID in(select OrderID from tbOrderWorkingLogInfo where pAppendTime <= @eDate and oType=4) 
                                ;
                                
        end
        else
        begin
            --出货时间:销售,赠品,样品,坏货 单据的发货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=3 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType in(3,5,6,10) 
                                and o.oState=0 
                                and o.oSteps>=3
                                and ol.oWorkType in(1,2)
                            --where 
                                --ol.ProductsID in(select ProductsID from @Products)  and 
                                --ol.OrderID in(select OrderID from @Orders) 
                                ;

            --退货时间:退货单的 收货时间

            insert into @OrderList(OrderID,StorageID,ProductsID,oQuantity,oPrice,oMoney,StoresID,StoresSupplierID,oType,oOrderDateTime,oWorkingDateTime,IsGifts,StaffID,SingleMemberID)
                        select ol.OrderID,ol.StorageID,ol.ProductsID,ol.oQuantity,ol.oPrice,(isnull(ol.oQuantity,0)*isnull(ol.oPrice,0)) as oMoney,o.StoresID,ol.StoresSupplierID,o.oType,o.oOrderDateTime,
                        (select max(pAppendTime) from tbOrderWorkingLogInfo where oType=4 and OrderID=o.OrderID) as pAppendTime
                        ,ol.IsGifts,o.StaffID,o.UserID
                            from tbOrderListInfo ol left join @Orders as o on 
                                o.OrderID=ol.OrderID 
                                and o.oType=4
                                and o.oState=0 
                                and o.oSteps>=4
                                and ol.oWorkType in(1,2)
                            --where 
                                --ol.ProductsID in(select ProductsID from @Products)  and 
                                --ol.OrderID in(select OrderID from @Orders) 
                                ;
        end
    end



    --条件表

    declare @OrderList_t Table(

                OrderID int

            );

            

    insert into @OrderList_t(OrderID) values(0);

    --剔除联营

    if @NOJoinSales=1

    begin

        insert into @OrderList_t(OrderID)

            select OrderID from @OrderList where dbo.fun_CheckProductIsPool(ProductsID,oWorkingDateTime)=1

    end

    

    --仅联营

    if @NOJoinSales=2

    begin

        insert into @OrderList_t(OrderID)

            select OrderID from @OrderList where dbo.fun_CheckProductIsPool(ProductsID,oWorkingDateTime)=0

    end

    

    --指定客户

    if @StoresID>0

    begin

        insert into @OrderList_t(OrderID)

            select OrderID from @OrderList where StoresID<>@StoresID;

    end

    
    --指定开单员
    if @SingleMemberID>0
    begin
        insert into @OrderList_t(OrderID)

            select OrderID from @OrderList where SingleMemberID<>@SingleMemberID;
    end


    --指定结算系统

    if @PaymentSystemID>0

    begin

        insert into @OrderList_t(OrderID)

            select OrderID from @OrderList as o where not exists(select StoresID from tbStoresInfo where o.StoresID=tbStoresInfo.StoresID and  PaymentSystemID=@PaymentSystemID);

    end

    

    --整理后的单据数据

    declare @OrderList_tem Table(

            OrderID int,

            StaffID int,

            StoresID int,

            ProductsID int,

            oQuantity numeric(18,6),

            oMoney numeric(18,6),

            IsGifts int,

            oType int,
            SingleMemberID int

        );

    

    --商品销售

    if @ReType = 1

    begin

        

        insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                    select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        

        select pss.ProductsID,pss.pPrice,pss.CoPrice,pss.pBarcode,pss.pName,pss.ProductClassID,pss.pBrand,pss.pStandard,pss.pUnits,pss.pMaxUnits,pss.pToBoxNo,pss.pClassName,

        pss.oQuantity,pss.oMoney,

        pss.oQuantity_t,pss.oMoney_t,

        pss.oQuantity_z,pss.CostPrice_z as oMoney_z,

        pss.oQuantity_y,pss.CostPrice_y as oMoney_y,

        pss.oQuantity_h,pss.CostPrice_h as oMoney_h,

        pss.oQuantity_sz,pss.CostPrice_sz as oMoney_sz,

        pss.CostPrice,pss.CostPrice_s,pss.CostPrice_t,pss.CostPrice_z,pss.CostPrice_y,pss.CostPrice_h,pss.CostPrice_sz from (

            select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,        --销售成本

                        (ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,    --退货成本

                        (ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,    --赠品成本

                        (ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,    --样品成本

                        (ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h,    --坏货成本

                        (ps.oQuantity_sz*ISNULL(ps.CostPrice,0)) CostPrice_sz        --坏货成本

             from(

                select p.*,pc.pClassName,

                    isnull(oo.oQuantity,0) oQuantity,            --销售数量

                    isnull(oo.oMoney,0) oMoney,                    --销售金额

                    isnull(ool.oQuantity,0) oQuantity_t,        --销售退货数量

                    isnull(ool.oMoney,0) oMoney_t,                --销售退货金额

                    isnull(oool.oQuantity,0) oQuantity_z,        --赠品数量

                    --isnull(oool.oQuantity*isnull(p.CoPrice,0),0) oMoney_z,                --赠品单据金额

                    isnull(ooool.oQuantity,0) oQuantity_y,        --样品数量

                    --isnull(ooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_y,            --样品单据金额

                    isnull(oooool.oQuantity,0) oQuantity_h,        --坏货数量

                    --isnull(oooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_h,            --坏货单据金额

                    isnull(ooooool.oQuantity,0) oQuantity_sz,    --销售赠品数量

                    --isnull(ooooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_sz,            --销售赠品单据金额

                    isnull(p.CoPrice,0) as CostPrice            --成本

                    from @Products as p left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID 

                    --销售--,sum(isnull(oMoney,0)) oMoney

                    left join 

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by ProductsID) as oo on oo.ProductsID=p.ProductsID

                    --退货

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by ProductsID) as ool on ool.ProductsID=p.ProductsID

                    --赠品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by ProductsID) as oool on oool.ProductsID=p.ProductsID

                    --样品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by ProductsID) as ooool on ooool.ProductsID=p.ProductsID

                    --坏货

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=10  group by ProductsID) as oooool on oooool.ProductsID=p.ProductsID

                    --销售赠品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by ProductsID) as ooooool on ooooool.ProductsID=p.ProductsID

            ) ps  ) as pss 

            where pss.oQuantity<>0 or pss.oMoney<>0 or pss.oQuantity_t<>0 or pss.oMoney_t<>0 or pss.oQuantity_t<>0 or pss.oMoney_t<>0

            or pss.oQuantity_z<>0  or pss.oQuantity_y<>0  or pss.oQuantity_h<>0  or pss.oQuantity_sz<>0 

            order by  pss.ProductClassID,pss.ProductsID desc;

        

    end

    --客户销售

    if @ReType = 2

    begin

        

            insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                    select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        

            select ps.CustomersClassID,ps.StoresID,ps.sName,

                    ppp.CoPrice as CostPrice,

                    ppp.pPrice,

                    ppp.pBarcode,ppp.pName,ppp.pToBoxNo,

                    ss.oQuantity,ss.oMoney,

                    ss.oQuantity_t,ss.oMoney_t,

                    ss.oQuantity_z,(ss.oQuantity_z*isnull(ppp.CoPrice,0)) as oMoney_z,

                    ss.oQuantity_y,(ss.oQuantity_y*isnull(ppp.CoPrice,0)) as oMoney_y,

                    ss.oQuantity_sz,(ss.oQuantity_sz*isnull(ppp.CoPrice,0)) as oMoney_sz

            from tbStoresInfo as ps left join (

                select s.StoresID,s.ProductsID,

                        sum(isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                        sum(isnull(oo.oMoney,0)) oMoney,                --销售金额

                        sum(isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                        sum(isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                        sum(isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                        --sum(isnull(oool.oMoney,0)) oMoney_z,            --赠品单据金额

                        sum(isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                        --sum(isnull(ooool.oMoney,0)) oMoney_y,            --样品单据金额

                        sum(isnull(oooool.oQuantity,0)) oQuantity_sz    --销售赠品数量

                        --sum(isnull(oooool.oMoney,0)) oMoney_sz            --销售赠品单据金额

                        

                    from (select _s.StoresID,_p.ProductClassID,_p.ProductsID,_p.CoPrice

                     from tbStoresInfo _s ,@Products _p) as s

                    --销售

                    left join 

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by StoresID,ProductsID) as oo on oo.StoresID=s.StoresID and oo.ProductsID=s.ProductsID

                    --退货

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by StoresID,ProductsID) as ool on ool.StoresID=s.StoresID and ool.ProductsID=s.ProductsID

                    --赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by StoresID,ProductsID) as oool on oool.StoresID=s.StoresID and oool.ProductsID=s.ProductsID

                    --样品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by StoresID,ProductsID) as ooool on ooool.StoresID=s.StoresID and ooool.ProductsID=s.ProductsID

                    --销售赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by StoresID,ProductsID) as oooool on oooool.StoresID=s.StoresID and oooool.ProductsID=s.ProductsID

                

                    group by s.StoresID,s.ProductsID

                    ) as ss on ps.StoresID=ss.StoresID

                left join @Products ppp on ppp.ProductsID=ss.ProductsID

            where (ss.oQuantity<>0 or ss.oMoney<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0

            or ss.oQuantity_z<>0  or ss.oQuantity_y<>0  or ss.oQuantity_sz<>0 )

            order by  ps.CustomersClassID,ps.StoresID,ppp.ProductClassID,ppp.ProductsID desc;

            

    end

    

    --商品出货

    if @ReType = 8

    begin

        insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                    select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        

        select pss.ProductsID,pss.pPrice,pss.CoPrice,pss.pBarcode,pss.pName,pss.ProductClassID,pss.pBrand,pss.pStandard,pss.pUnits,pss.pMaxUnits,pss.pToBoxNo,pss.pClassName,

        pss.oQuantity,pss.oMoney,

        pss.oQuantity_t,pss.oMoney_t,

        pss.oQuantity_z,pss.CostPrice_z as oMoney_z,

        pss.oQuantity_y,pss.CostPrice_y as oMoney_y,

        pss.oQuantity_h,pss.CostPrice_h as oMoney_h,

        pss.oQuantity_sz,pss.CostPrice_sz as oMoney_sz,

        pss.CostPrice,pss.CostPrice_s,pss.CostPrice_t,pss.CostPrice_z,pss.CostPrice_y,pss.CostPrice_h,pss.CostPrice_sz from (

            select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,        --销售成本

                        (ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,    --退货成本

                        (ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,    --赠品成本

                        (ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,    --样品成本

                        (ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h,    --坏货成本

                        (ps.oQuantity_sz*ISNULL(ps.CostPrice,0)) CostPrice_sz        --坏货成本

             from(

                select p.*,pc.pClassName,

                    isnull(oo.oQuantity,0) oQuantity,            --销售数量

                    isnull(oo.oMoney,0) oMoney,                    --销售金额

                    isnull(ool.oQuantity,0) oQuantity_t,        --销售退货数量

                    isnull(ool.oMoney,0) oMoney_t,                --销售退货金额

                    isnull(oool.oQuantity,0) oQuantity_z,        --赠品数量

                    --isnull(oool.oQuantity*isnull(p.CoPrice,0),0) oMoney_z,                --赠品单据金额

                    isnull(ooool.oQuantity,0) oQuantity_y,        --样品数量

                    --isnull(ooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_y,            --样品单据金额

                    isnull(oooool.oQuantity,0) oQuantity_h,        --坏货数量

                    --isnull(oooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_h,            --坏货单据金额

                    isnull(ooooool.oQuantity,0) oQuantity_sz,    --销售赠品数量

                    --isnull(ooooool.oQuantity*isnull(p.CoPrice,0),0) oMoney_sz,            --销售赠品单据金额

                    isnull(p.CoPrice,0) as CostPrice            --成本

                    from @Products as p left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID 

                    --销售--,sum(isnull(oMoney,0)) oMoney

                    left join 

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by ProductsID) as oo on oo.ProductsID=p.ProductsID

                    --退货

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by ProductsID) as ool on ool.ProductsID=p.ProductsID

                    --赠品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by ProductsID) as oool on oool.ProductsID=p.ProductsID

                    --样品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by ProductsID) as ooool on ooool.ProductsID=p.ProductsID

                    --坏货

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=10  group by ProductsID) as oooool on oooool.ProductsID=p.ProductsID

                    --销售赠品

                    left join

                    (select ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by ProductsID) as ooooool on ooooool.ProductsID=p.ProductsID

            ) ps  ) as pss 

            where pss.oQuantity<>0 or pss.oMoney<>0 or pss.oQuantity_t<>0 or pss.oMoney_t<>0 or pss.oQuantity_t<>0 or pss.oMoney_t<>0

            or pss.oQuantity_z<>0  or pss.oQuantity_y<>0  or pss.oQuantity_h<>0  or pss.oQuantity_sz<>0 

            order by  pss.ProductClassID,pss.ProductsID desc;

    end

    --客户出货

    if @ReType = 9

    begin

        insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                    select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        

            select ps.CustomersClassID,ps.StoresID,ps.sName,

                    ppp.CoPrice as CostPrice,

                    ppp.pPrice,

                    ppp.pBarcode,ppp.pName,ppp.pToBoxNo,

                    ss.oQuantity,ss.oMoney,

                    ss.oQuantity_t,ss.oMoney_t,

                    ss.oQuantity_z,(ss.oQuantity_z*isnull(ppp.CoPrice,0)) as oMoney_z,

                    ss.oQuantity_y,(ss.oQuantity_y*isnull(ppp.CoPrice,0)) as oMoney_y,

                    ss.oQuantity_sz,(ss.oQuantity_sz*isnull(ppp.CoPrice,0)) as oMoney_sz

            from tbStoresInfo as ps left join (

                select s.StoresID,s.ProductsID,

                        sum(isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                        sum(isnull(oo.oMoney,0)) oMoney,                --销售金额

                        sum(isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                        sum(isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                        sum(isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                        --sum(isnull(oool.oMoney,0)) oMoney_z,            --赠品单据金额

                        sum(isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                        --sum(isnull(ooool.oMoney,0)) oMoney_y,            --样品单据金额

                        sum(isnull(oooool.oQuantity,0)) oQuantity_sz    --销售赠品数量

                        --sum(isnull(oooool.oMoney,0)) oMoney_sz            --销售赠品单据金额

                        

                    from (select _s.StoresID,_p.ProductClassID,_p.ProductsID,_p.CoPrice

                     from tbStoresInfo _s ,@Products _p) as s

                    --销售

                    left join 

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by StoresID,ProductsID) as oo on oo.StoresID=s.StoresID and oo.ProductsID=s.ProductsID

                    --退货

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by StoresID,ProductsID) as ool on ool.StoresID=s.StoresID and ool.ProductsID=s.ProductsID

                    --赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by StoresID,ProductsID) as oool on oool.StoresID=s.StoresID and oool.ProductsID=s.ProductsID

                    --样品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by StoresID,ProductsID) as ooool on ooool.StoresID=s.StoresID and ooool.ProductsID=s.ProductsID

                    --销售赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by StoresID,ProductsID) as oooool on oooool.StoresID=s.StoresID and oooool.ProductsID=s.ProductsID

                

                    group by s.StoresID,s.ProductsID

                    ) as ss on ps.StoresID=ss.StoresID

                left join @Products ppp on ppp.ProductsID=ss.ProductsID

            where (ss.oQuantity<>0 or ss.oMoney<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0

            or ss.oQuantity_z<>0  or ss.oQuantity_y<>0  or ss.oQuantity_sz<>0 )

            order by  ps.CustomersClassID,ps.StoresID,ppp.ProductClassID,ppp.ProductsID desc;

    end

    

    --结算系统

    if @ReType = 3

    begin

            insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

            select pps.*,p.pName as ProductName,p.pBarcode,p.pToBoxNo,p.pUnits,p.pMaxUnits,

                isnull(p.CoPrice,0) as CostPrice    --成本

             from  @Products as p left join(

                select ps.PaymentSystemID,ps.pName,ssss.ProductsID,

                    sum(isnull(ssss.oQuantity,0)) oQuantity,            --销售数量

                    sum(isnull(ssss.oMoney,0)) oMoney,                    --销售金额

                    sum(isnull(ssss.oQuantity_t,0)) oQuantity_t,        --销售退货数量

                    sum(isnull(ssss.oMoney_t,0)) oMoney_t,            --销售退货金额

                    sum(isnull(ssss.oQuantity_z,0)) oQuantity_z,        --赠品数量

                    sum(isnull(ssss.oMoney_z,0)) oMoney_z,            --赠品单据金额

                    sum(isnull(ssss.oQuantity_y,0)) oQuantity_y,    --样品数量

                    sum(isnull(ssss.oMoney_y,0)) oMoney_y            --样品单据金额 

                

                

                from tbPaymentSystemInfo ps left join(

                    select ss.*,sss.PaymentSystemID from(

                        select s.StoresID,s.ProductsID,

                            sum(isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                            sum(isnull(oo.oMoney,0)) oMoney,                    --销售金额

                            sum(isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                            sum(isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                            sum(isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                            sum(isnull(oool.oQuantity,0)*isnull(s.CoPrice,0)) oMoney_z,            --赠品单据金额

                            sum(isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                            sum(isnull(ooool.oQuantity,0)*isnull(s.CoPrice,0)) oMoney_y            --样品单据金额

                        

                        from (select _s.StoresID,_p.ProductClassID,_p.ProductsID,_p.CoPrice

                            from tbStoresInfo _s ,@Products _p) as s

                        --销售

                        left join 

                        (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by StoresID,ProductsID) as oo on oo.StoresID=s.StoresID and oo.ProductsID=s.ProductsID

                        --退货

                        left join

                        (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by StoresID,ProductsID) as ool on ool.StoresID=s.StoresID and ool.ProductsID=s.ProductsID

                        --赠品

                        left join

                        (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by StoresID,ProductsID) as oool on oool.StoresID=s.StoresID and oool.ProductsID=s.ProductsID

                        --样品

                        left join

                        (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by StoresID,ProductsID) as ooool on ooool.StoresID=s.StoresID and ooool.ProductsID=s.ProductsID

                        group by s.StoresID,s.ProductsID

                        ) as ss right join tbStoresInfo sss on ss.StoresID=sss.StoresID where sss.sState=0

                    ) as ssss 

                    on ssss.PaymentSystemID = ps.PaymentSystemID 

                    group by ps.PaymentSystemID,ps.pName,ssss.ProductsID

                )as pps on p.ProductsID=pps.ProductsID

                where (pps.oQuantity<>0 or pps.oMoney<>0 or pps.oQuantity_t<>0 or pps.oMoney_t<>0 or pps.oQuantity_t<>0 or pps.oMoney_t<>0

            or pps.oQuantity_z<>0 or pps.oMoney_z<>0 or pps.oQuantity_y<>0 or pps.oMoney_y<>0 )

            order by pps.PaymentSystemID,p.ProductClassID,p.ProductsID desc;

        

    end

    

    --人员（岗位变动）,业务员,促销员,部门

    if @ReType = 4 or @ReType=5

    begin

        declare @sType int;    --人员类型

    

        if @ReType = 4    --业务员

        begin

            set @sType = 1;

        end

        

        if @ReType = 5    --促销员

        begin

            set @sType = 2;

        end

        

        --按人员岗位变动统计

        

        insert into @Staff(StaffID,DepartmentsClassID,sName,sType,bDate,eDate,StoresID)

                select s.StaffID, s.DepartmentsClassID,s.sName,s.sType,ss.bdate,ss.edate,ss.StoresID from 

                (select StaffID,StoresID,MIN(bdate) bdate,MAX(edate) edate from tbSales_Staff_StoresDataInfo group by StaffID,StoresID)  ss 

                    left join tbStaffInfo s on ss.StaffID=s.StaffID

                    where (@bDate between ss.bdate and ss.edate) and (@eDate between ss.bdate and ss.edate) and s.sType=@sType;    

        --select * from @Staff order by StaffID

        

        insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

            select o.OrderID,s.StaffID,o.StoresID,o.ProductsID,o.oQuantity ,o.oMoney,o.IsGifts,o.oType,o.SingleMemberID 

                from @OrderList as o left join @Staff as s on o.StoresID=s.StoresID  

                where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID) 

                        and s.StaffID > 0 and (o.oWorkingDateTime between s.bDate and s.eDate)

                order by s.StaffID,o.ProductsID desc;

        

        --select * from @OrderList_tem where oType=3 order by StaffID,ProductsID desc;

        

        select os.StaffID,os.ProductsID,ss.sName,

                    isnull(p.CoPrice,0) as CostPrice,

                    p.pPrice,

                    p.pBarcode,p.pName,p.pToBoxNo,

                    os.oQuantity,os.oMoney,

                    os.oQuantity_t,os.oMoney_t,

                    os.oQuantity_z,(os.oQuantity_z*isnull(p.CoPrice,0)) as oMoney_z,

                    os.oQuantity_y,(os.oQuantity_y*isnull(p.CoPrice,0)) as oMoney_y,

                    os.oQuantity_sz,(os.oQuantity_sz*isnull(p.CoPrice,0)) as oMoney_sz

         from (

            select s.StaffID,s.ProductsID,

                (isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                (isnull(oo.oMoney,0)) oMoney,                --销售金额

                (isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                (isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                (isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                --(isnull(oool.oMoney,0)) oMoney_z,            --赠品单据金额

                (isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                --(isnull(ooool.oMoney,0)) oMoney_y,            --样品单据金额

                (isnull(oooool.oQuantity,0)) oQuantity_sz    --销售赠品数量

                --(isnull(oooool.oMoney,0)) oMoney_sz            --销售赠品单据金额

            from 

                (select _s.StaffID,_p.ProductsID from (select StaffID from tbStaffInfo where sType=@sType) _s ,@Products _p) as s

            

                --销售

                left join 

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem  where oType=3  group by StaffID,ProductsID) as oo on oo.StaffID=s.StaffID  and oo.ProductsID=s.ProductsID  

                --退货

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem  where oType=4  group by StaffID,ProductsID) as ool on ool.StaffID=s.StaffID  and ool.ProductsID=s.ProductsID 

                --赠品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem  where oType=5  group by StaffID,ProductsID) as oool on oool.StaffID=s.StaffID  and oool.ProductsID=s.ProductsID 

                --样品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem  where oType=6  group by StaffID,ProductsID) as ooool on ooool.StaffID=s.StaffID  and ooool.ProductsID=s.ProductsID 

                --销售赠品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem  where oType=3 and IsGifts<>0  group by StaffID,ProductsID) as oooool on oooool.StaffID=s.StaffID  and oooool.ProductsID=s.ProductsID 

                

                --group by s.StaffID,s.ProductsID

                --order by s.StaffID,s.ProductsID desc

                

            ) as os left join (select StaffID,DepartmentsClassID,sName from tbStaffInfo where sType=@sType) ss on ss.StaffID = os.StaffID

            left join @Products p on os.ProductsID = p.ProductsID

            where (os.oQuantity<>0 or os.oMoney<>0 or os.oQuantity_t<>0 or os.oMoney_t<>0 or os.oQuantity_z<>0  or os.oQuantity_y<>0  or os.oQuantity_sz<>0 )

            order by  ss.DepartmentsClassID,ss.StaffID,p.ProductClassID,p.ProductsID desc;

    end

    

    --地区统计

    if @ReType=6

    begin

        insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                    select OrderID,0,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        

            select ps.CustomersClassID,ps.StoresID,ps.sName,isnull(r.RegionID,0) as RegionID,isnull(r.rName,'未归类') as rName,isnull(r.rUpID,0) as rUpID,

                    ppp.CoPrice as CostPrice,

                    ppp.pPrice,

                    ppp.pBarcode,ppp.pName,ppp.pToBoxNo,

                    ss.oQuantity,ss.oMoney,

                    ss.oQuantity_t,ss.oMoney_t,

                    ss.oQuantity_z,(ss.oQuantity_z*isnull(ppp.CoPrice,0)) as oMoney_z,

                    ss.oQuantity_y,(ss.oQuantity_y*isnull(ppp.CoPrice,0)) as oMoney_y,

                    ss.oQuantity_sz,(ss.oQuantity_sz*isnull(ppp.CoPrice,0)) as oMoney_sz

            from tbStoresInfo as ps left join (

                select s.StoresID,s.ProductsID,

                        sum(isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                        sum(isnull(oo.oMoney,0)) oMoney,                --销售金额

                        sum(isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                        sum(isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                        sum(isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                        --sum(isnull(oool.oMoney,0)) oMoney_z,            --赠品单据金额

                        sum(isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                        --sum(isnull(ooool.oMoney,0)) oMoney_y,            --样品单据金额

                        sum(isnull(oooool.oQuantity,0)) oQuantity_sz    --销售赠品数量

                        --sum(isnull(oooool.oMoney,0)) oMoney_sz            --销售赠品单据金额

                        

                    from (select _s.StoresID,_p.ProductClassID,_p.ProductsID,_p.CoPrice

                     from tbStoresInfo _s ,@Products _p) as s

                    --销售

                    left join 

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by StoresID,ProductsID) as oo on oo.StoresID=s.StoresID and oo.ProductsID=s.ProductsID

                    --退货

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by StoresID,ProductsID) as ool on ool.StoresID=s.StoresID and ool.ProductsID=s.ProductsID

                    --赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by StoresID,ProductsID) as oool on oool.StoresID=s.StoresID and oool.ProductsID=s.ProductsID

                    --样品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by StoresID,ProductsID) as ooool on ooool.StoresID=s.StoresID and ooool.ProductsID=s.ProductsID

                    --销售赠品

                    left join

                    (select StoresID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by StoresID,ProductsID) as oooool on oooool.StoresID=s.StoresID and oooool.ProductsID=s.ProductsID

                

                    group by s.StoresID,s.ProductsID

                    ) as ss on ps.StoresID=ss.StoresID

                left join @Products ppp on ppp.ProductsID=ss.ProductsID

                left join tbRegionInfo r on ps.RegionID=r.RegionID

            where (ss.oQuantity<>0 or ss.oMoney<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0

            or ss.oQuantity_z<>0  or ss.oQuantity_y<>0  or ss.oQuantity_sz<>0 )

            order by  ps.CustomersClassID,ps.StoresID,ppp.ProductClassID,ppp.ProductsID desc;

    end

    

    --人员（单据）

    if @ReType=7

    begin

    --按单据上的人员统计    

    insert into @OrderList_tem(OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID)

                select OrderID,StaffID,StoresID,ProductsID,oQuantity,oMoney,IsGifts,oType,SingleMemberID from @OrderList o where NOT EXISTS (select null from @OrderList_t as t where o.OrderID=t.OrderID);

        select ps.DepartmentsClassID,ps.StaffID,ps.sName,

                ppp.CoPrice as CostPrice,

                ppp.pPrice,

                ppp.pBarcode,ppp.pName,ppp.pToBoxNo,

                ss.oQuantity,ss.oMoney,

                ss.oQuantity_t,ss.oMoney_t,

                ss.oQuantity_z,(ss.oQuantity_z*isnull(ppp.CoPrice,0)) as oMoney_z,

                ss.oQuantity_y,(ss.oQuantity_y*isnull(ppp.CoPrice,0)) as oMoney_y,

                ss.oQuantity_sz,(ss.oQuantity_sz*isnull(ppp.CoPrice,0)) as oMoney_sz

        from  tbStaffInfo as ps left join (/*(select * from tbStaffInfo /*where sType=1*/)*/

            select s.StaffID,s.ProductsID,

                    sum(isnull(oo.oQuantity,0)) oQuantity,            --销售数量

                    sum(isnull(oo.oMoney,0)) oMoney,                --销售金额

                    sum(isnull(ool.oQuantity,0)) oQuantity_t,        --销售退货数量

                    sum(isnull(ool.oMoney,0)) oMoney_t,            --销售退货金额

                    sum(isnull(oool.oQuantity,0)) oQuantity_z,        --赠品数量

                    --sum(isnull(oool.oMoney,0)) oMoney_z,            --赠品单据金额

                    sum(isnull(ooool.oQuantity,0)) oQuantity_y,    --样品数量

                    --sum(isnull(ooool.oMoney,0)) oMoney_y,            --样品单据金额

                    sum(isnull(oooool.oQuantity,0)) oQuantity_sz    --销售赠品数量

                    --sum(isnull(oooool.oMoney,0)) oMoney_sz            --销售赠品单据金额


                from (select _s.StaffID,_p.ProductClassID,_p.ProductsID,_p.CoPrice

                 from tbStaffInfo _s ,@Products _p) as s

                --销售

                left join 

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=3  group by StaffID,ProductsID) as oo on oo.StaffID=s.StaffID and oo.ProductsID=s.ProductsID

                --退货

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity,sum(isnull(oMoney,0)) oMoney from @OrderList_tem as o where oType=4  group by StaffID,ProductsID) as ool on ool.StaffID=s.StaffID and ool.ProductsID=s.ProductsID

                --赠品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=5  group by StaffID,ProductsID) as oool on oool.StaffID=s.StaffID and oool.ProductsID=s.ProductsID

                --样品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=6  group by StaffID,ProductsID) as ooool on ooool.StaffID=s.StaffID and ooool.ProductsID=s.ProductsID

                --销售赠品

                left join

                (select StaffID,ProductsID,sum(isnull(oQuantity,0)) oQuantity from @OrderList_tem as o where oType=3 and IsGifts<>0  group by StaffID,ProductsID) as oooool on oooool.StaffID=s.StaffID and oooool.ProductsID=s.ProductsID

            
                group by s.StaffID,s.ProductsID

                ) as ss on ps.StaffID=ss.StaffID

            left join @Products ppp on ppp.ProductsID=ss.ProductsID

        where (ss.oQuantity<>0 or ss.oMoney<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0 or ss.oQuantity_t<>0 or ss.oMoney_t<>0

        or ss.oQuantity_z<>0  or ss.oQuantity_y<>0  or ss.oQuantity_sz<>0 )

        order by  ps.DepartmentsClassID,ps.StaffID,ppp.ProductClassID,ppp.ProductsID desc;

    end
/**/
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSalesReport]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetSalesReport]
	(
	@ReType int = 1,		--商品销售=1,客户销售=2,结算系统=3
	@bDate datetime,		--开始时间
	@eDate datetime,		--结束时间
	@NOJoinSales int = 0,	--剔除联营数据,不剔除=0,剔除=1,仅联营=2
	@StoresID int=0,			--指定客户
	@PaymentSystemID int=0	--指定结算系统
	)
AS
begin

set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');
set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

declare @tBDate datetime,@tEDate datetime;

set @tBDate = dateadd(DAY,-365,getdate());
set @tEDate = dateadd(DAY,365,getdate());

--整理商品变价数据
--exec sp_GetProductCostValence 0,null;

--整理商品联营数据
--exec sp_GetProductPoolList 0,@tBDate,@tEDate;

	--商品销售
	if @ReType = 1
	begin
		--全部
		if @NOJoinSales=0
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
				
				select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
							(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
							(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
							(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
							(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
				 from(
					select p.*,pc.pClassName,
					isnull(oo.oQuantity,0) oQuantity,			--销售数量
					isnull(oo.oMoney,0) oMoney,					--销售金额
					isnull(ool.oQuantity_t,0) oQuantity_t,		--销售退货数量
					isnull(ool.oMoney_t,0) oMoney_t,			--销售退货金额
					isnull(oool.oQuantity_z,0) oQuantity_z,		--赠品数量
					isnull(oool.oMoney_z,0) oMoney_z,			--赠品单据金额
					isnull(ooool.oQuantity_y,0) oQuantity_y,	--样品数量
					isnull(ooool.oMoney_y,0) oMoney_y,			--样品单据金额
					isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
					isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额

					isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
					from tbProductsInfo as p 
					left join
					--销售
					(select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=3 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and  OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5)   ) and ol.oWorkType=2 group by ol.ProductsID) as oo 
					on p.ProductsID=oo.ProductsID
					left join
					--销售 成本
					(select col.ProductsID,isnull(sum(col.oQuantity),0) oQuantity_c from tbOrderListInfo col where  col.OrderID in(select OrderID from tbOrderInfo where oType=3 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and  OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5)   ) and col.oWorkType=2 group by col.ProductsID) as coo 
					on p.ProductsID=coo.ProductsID
					left join
					--退货 成本
					(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=4 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and oll.oWorkType=2 group by oll.ProductsID) as ool
					on p.ProductsID=ool.ProductsID
					left join
					--赠品 成本
					(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll where olll.OrderID in(select OrderID from tbOrderInfo where oType=5 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olll.oWorkType=2 group by olll.ProductsID) as oool
					on p.ProductsID=oool.ProductsID
					left join
					--样品 成本
					(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll where ollll.OrderID in(select OrderID from tbOrderInfo where oType=6 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
					on p.ProductsID=ooool.ProductsID
					left join
					--坏货 成本
					(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
					on p.ProductsID=oooool.ProductsID
					 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					 ) as ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
								(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
								(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
								(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
								(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					 from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=3 and StoresID=@StoresID and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=4 and StoresID=@StoresID and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll where olll.OrderID in(select OrderID from tbOrderInfo where oType=5 and StoresID=@StoresID and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll where ollll.OrderID in(select OrderID from tbOrderInfo where oType=6 and StoresID=@StoresID and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
			end
			else
			begin
				if @PaymentSystemID>0
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						 from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=3 and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=4 and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll where olll.OrderID in(select OrderID from tbOrderInfo where oType=5 and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll where ollll.OrderID in(select OrderID from tbOrderInfo where oType=6 and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType=3 and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType=4 and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll where olll.OrderID in(select OrderID from tbOrderInfo where oType=5 and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll where ollll.OrderID in(select OrderID from tbOrderInfo where oType=6 and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
			 end
		end
		--剔除联营
		if @NOJoinSales=1
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.StoresID=@StoresID and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.StoresID=@StoresID and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.StoresID=@StoresID and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and  oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.StoresID=@StoresID and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.StoresID=@StoresID and  oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end

			end
			else
			begin
				if @PaymentSystemID>0
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.oType=4 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and  oiii.oType=5 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.oType=6 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
						) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and  oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end

			 end
		end
		--仅联营
		if @NOJoinSales=2
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.StoresID=@StoresID and  oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					 ) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.StoresID=@StoresID and  oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				
			end
			else
			begin
				if @PaymentSystemID>0
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and  oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
				else
				begin
					select ps.*,(ps.oQuantity*ISNULL(ps.CostPrice,0)) CostPrice_s,		--销售成本
									(ps.oQuantity_t*ISNULL(ps.CostPrice,0)) CostPrice_t,	--退货成本
									(ps.oQuantity_z*ISNULL(ps.CostPrice,0)) CostPrice_z,	--赠品成本
									(ps.oQuantity_y*ISNULL(ps.CostPrice,0)) CostPrice_y,	--样品成本
									(ps.oQuantity_h*ISNULL(ps.CostPrice,0)) CostPrice_h		--坏货成本
					from(
						select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.oQuantity_z,0) oQuantity_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.oQuantity_y,0) oQuantity_y,isnull(ooool.oMoney_y,0) oMoney_y,
						isnull(oooool.oQuantity_h,0) oQuantity_h,	--坏货数量
						isnull(oooool.oMoney_h,0) oMoney_h,			--坏货单据金额
						isnull(dbo.fun_GetProductPrice(p.ProductsID,0,@bDate,@eDate,1,0,1),0) as CostPrice	--成本
						from tbProductsInfo as p left join(
						--销售
						select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by ol.ProductsID
						) as oo on p.ProductsID=oo.ProductsID
						left join 
						--退货
						(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oll.ProductsID) as ool
						on p.ProductsID=ool.ProductsID
						left join
						--赠品
						(select olll.ProductsID,isnull(sum(olll.oQuantity),0) oQuantity_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and  oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by olll.ProductsID) as oool
						on p.ProductsID=oool.ProductsID
						left join
						--样品
						(select ollll.ProductsID,isnull(sum(ollll.oQuantity),0) oQuantity_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by ollll.ProductsID) as ooool
						on p.ProductsID=ooool.ProductsID
						left join
						--坏货
						(select olllll.ProductsID,isnull(sum(olllll.oQuantity),0) oQuantity_h,isnull(sum(olllll.oMoney),0) oMoney_h from tbOrderListInfo olllll where olllll.OrderID in(select OrderID from tbOrderInfo where oType=10 and StoresID=@StoresID and StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oState=0 and oSteps=5 and OrderID in(select OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and oType=5) ) and olllll.oWorkType=2 group by olllll.ProductsID) as oooool
						on p.ProductsID=oooool.ProductsID
						 left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID
					) ps order by  ps.ProductClassID,ps.ProductsID desc;
				end
			end
		end
	end
	
	--客户销售
	if @ReType = 2
	begin
		--全部
		if @NOJoinSales=0
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.StoresID=@StoresID and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.StoresID=@StoresID and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.StoresID=@StoresID and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.StoresID=@StoresID and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
						left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.StoresID=@StoresID and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.StoresID=@StoresID and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.StoresID=@StoresID and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.StoresID=@StoresID and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
						left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
			end
			else
			begin
				if @PaymentSystemID>0
				begin
						select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
						--销售
						select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
						) as oo on s.StoresID=oo.StoresID
						left join 
						--退货
						(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
						on s.StoresID=ool.StoresID
						left join
						--赠品
						(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
						on s.StoresID=oool.StoresID
						left join
						--样品
						(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
						on s.StoresID=ooool.StoresID
						 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
			 end
		end
		--剔除联营
		if @NOJoinSales=1
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.StoresID=@StoresID and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.StoresID=@StoresID and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.StoresID=@StoresID and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.StoresID=@StoresID and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.StoresID=@StoresID and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
			end
			else
			begin
				if @PaymentSystemID>0
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
			 end
		end
		--仅联营
		if @NOJoinSales=2
		begin
			if @StoresID>0
			begin
				if @PaymentSystemID>0
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.StoresID=@StoresID and oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.StoresID=@StoresID and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID order by  cc.CustomersClassID,s.StoresID desc;
				end
			end
			else
			begin
				if @PaymentSystemID>0
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.oType=3 and oi.oState=0 and oi.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.oType=4 and oii.oState=0 and oii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.oType=5 and oiii.oState=0 and oiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.oType=6 and oiiii.oState=0 and oiiii.StoresID in(select StoresID from tbStoresInfo where PaymentSystemID=@PaymentSystemID) and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
				else
				begin
					
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID order by  cc.CustomersClassID,s.StoresID desc;
				end
			 end
		end
	end

	--结算系统销售
	if @ReType = 3
	begin
		--全部
		if @NOJoinSales=0
		begin
			if @StoresID>0
			begin
				select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.StoresID=@StoresID and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.StoresID=@StoresID and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.StoresID=@StoresID and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.StoresID=@StoresID and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
						left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID 
						) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
				end
			else
			begin
				select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
					select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
					--销售
					select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
					) as oo on s.StoresID=oo.StoresID
					left join 
					--退货
					(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
					on s.StoresID=ool.StoresID
					left join
					--赠品
					(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
					on s.StoresID=oool.StoresID
					left join
					--样品
					(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
					on s.StoresID=ooool.StoresID
					 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID 
					 ) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
			 end
		end
		--剔除联营
		if @NOJoinSales=1
		begin
			if @StoresID>0
			begin
			select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
				select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
				--销售
				select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
				) as oo on s.StoresID=oo.StoresID
				left join 
				--退货
				(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
				on s.StoresID=ool.StoresID
				left join
				--赠品
				(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.StoresID=@StoresID and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
				on s.StoresID=oool.StoresID
				left join
				--样品
				(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
				on s.StoresID=ooool.StoresID
				 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID 
				  ) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
			end
			else
			begin
			select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
				select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
				--销售
				select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
				) as oo on s.StoresID=oo.StoresID
				left join 
				--退货
				(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
				on s.StoresID=ool.StoresID
				left join
				--赠品
				(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=0 and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
				on s.StoresID=oool.StoresID
				left join
				--样品
				(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=0 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
				on s.StoresID=ooool.StoresID
				 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID 
				 ) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
			 end
		end
		--仅联营
		if @NOJoinSales=2
		begin
			if @StoresID>0
			begin
			select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
				select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
				--销售
				select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.StoresID=@StoresID and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
				) as oo on s.StoresID=oo.StoresID
				left join 
				--退货
				(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.StoresID=@StoresID and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
				on s.StoresID=ool.StoresID
				left join
				--赠品
				(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.StoresID=@StoresID and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
				on s.StoresID=oool.StoresID
				left join
				--样品
				(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.StoresID=@StoresID and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
				on s.StoresID=ooool.StoresID
				 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID where s.StoresID=@StoresID 
				 ) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
			end
			else
			begin
			select ps.pName,isnull(sum(isnull(sss.CostPrice,0)),0) CostPrice,
										isnull(sum(isnull(sss.oMoney,0)),0) oMoney,
										isnull(sum(isnull(sss.CostPrice_t,0)),0) CostPrice_t,
										isnull(sum(isnull(sss.oMoney_t,0)),0) oMoney_t,
										isnull(sum(isnull(sss.CostPrice_z,0)),0) CostPrice_z,
										isnull(sum(isnull(sss.oMoney_z,0)),0) oMoney_z,
										isnull(sum(isnull(sss.oMoney_y,0)),0) oMoney_y,
										isnull(sum(isnull(sss.CostPrice_y,0)),0) CostPrice_y
				 from tbPaymentSystemInfo ps left join (
				select s.*,cc.cClassName,isnull(oo.CostPrice,0) CostPrice,isnull(oo.oMoney,0) oMoney,isnull(ool.CostPrice_t,0) CostPrice_t,isnull(ool.oMoney_t,0) oMoney_t,isnull(oool.CostPrice_z,0) CostPrice_z,isnull(oool.oMoney_z,0) oMoney_z,isnull(ooool.CostPrice_y,0) CostPrice_y,isnull(ooool.oMoney_y,0) oMoney_y from tbStoresInfo as s left join(
				--销售
				select oi.StoresID,isnull(sum(ol.oQuantity*dbo.fun_GetProductPrice(ol.ProductsID,0,oi.oOrderDateTime,oi.oOrderDateTime,1,0,1)),0) CostPrice,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1 and oi.oType=3 and oi.oState=0 and oi.oSteps=5 and oi.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ol.oWorkType=2 group by oi.StoresID
				) as oo on s.StoresID=oo.StoresID
				left join 
				--退货
				(select oii.StoresID,isnull(sum(oll.oQuantity*dbo.fun_GetProductPrice(oll.ProductsID,0,oii.oOrderDateTime,oii.oOrderDateTime,1,0,1)),0) CostPrice_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1 and oii.oType=4 and oii.oState=0 and oii.oSteps=5 and oii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and oll.oWorkType=2 group by oii.StoresID) as ool
				on s.StoresID=ool.StoresID
				left join
				--赠品
				(select oiii.StoresID,isnull(sum(olll.oQuantity*dbo.fun_GetProductPrice(olll.ProductsID,0,oiii.oOrderDateTime,oiii.oOrderDateTime,1,0,1)),0) CostPrice_z,isnull(sum(olll.oMoney),0) oMoney_z from tbOrderListInfo olll left join tbOrderInfo oiii on oiii.OrderID=olll.OrderID where dbo.fun_CheckProductIsPool(olll.ProductsID,oiii.oOrderDateTime)=1 and oiii.oType=5 and oiii.oState=0 and oiii.oSteps=5 and oiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and olll.oWorkType=2 group by oiii.StoresID) as oool
				on s.StoresID=oool.StoresID
				left join
				--样品
				(select oiiii.StoresID,isnull(sum(ollll.oQuantity*dbo.fun_GetProductPrice(ollll.ProductsID,0,oiiii.oOrderDateTime,oiiii.oOrderDateTime,1,0,1)),0) CostPrice_y,isnull(sum(ollll.oMoney),0) oMoney_y from tbOrderListInfo ollll left join tbOrderInfo oiiii on oiiii.OrderID=ollll.OrderID where dbo.fun_CheckProductIsPool(ollll.ProductsID,oiiii.oOrderDateTime)=1 and oiiii.oType=6 and oiiii.oState=0 and oiiii.oSteps=5 and oiiii.OrderID in (select tbOrderWorkingLogInfo.OrderID from tbOrderWorkingLogInfo where tbOrderWorkingLogInfo.pAppendTime between @bDate and @eDate and tbOrderWorkingLogInfo.oType=5) and ollll.oWorkType=2 group by oiiii.StoresID) as ooool
				on s.StoresID=ooool.StoresID
				 left join tbCustomersClassInfo cc on cc.CustomersClassID=s.CustomersClassID 
				  ) sss on ps.PaymentSystemID=sss.PaymentSystemID group by ps.pName,ps.PaymentSystemID  order by ps.PaymentSystemID desc;
			 end
		end
	end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_AssociteProductsDetails_do]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AssociteProductsDetails_do]
   @inyStorehouseID int,      --门店编号
   @inyAssociteID int,        --选择类型
   @dtmDateTime datetime,     --选择时间
   @inyQid  int               --统计类型 0=合成统计；1=分步统计
AS
   declare @productsID int
   set @dtmDateTime=convert(datetime,CONVERT(varchar,DATEPART(YEAR,@dtmDateTime))+'-'+CONVERT(varchar,DATEPART(MONTH,@dtmDateTime))+'-'+CONVERT(varchar,DATEPART(DAY,@dtmDateTime)))
BEGIN
      --合成统计
      if(@inyQid=0)
      begin
        if @inyAssociteID =-1  --包含联营
        begin
            select ProductsID,sName,pName,pBarcode,pBrand,isnull(sum(pRelityStorage),0) as pRelityStorage,pAppendTime from tbStoreStorehouseInfo where pAppendTime=@dtmDateTime
            and pRelityStorage !=0 and StoresID=@inyStorehouseID group by ProductsID,sName,pName,pBarcode,pBrand,pAppendTime order by ProductsID asc
        end
        if @inyAssociteID =0 --剔除联营
        begin
            select ProductsID,sName,pName,pBarcode,pBrand,isnull(sum(pRelityStorage),0) as pRelityStorage,pAppendTime from tbStoreStorehouseInfo where pAppendTime=@dtmDateTime
			 and pRelityStorage !=0 and StoresID=@inyStorehouseID and ProductsID not in(select ProductsID from tbProductPoolDataInfo where Edate>@dtmDateTime) 
			 group by ProductsID,sName,pName,pBarcode,pBrand,pAppendTime order by ProductsID asc
        end
        if @inyAssociteID =1 --仅联营
        begin
             select ProductsID,sName,pName,pBarcode,pBrand,isnull(sum(pRelityStorage),0) as pRelityStorage,pAppendTime from tbStoreStorehouseInfo where pAppendTime=@dtmDateTime
			 and pRelityStorage !=0 and StoresID=@inyStorehouseID and ProductsID in(select ProductsID from tbProductPoolDataInfo where Edate>@dtmDateTime) 
			 group by ProductsID,sName,pName,pBarcode,pBrand,pAppendTime order by ProductsID asc
        end
      end  
      --分步统计
      if(@inyQid=1)
      begin
		  declare @tbPandMoneyDetal table(
				storesID int,
				sName varchar(50),
				pName varchar(50),
				pBarcode varchar(50),
				productsID int,
				quantity numeric,
				qmoney  money,
				pmoney money,
				pAppendtime datetime
				)
		  if @inyAssociteID =-1  --包含联营
		  begin
			declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0   
			open cour 
			fetch next from cour into @productsID
			WHILE @@FETCH_STATUS=0
			begin
			 insert into @tbPandMoneyDetal(storesID,sName,pName,pBarcode,productsID,quantity,qmoney,pmoney,pAppendtime)
			 select qq.StoresID,qq.sName,p.pName,p.pBarcode,qq.ProductsID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendTime from 
			 (select sName,StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
			 tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
			 and StoresID=@inyStorehouseID) as qq  left join tbProductsInfo as p on qq.ProductsID=p.ProductsID
			fetch next from cour into @productsID
			end
			select sName,pName,pBarcode,isnull(sum(quantity),0) as pRelityStorage,isnull(sum(pmoney),0) as pMoney,isnull(sum(qmoney),0) as qMoney,pAppendtime from @tbPandMoneyDetal
			group by   sName,pName,pBarcode,pAppendtime
			close cour 
			deallocate cour
		  end
		  
		  if @inyAssociteID =0 --剔除联营
		  begin 
			declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
			open cour 
			fetch next from cour into @productsID
			WHILE @@FETCH_STATUS=0
			begin
			  insert into @tbPandMoneyDetal(storesID,sName,pName,pBarcode,productsID,quantity,qmoney,pmoney,pAppendtime)
			  select qq.StoresID,qq.sName,p.pName,p.pBarcode,qq.ProductsID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendTime from 
			 (select sName,StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
			 tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
			 and StoresID=@inyStorehouseID  
			 and ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime))
			 as qq  left join tbProductsInfo as p on qq.ProductsID=p.ProductsID
			fetch next from cour into @productsID
			end
			   select sName,pName,pBarcode,isnull(sum(quantity),0) as pRelityStorage,isnull(sum(pmoney),0) as pMoney,isnull(sum(qmoney),0) as qMoney,pAppendtime from @tbPandMoneyDetal
			   group by   sName,pName,pBarcode,pAppendtime
			close cour 
			deallocate cour
		  end 
		  
		  if @inyAssociteID =1 --仅联营
		  begin
			 declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
			open cour 
			fetch next from cour into @productsID
			WHILE @@FETCH_STATUS=0
			begin
			  insert into @tbPandMoneyDetal(storesID,sName,pName,pBarcode,productsID,quantity,qmoney,pmoney,pAppendtime)
			 select qq.StoresID,qq.sName,p.pName,p.pBarcode,qq.ProductsID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendTime from 
			(select sName,StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
			 tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
			 and StoresID=@inyStorehouseID  and ProductsID 
			 in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime))
			  as qq  left join tbProductsInfo as p on qq.ProductsID=p.ProductsID
			fetch next from cour into @productsID
			end
				select sName,pName,pBarcode,isnull(sum(quantity),0) as pRelityStorage,isnull(sum(pmoney),0) as pMoney,isnull(sum(qmoney),0) as qMoney,pAppendtime from @tbPandMoneyDetal
			    group by   sName,pName,pBarcode,pAppendtime
			close cour 
			deallocate cour
		  end
	  end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AssociteProductsDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ANGOL
-- Create date: 2011-5-23
-- Description:	获得门店库存联营详情
-- =============================================
CREATE PROCEDURE [dbo].[sp_AssociteProductsDetails]
	@inyRegoin int,         --区域ID
	@inyType int,           --是否联营；-1：包含；0：剔除；1：仅包含
	@dtmDateTime datetime   --日期
AS
    select @dtmDateTime=convert(datetime,CONVERT(varchar,DATEPART(YEAR,@dtmDateTime))+'-'+CONVERT(varchar,DATEPART(MONTH,@dtmDateTime))+'-'+CONVERT(varchar,DATEPART(DAY,@dtmDateTime)))
    declare @productsID int
BEGIN
    declare @tbPandMoneyDetal table(
            storesID int,
            productsID int,
            quantity numeric,
            qmoney  money,
            pmoney money,
            pAppendtime datetime
            )
    --全部区域:包含联营
    if @inyRegoin=0 and @inyType=-1 
	  begin
	    declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
	     insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime,@dtmDateTime)*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	    fetch next from cour into @productsID
	    end
	     
	    select si.sName,si.sType,qq.storesID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour 
		deallocate cour
	  end
    --全部区域：剔除联营
    if @inyRegoin=0 and @inyType=0
      begin
       declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
         insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	     and ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime)
		  fetch next from cour into @productsID
	     end
	    
	     select si.sName,si.sType,qq.storesID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour
		deallocate cour
      end
    --全部区域：仅联营
    if @inyRegoin=0 and @inyType=1
      begin
       declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
        insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	     and ProductsID in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime)
		  fetch next from cour into @productsID
	     end
	    
	     select si.sName,si.sType,qq.storesID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour
		deallocate cour
      end    
	--选择区域：包含联营
	if @inyRegoin>0 and @inyType=-1
	  begin
	   declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
	     insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	     and StoresID in(select StoresID from tbStoresInfo where RegionID=@inyRegoin)
	    fetch next from cour into @productsID
	    end
	     
	    select si.sName,si.sType,qq.storesID,isnull(qq.pRelityStorage,0) as pRelityStorage,isnull(qq.pMoney,0) as pMoney,isnull(qq.qMoney,0) as qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour
		deallocate cour
	  end
	
	--选择区域：剔除联营
	if @inyRegoin>0 and @inyType=0
	  begin
	   declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
	    insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	     and ProductsID not in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime)
	     and StoresID in(select StoresID from tbStoresInfo where RegionID=@inyRegoin)
	    fetch next from cour into @productsID
	    end
	     
	    select si.sName,si.sType,qq.storesID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour
		deallocate cour
	  end
	--选择区域：仅联营
	if @inyRegoin>0 and @inyType=1
	  begin
	   declare cour cursor for select distinct(ProductsID) from tbStoreStorehouseInfo where pRelityStorage !=0
	    open cour 
	    fetch next from cour into @productsID
	    WHILE @@FETCH_STATUS=0
	     begin
	    insert into @tbPandMoneyDetal(storesID,productsID,quantity,qmoney,pmoney,pAppendtime)
	     select StoresID,ProductsID,pRelityStorage,isnull(dbo.fun_GetProductPriceXP(@productsID,@dtmDateTime+' 00:00:00',@dtmDateTime+' 23:59:59')*pRelityStorage,0) as qMoney,isnull(pMoney,0) as pMoney,pAppendTime from
	     tbStoreStorehouseInfo where pAppendTime=@dtmDateTime and ProductsID=@productsID and pRelityStorage !=0
	     and ProductsID in (select ProductsID from tbProductPoolDataInfo where Edate>=@dtmDateTime)
	     and StoresID in(select StoresID from tbStoresInfo where RegionID=@inyRegoin)
	    fetch next from cour into @productsID
	    end
	     
	    select si.sName,si.sType,qq.storesID,qq.pRelityStorage,qq.pMoney,qq.qMoney,qq.pAppendtime from 
	    (select storesID,pAppendtime,sum(quantity) as pRelityStorage,sum(qmoney) as qMoney,sum(pmoney) as pMoney from @tbPandMoneyDetal
	    group by storesID,pAppendtime) as qq left join tbStoresInfo as si on qq.storesID=si.StoresID
		close cour
		deallocate cour
	  end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ErpCustomerPay]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ErpCustomerPay]
/*返回指定客户,指定时间段内应付账款信息*/
	(
	@C_CODE varchar(50) = '',		--客户编号
	@C_NAME varchar(128) = '',		--客户名称
	@bDate	datetime = null,		--开始时间
	@eDate	datetime = null,		--结束时间
	@PaySystemName varchar(128) = ''--结算系统名称
	)
AS
begin

	declare @tSQLwhere varchar(3000);
	declare @tSQLwhere_a varchar(1000);
	declare @tSQLwhere_b varchar(1000);	
	declare @tSQLwhere_c varchar(1000);	
	declare @tSQLwhere_d varchar(1000);	
	declare @tSQLwhere_e varchar(1000);	
	
	--销售发货tbErpOrderInfo.O_CREATETIME>='''+CAST(@bDate as varchar(50))+''' and
	set @tSQLwhere_a = ' and tbErpOrderInfo.IsCheck=0 and tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=1';
	--销售退货
	set @tSQLwhere_b = ' and tbErpOrderInfo.IsCheck=0 and tbErpOrderInfo.O_CREATETIME<='''+CAST(@eDate as varchar(50))+''' and tbErpOrderInfo.R_ID=5';
	
	--排除联营期间内产品销售记录
	If object_id('tempdb..#ProductPoolList_tmp') is  not null
	Drop table #ProductPoolList_tmp
	--创建新临时表
	Create table #ProductPoolList_tmp (
						ProductPoolID int,
						ProductsID int,			--产品编号
						bdate datetime,			--上岗时间
						edate datetime			--下岗时间
					)
	insert into #ProductPoolList_tmp(ProductPoolID,ProductsID,bdate,edate) exec sp_GetProductPoolList 0,@bDate,@eDate;
	
	--联营产品销售单据
	set @tSQLwhere_e = 'and tbErpOrderInfo.ErpOrderID not in(select tbErpOrderInfo.ErpOrderID from #ProductPoolList_tmp where bdate>=tbErpOrderInfo.O_CREATETIME and edate<=tbErpOrderInfo.O_CREATETIME and ProductsID=tbErpOrderInfo.ProductsID)';
	
	if @PaySystemName = ''
	begin
		if @C_CODE = '' and @C_NAME=''
		begin
			
			set @tSQLwhere = 'select tbStoresInfo.StoresID,tbStoresInfo.sName,tbStoresInfo.sCode,sDoDayMoney,
			 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' '+CAST(@tSQLwhere_e as varchar(1000))+' ) as DeliveryMoney,
			 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
			 (select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as AMoney,
			 (select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as ActualMoney  
			from tbStoresInfo where tbStoresInfo.sState=0 order by DeliveryMoney desc';
			
			exec(@tSQLwhere);
			
		end
		else
		begin
			
			--单个客户应付账款
			if @C_CODE = ''
			begin
				--set @tSQLwhere = 'select sum(tbErpOrderInfo.S_TOTAL) from tbErpOrderInfo where tbErpOrderInfo.C_NAME='''+CAST(@C_NAME as varchar(128))+'''';
				--set @tSQLwhere_c = 'select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID in(select tbStoresInfo.StoresID from tbStoresInfo where tbStoresInfo.sName='''+CAST(@C_NAME as varchar(128))+''')';
				
				set @tSQLwhere = 'select tbStoresInfo.StoresID,tbStoresInfo.sName,tbStoresInfo.sCode,sDoDayMoney,
				 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' '+CAST(@tSQLwhere_e as varchar(1000))+') as DeliveryMoney,
				 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
				 (select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as AMoney,
				 (select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as ActualMoney  
				from tbStoresInfo where tbStoresInfo.sState=0 and tbStoresInfo.sName='''+CAST(@C_NAME as varchar(128))+''' order by DeliveryMoney desc';
				
				exec(@tSQLwhere);
				
				
			end
			else
			begin
				--set @tSQLwhere = 'select sum(tbErpOrderInfo.S_TOTAL) from tbErpOrderInfo where tbErpOrderInfo.C_CODE='''+CAST(@C_CODE as varchar(50))+'''';
				--set @tSQLwhere_d = 'select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID in(select tbStoresInfo.StoresID from tbStoresInfo where tbStoresInfo.sCode='''+CAST(@C_CODE as varchar(128))+''')';
				
				set @tSQLwhere = 'select tbStoresInfo.StoresID,tbStoresInfo.sName,tbStoresInfo.sCode,sDoDayMoney,
				 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' '+CAST(@tSQLwhere_e as varchar(1000))+') as DeliveryMoney,
				 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
				 (select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as AMoney,
				 (select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as ActualMoney  
				from tbStoresInfo where tbStoresInfo.sState=0 and tbStoresInfo.sCode='''+CAST(@C_CODE as varchar(50))+''' order by DeliveryMoney desc';
				
				exec(@tSQLwhere);
				
			end

		end
	end
	else
	begin
	
		if @PaySystemName = '*'
		begin
			set @tSQLwhere = 'select p.PaymentSystemID,p.pName,p.pAppendTime,m.DeliveryMoney,m.ReturnMoney,m.AMoney,m.ActualMoney from tbPaymentSystemInfo as p, (
								select tM.PaymentSystemID,sum(isnull(tM.DeliveryMoney,0)) as DeliveryMoney,sum(isnull(tM.ReturnMoney,0)) as ReturnMoney,sum(isnull(tM.AMoney,0)) as AMoney,sum(isnull(tM.ActualMoney,0)) as ActualMoney from (
									select tbStoresInfo.StoresID,tbStoresInfo.sName,tbStoresInfo.sCode,sDoDayMoney,tbStoresInfo.PaymentSystemID,
									 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' '+CAST(@tSQLwhere_e as varchar(1000))+' ) as DeliveryMoney,
									 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
									 (select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as AMoney,
									 (select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as ActualMoney  
									from tbStoresInfo where tbStoresInfo.sState=0 ) as tM group by tM.PaymentSystemID) as m 
								where p.PaymentSystemID=m.PaymentSystemID order by m.DeliveryMoney desc';
		end
		else
		begin
			set @tSQLwhere = 'select p.PaymentSystemID,p.pName,p.pAppendTime,m.DeliveryMoney,m.ReturnMoney,m.AMoney,m.ActualMoney from tbPaymentSystemInfo as p, (
						select tM.PaymentSystemID,sum(isnull(tM.DeliveryMoney,0)) as DeliveryMoney,sum(isnull(tM.ReturnMoney,0)) as ReturnMoney,sum(isnull(tM.AMoney,0)) as AMoney,sum(isnull(tM.ActualMoney,0)) as ActualMoney from (
							select tbStoresInfo.StoresID,tbStoresInfo.sName,tbStoresInfo.sCode,sDoDayMoney,tbStoresInfo.PaymentSystemID,
							 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_a as varchar(1000))+' '+CAST(@tSQLwhere_e as varchar(1000))+' ) as DeliveryMoney,
							 (select isnull(sum(tbErpOrderInfo.S_TOTAL),0) from tbErpOrderInfo where tbErpOrderInfo.C_CODE=tbStoresInfo.sCode '+CAST(@tSQLwhere_b as varchar(1000))+' ) as ReturnMoney,
							 (select isnull(sum(tbARMoneyInfo.aAMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as AMoney,
							 (select isnull(sum(tbARMoneyInfo.aActualMoney),0) from tbARMoneyInfo where tbARMoneyInfo.ARObjType=0 and tbARMoneyInfo.ARObjID=tbStoresInfo.StoresID ) as ActualMoney  
							from tbStoresInfo where tbStoresInfo.sState=0 ) as tM group by tM.PaymentSystemID) as m 
						where p.PaymentSystemID=m.PaymentSystemID and p.pName like ''%'+CAST(@PaySystemName as varchar(128))+'%'' order by m.DeliveryMoney desc';

		end
		exec(@tSQLwhere);
	end
	Drop table #ProductPoolList_tmp;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ErpData_fees_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ErpData_fees_analysis]
	/*
	费用分析
	*/
	@StoresID int,			--门店,客户编号 
	@bDate datetime,		--开始时间
	@eDate datetime			--结束时间
AS
begin
	declare @AllSales money;		--销售额
	declare @AllCost money;			--成本
	declare @AllReturns money;		--退货
	declare @AllBadgoods money;		--坏货
	declare @AllGifts money;		--赠品
	declare @AllSalesCost money;	--销售费用

	set @AllSales = 0;
	set @AllCost = 0;
	set @AllReturns = 0;
	set @AllBadgoods = 0;
	set @AllGifts = 0;
	set @AllSalesCost = 0;
	
	--删除原数据
	If object_id('tempdb..#ErpProductCostPrice_antmp') is  not null
	Drop table #ErpProductCostPrice_antmp
	--创建新临时表
	Create table #ErpProductCostPrice_antmp (CostVelenceID int,ProductsID int,		--产品编号
						cPrice money,			--成本
						bdate datetime,			--开始时间
						edate datetime			--结束时间
					)
	
	insert into #ErpProductCostPrice_antmp exec sp_GetProductCostValence;
	
	--发货
	select @AllSales=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@StoresID;
		
	--退货
	select @AllReturns=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@StoresID;
	
	--成本
	select @AllCost=isnull(sum(isnull(te.tValue,0)),0) from(
		select (select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate) as tValue from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@StoresID
		) as te;
		
	--坏货
	select @AllBadgoods=isnull(sum(isnull(te.tValue,0)),0) from(
		select (select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate) as tValue from tbErpOrderInfo as e where e.R_ID=6 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@StoresID
		) as te;
	
	--赠品
	select @AllGifts=isnull(sum(isnull(te.tValue,0)),0) from(
		select (select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate) as tValue from tbErpOrderInfo as e where e.R_ID=2 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@StoresID
		) as te;
	
	--销售费用
	select @AllSalesCost=isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where mType=0 and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate and StoresID=@StoresID
	
	
	select @AllSales,@AllCost,@AllReturns,@AllBadgoods,@AllGifts,@AllSalesCost;
	
	Drop table #ErpProductCostPrice_antmp;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOutReport]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetOutReport]
	(
	--出货时间:销售,赠品,样品,坏货 单据的发货时间
	--退货时间:退货单的 收货时间
	@ReType int = 1,		--商品=1,客户=2
	@bDate datetime,		--开始时间
	@eDate datetime,		--结束时间
	@NOJoinSales int =0--剔除联营,不剔除=0,剔除=1,仅联营=2
	)
AS
begin

set @bDate = convert(datetime,convert(varchar,DATEPART(year,@bDate))+'-'+convert(varchar,DATEPART(month,@bDate))+'-'+convert(varchar,DATEPART(day,@bDate))+' 00:00:00');
set @eDate = convert(datetime,convert(varchar,DATEPART(year,@eDate))+'-'+convert(varchar,DATEPART(month,@eDate))+'-'+convert(varchar,DATEPART(day,@eDate))+' 23:59:59');

declare @tBDate datetime,@tEDate datetime;

set @tBDate = dateadd(DAY,-365,getdate());
set @tEDate = dateadd(DAY,365,getdate());

	--商品
	if @ReType = 1
	begin
		--全部
		if @NOJoinSales = 0
		begin
		select ppp.* from (
				select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t from tbProductsInfo as p left join(
				--出货
				select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7,10) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and ol.oWorkType=0 group by ol.ProductsID
				) as oo on p.ProductsID=oo.ProductsID
				left join 
				--退货
				(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType in(4) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and oll.oWorkType=0 group by oll.ProductsID) as ool
				on oo.ProductsID=ool.ProductsID
				left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID) as ppp where ppp.oQuantity<>0 or ppp.oMoney<>0 or ppp.oQuantity_t<>0 or ppp.oMoney_t<>0 order by  ppp.ProductClassID,ppp.ProductsID desc;
		end
		--剔除
		if @NOJoinSales = 1
		begin
		select ppp.* from (
				select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t from tbProductsInfo as p left join(
				--出货
				select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7,10) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and dbo.fun_CheckProductIsPool(ol.ProductsID,(select oOrderDateTime from tbOrderInfo where OrderID=ol.OrderID))=0 and ol.oWorkType=0 group by ol.ProductsID
				) as oo on p.ProductsID=oo.ProductsID
				left join 
				--退货
				(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType in(4) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and dbo.fun_CheckProductIsPool(oll.ProductsID,(select oOrderDateTime from tbOrderInfo where OrderID=oll.OrderID))=0 and oll.oWorkType=0 group by oll.ProductsID) as ool
				on oo.ProductsID=ool.ProductsID
				left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID) as ppp where ppp.oQuantity<>0 or ppp.oMoney<>0 or ppp.oQuantity_t<>0 or ppp.oMoney_t<>0  order by  ppp.ProductClassID,ppp.ProductsID desc;
		end
		--仅联营
		if @NOJoinSales = 2
		begin
		select ppp.* from (
				select p.*,pc.pClassName,isnull(oo.oQuantity,0) oQuantity,isnull(oo.oMoney,0) oMoney,isnull(ool.oQuantity_t,0) oQuantity_t,isnull(ool.oMoney_t,0) oMoney_t from tbProductsInfo as p left join(
				--出货
				select ol.ProductsID,isnull(sum(ol.oQuantity),0) oQuantity,isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol where  ol.OrderID in(select OrderID from tbOrderInfo where oType in(3,5,6,7,10) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and dbo.fun_CheckProductIsPool(ol.ProductsID,(select oOrderDateTime from tbOrderInfo where OrderID=ol.OrderID))=1 and ol.oWorkType=0 group by ol.ProductsID
				) as oo on p.ProductsID=oo.ProductsID
				left join 
				--退货
				(select oll.ProductsID,isnull(sum(oll.oQuantity),0) oQuantity_t,isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll where oll.OrderID in(select OrderID from tbOrderInfo where oType in(4) and oState=0 and oSteps>=3 and OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate)) ) and dbo.fun_CheckProductIsPool(oll.ProductsID,(select oOrderDateTime from tbOrderInfo where OrderID=oll.OrderID))=1 and oll.oWorkType=0 group by oll.ProductsID) as ool
				on oo.ProductsID=ool.ProductsID
				left join tbProductClassInfo pc on pc.ProductClassID=p.ProductClassID) as ppp where ppp.oQuantity<>0 or ppp.oMoney<>0 or ppp.oQuantity_t<>0 or ppp.oMoney_t<>0  order by  ppp.ProductClassID,ppp.ProductsID desc;
		end
	end

	--客户
	if @ReType = 2
	begin
		--全部
		if @NOJoinSales = 0
		begin
		select ppp.* from (
			select s.*,sc.cClassName,--isnull(oo.CostPrice,0) CostPrice,
			isnull(oo.oMoney,0) oMoney,--isnull(ool.CostPrice_t,0) CostPrice_t,
			isnull(ool.oMoney_t,0) oMoney_t from tbStoresInfo as s left join(
			--出货
			select oi.StoresID,--isnull(sum(ol.oQuantity*dbo.fun_GetProductCostPrice(ol.ProductsID,oi.oOrderDateTime)),0) CostPrice,
			isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType in(3,5,6,7) and oi.oState=0 and oi.oSteps>=3 and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate))   and ol.oWorkType=0 group by oi.StoresID
			) as oo on s.StoresID=oo.StoresID
			left join 
			--退货
			(select oii.StoresID,--isnull(sum(oll.oQuantity*dbo.fun_GetProductCostPrice(oll.ProductsID,oii.oOrderDateTime)),0) CostPrice_t,
			isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType in(4) and oii.oState=0 and oii.oSteps>=3 and oii.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate))  and oll.oWorkType=0 group by oii.StoresID) as ool
			on oo.StoresID=ool.StoresID  
			left join  tbCustomersClassInfo sc on sc.CustomersClassID=s.CustomersClassID) ppp where ppp.oMoney<>0 or ppp.oMoney_t<>0  order by  ppp.CustomersClassID,ppp.StoresID desc;
		end
		--剔除
		if @NOJoinSales = 1
		begin
		select ppp.* from (
			select s.*,sc.cClassName,--isnull(oo.CostPrice,0) CostPrice,
			isnull(oo.oMoney,0) oMoney,--isnull(ool.CostPrice_t,0) CostPrice_t,
			isnull(ool.oMoney_t,0) oMoney_t from tbStoresInfo as s left join(
			--出货
			select oi.StoresID,--isnull(sum(ol.oQuantity*dbo.fun_GetProductCostPrice(ol.ProductsID,oi.oOrderDateTime)),0) CostPrice,
			isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType in(3,5,6,7) and oi.oState=0 and oi.oSteps>=3 and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate)) and dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=0   and ol.oWorkType=0 group by oi.StoresID
			) as oo on s.StoresID=oo.StoresID
			left join 
			--退货
			(select oii.StoresID,--isnull(sum(oll.oQuantity*dbo.fun_GetProductCostPrice(oll.ProductsID,oii.oOrderDateTime)),0) CostPrice_t,
			isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType in(4) and oii.oState=0 and oii.oSteps>=3 and oii.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate)) and  dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=0  and oll.oWorkType=0 group by oii.StoresID) as ool
			on oo.StoresID=ool.StoresID  
			left join  tbCustomersClassInfo sc on sc.CustomersClassID=s.CustomersClassID) ppp where ppp.oMoney<>0 or ppp.oMoney_t<>0 order by  ppp.CustomersClassID,ppp.StoresID desc;
		end
		--仅联营
		if @NOJoinSales = 2
		begin
		select ppp.* from (
			select s.*,sc.cClassName,--isnull(oo.CostPrice,0) CostPrice,
			isnull(oo.oMoney,0) oMoney,--isnull(ool.CostPrice_t,0) CostPrice_t,
			isnull(ool.oMoney_t,0) oMoney_t from tbStoresInfo as s left join(
			--出货
			select oi.StoresID,--isnull(sum(ol.oQuantity*dbo.fun_GetProductCostPrice(ol.ProductsID,oi.oOrderDateTime)),0) CostPrice,
			isnull(sum(ol.oMoney),0) oMoney from tbOrderListInfo ol left join tbOrderInfo oi on oi.OrderID=ol.OrderID where oi.oType in(3,5,6,7) and oi.oState=0 and oi.oSteps>=3 and oi.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=3 and  (pAppendTime BETWEEN @bDate and @eDate))  and dbo.fun_CheckProductIsPool(ol.ProductsID,oi.oOrderDateTime)=1  and ol.oWorkType=0 group by oi.StoresID
			) as oo on s.StoresID=oo.StoresID
			left join 
			--退货
			(select oii.StoresID,--isnull(sum(oll.oQuantity*dbo.fun_GetProductCostPrice(oll.ProductsID,oii.oOrderDateTime)),0) CostPrice_t,
			isnull(sum(oll.oMoney),0) oMoney_t from tbOrderListInfo oll left join tbOrderInfo oii on oii.OrderID=oll.OrderID where oii.oType in(4) and oii.oState=0 and oii.oSteps>=3 and oii.OrderID in(select OrderID from tbOrderWorkingLogInfo where oType=4 and  (pAppendTime BETWEEN @bDate and @eDate)) and dbo.fun_CheckProductIsPool(oll.ProductsID,oii.oOrderDateTime)=1  and oll.oWorkType=0 group by oii.StoresID) as ool
			on oo.StoresID=ool.StoresID  
			left join  tbCustomersClassInfo sc on sc.CustomersClassID=s.CustomersClassID) ppp where ppp.oMoney<>0 or ppp.oMoney_t<>0 order by  ppp.CustomersClassID,ppp.StoresID desc;
		end
	end

end
GO
/****** Object:  StoredProcedure [dbo].[sp_Products_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Products_analysis]
	/*
	产品分析
	*/
	@bDate datetime,			--开始时间
	@eDate datetime,			--结束时间
	@rType int = 1,				--返还类型,1=产品,2=品牌
	@ProductID int = 0,			--指定产品编号
	@Brand varchar(128) = ''	--知道产品品牌
AS
begin
	
	declare @tProductsID int,@tpName varchar(512);
	
	declare @tS_TOTAL money,@tS_QUANTITY int,@tBadgoodsFees money,@tReturnsFees money,@tCostFees money;
	
	/*产品动态成本*/
	If object_id('tempdb..#ErpProductCostPrice_antmp_t') is  not null
	Drop table #ErpProductCostPrice_antmp_t
	--创建新临时表
	Create table #ErpProductCostPrice_antmp_t (CostVelenceID int,ProductsID int,		--产品编号
						cPrice money,			--成本
						bdate datetime,			--开始时间
						edate datetime			--结束时间
					)
	--产品变价后，产品成本列表
	insert into #ErpProductCostPrice_antmp_t exec sp_GetProductCostValence;
	
	If object_id('tempdb..#Products_analysis_List') is  not null
	Drop table #Products_analysis_List
	--创建新临时表
	Create table #Products_analysis_List (
						ProductsID int,		--产品编号
						pName varchar(512),		--名称
						S_TOTAL money,			--总金额
						S_QUANTITY int,			--总数量
						BadgoodsFees money,			--坏货
						ReturnsFees money,			--退货
						CostFees money,				--成本
						Profit money				--利润
					)
	if @ProductID>0--指定产品
	begin
		declare ocur cursor for select ProductsID,pName from tbProductsInfo where ProductsID=@ProductID
	end
	else if @Brand!=''--指定产品品牌
	begin
		declare ocur cursor for select ProductsID,pName from tbProductsInfo where pBrand=@Brand
	end
	else
	begin
		declare ocur cursor for select ProductsID,pName from tbProductsInfo 
	end
	
	
	
	open ocur
	FETCH NEXT FROM ocur INTO @tProductsID,@tpName
	WHILE @@FETCH_STATUS = 0
	begin
		
		select @tS_TOTAL=isnull(sum(isnull(S_TOTAL,0)),0) from tbErpOrderInfo where R_ID=1 and O_CREATETIME>=@bDate and O_CREATETIME<=@eDate and ProductsID=@tProductsID;
		select @tS_QUANTITY=isnull(sum(isnull(S_QUANTITY,0)),0) from tbErpOrderInfo where R_ID=1 and O_CREATETIME>=@bDate and O_CREATETIME<=@eDate and ProductsID=@tProductsID;
		
		select @tBadgoodsFees=isnull(sum(e.S_QUANTITY),0)*(select top 1 t.cPrice from #ErpProductCostPrice_antmp_t as t where t.ProductsID=@tProductsID and t.bdate>=@bDate and t.bdate<=@eDate) 
			from tbErpOrderInfo e  where e.R_ID=6 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.ProductsID=@tProductsID  ;
			
		select @tReturnsFees=isnull(sum(e.S_QUANTITY),0)*(select top 1 t.cPrice from #ErpProductCostPrice_antmp_t as t where t.ProductsID=@tProductsID and t.bdate>=@bDate and t.bdate<=@eDate) 
			from tbErpOrderInfo e  where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate  and e.ProductsID=@tProductsID;
			
		select @tCostFees=isnull(sum(e.S_QUANTITY),0)*(select top 1 t.cPrice from #ErpProductCostPrice_antmp_t as t where t.ProductsID=@tProductsID and t.bdate>=@bDate and t.bdate<=@eDate) 
			from tbErpOrderInfo e  where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate  and e.ProductsID=@tProductsID;
		
		set @tS_TOTAL=isnull(@tS_TOTAL,0);
		set @tS_QUANTITY=isnull(@tS_QUANTITY,0);
		set @tBadgoodsFees=isnull(@tBadgoodsFees,0);
		set @tReturnsFees=isnull(@tReturnsFees,0);
		set @tCostFees=isnull(@tCostFees,0);
		
		insert into #Products_analysis_List(ProductsID,pName,S_TOTAL,S_QUANTITY,BadgoodsFees,ReturnsFees,CostFees,Profit)
			VALUES(@tProductsID,@tpName,@tS_TOTAL,@tS_QUANTITY,@tBadgoodsFees,@tReturnsFees,@tCostFees,@tS_TOTAL-(@tCostFees-@tReturnsFees)-@tBadgoodsFees)
		
		FETCH NEXT FROM ocur INTO @tProductsID,@tpName
	end
	CLOSE ocur--关闭游标
	DEALLOCATE ocur--释放游标
	
	if @rType=1
	begin
		select * from #Products_analysis_List order by Profit desc
	end
	else if @rType=2
	begin
		select p.pBrand,isnull(sum(isnull(l.S_TOTAL,0)),0) S_TOTAL,
						isnull(sum(isnull(l.S_QUANTITY,0)),0) S_QUANTITY,
						isnull(sum(isnull(l.BadgoodsFees,0)),0) BadgoodsFees,
						isnull(sum(isnull(l.ReturnsFees,0)),0) ReturnsFees,
						isnull(sum(isnull(l.CostFees,0)),0) CostFees,
						isnull(sum(isnull(l.Profit,0)),0) Profit
		 from tbProductsInfo p,#Products_analysis_List l where p.ProductsID=l.ProductsID group by p.pBrand order by Profit desc
	end
	
	Drop table #Products_analysis_List
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_MoriCostDetails]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YANGANGOL
-- Create date: 2011-6-22
-- Description:	毛利统计_区域
-- =============================================
CREATE PROCEDURE [dbo].[sp_MoriCostDetails]
	@inyMoriType int,     --毛利类别：0=区域；1=客户；2=业务员；3=品牌；4=单品
	@dtmbDate datetime,   --开始日期
	@dtmeDate datetime    --结束日期
AS
    set @dtmbDate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmbDate))+'-'+convert(varchar,DATEPART(MONTH,@dtmbDate))+'-'+convert(varchar,DATEPART(DAY,@dtmbDate))+' 00:00:00')
    set @dtmeDate=convert(datetime,convert(varchar,DATEPART(YEAR,@dtmeDate))+'-'+convert(varchar,DATEPART(MONTH,@dtmeDate))+'-'+convert(varchar,DATEPART(DAY,@dtmeDate))+' 23:59:59')
	
	
	--商品列表,含成本
	declare @Products Table(
		ProductsID	int,
		pPrice			numeric(18,6),
		CoPrice			numeric(18,6),
		pBarcode		varchar(50),
		pName			varchar(128),
		ProductClassID	int,
		pBrand			varchar(128),
		pStandard	varchar(50),
		pUnits			varchar(50),
		pMaxUnits	varchar(50),
		pToBoxNo	int
	);
	
  --人员列表
	declare @Staff Table(
		StaffID int,			--人员编号
		DepartmentsClassID int,	--部门编号
		StoresID int,			--客户/门店编号
		sName varchar(50),		--姓名
		sType int,				--类型
		bDate datetime,			--上岗时间
		eDate datetime			--离岗时间
	);
	
	--存储销售金额
	declare @tbSalesMoney table(
							    typeID int,			 --类别编号
							    typeProductID int,   --产品编号
							    typeNum int,		 --销售数量
							    typeMoney money		 --销售金额
							   )
	--存储退货数量
	declare @tbTuiHuoNum table(
							   typeTNumID int,		 --退货编号
							   typeTProductID int,   --产品编号
							   typeTNum int, 		 --退货数量
							   typeTMoney money		 --退货金额
							  )
	--存储赠品数量
	declare @tbGiveNum	table(
							   typeZNumID int,		 --赠品编号
							   typeZProductID int,	 --产品编号
							   typezNum int			 --赠品数量
							 )
	--存储销售单赠品数量
	declare @tbSalesGiveNum	table(
							   typeSZNumID int,		 --赠品编号
							   typeSZProductID int,	 --产品编号
							   typeSzNum int			 --赠品数量
							 )
	--存储样品数量
	declare @tbModelNum table(
							   typeYNumID int,		 --样品编号
							   typeYProductID int,   --产品编号
							   typeYNum int			 --样品数量
							 )
	--存储坏货数量
	declare @tbBadNum	table(
							   typeBNumID int,		 --坏货编号
							   typeBProductID int,	 --产品编号
							   typeBNum int			 --坏货数量
							 )
    --存储实际产品销售数量
    declare @tbRealNum table(
							  tbProductID int,		 --产品编号
							  tbRealNum int			 --实际销量
							)
	--存储实际门店产品销售数量
	declare @tbRealNumOfStorehouse table(
							  storesID int,			--门店编号
							  productsID int,		--产品编号
							  realNum int,			--实际数量
							  realMoney money       --成本金额
							)
BEGIN
    --单品成本金额
    insert into @Products(ProductsID,pPrice,CoPrice,pBarcode,pName,ProductClassID,pBrand,pStandard,pUnits,pMaxUnits,pToBoxNo)
	   select p.ProductsID,p.pPrice,(dbo.fun_GetProductPriceXP(p.ProductsID,@dtmbDate,@dtmeDate)),p.pBarcode,p.pName,p.ProductClassID,p.pBrand,p.pStandard,p.pUnits,p.pMaxUnits,p.pToBoxNo from tbProductsInfo p where p.pState=0;
    
	--销售数量及金额
	insert into @tbSalesMoney(typeID,typeProductID,typeNum,typeMoney)
    select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity,isnull(oli.oMoney,0) as oMoney from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=3 and oi.oState=0  and oli.oWorkType=2 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) 
			
   --退货数量
   insert into @tbTuiHuoNum(typeTNumID,typeTProductID,typeTNum,typeTMoney)
   select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity,isnull(oMoney,0) as oMoney from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=4 and oi.oState=0  and oli.oWorkType=2 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
          
   --赠品数量
   insert into @tbGiveNum(typeZNumID,typeZProductID,typezNum)
   select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=5 and oi.oState=0  and oli.oWorkType=2 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
   --销售单赠品数量
   insert into @tbSalesGiveNum(typeSZNumID,typeSZProductID,typeSzNum)
   select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=3 and oi.oState=0  and oli.oWorkType=2 and oli.IsGifts !=0 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
   
   --样品数量
   insert into @tbModelNum(typeYNumID,typeYProductID,typeYNum)
   select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=6 and oi.oState=0  and oli.oWorkType=2 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
   --坏货数量
   insert @tbBadNum(typeBNumID,typeBProductID,typeBNum)
   select oi.StoresID,oli.ProductsID,isnull(oli.oQuantity,0) as oQuantity from tbOrderInfo as oi 
	   left join tbOrderListInfo as oli on oi.OrderID=oli.OrderID
		 where oi.oType=10 and oi.oState=0  and oli.oWorkType=2 and oi.OrderID in
		  (select OrderID from tbOrderWorkingLogInfo where oType=5 and pAppendTime between @dtmbDate and @dtmeDate)
    
   if(@inyMoriType=3 or @inyMoriType=4)
      begin
      --单品实际销量
	  insert into @tbRealNum(tbProductID,tbRealNum)
	  select p.ProductsID,isnull((isnull(sm.typeNum,0)-isnull(tm.typeTNum,0)+isnull(gm.typezNum,0)+isnull(sgm.typeSzNum,0)+isnull(ym.typeYNum,0)+isnull(bm.typeBNum,0)),0) as realNum 
	      from tbProductsInfo as p left join(
	      --销售数量
	      select typeProductID,isnull(sum(typeNum),0) as typeNum from @tbSalesMoney group by typeProductID) as sm on sm.typeProductID=p.ProductsID
			left join(
	      --退货数量
	      select typeTProductID,isnull(sum(typeTNum),0) as typeTNum from @tbTuiHuoNum group by typeTProductID) as tm on tm.typeTProductID=p.ProductsID
	        left join(
	      --赠品数量
	      select typeZProductID,isnull(sum(typezNum),0) as typezNum from @tbGiveNum group by typeZProductID) as gm on gm.typeZProductID=p.ProductsID
	        left join(
	      --销售单赠品数量
	      select typeSZProductID,isnull(sum(typeSzNum),0) as typeSzNum from @tbSalesGiveNum group by typeSZProductID) as  sgm on sgm.typeSZProductID=p.ProductsID
	        left join(
	      --样品数量
	      select typeYProductID,isnull(sum(typeYNum),0) as typeYNum from @tbModelNum group by typeYProductID) as ym on ym.typeYProductID=p.ProductsID
	        left join(
	      --坏货数量
	      select typeBProductID,isnull(sum(typeBNum),0) as typeBNum from @tbBadNum group by typeBProductID) as bm on bm.typeBProductID=p.ProductsID
	   where p.pState=0 and sm.typeNum <>0 or tm.typeTNum <>0 or gm.typezNum <>0 or sgm.typeSzNum <>0
	   or ym.typeYNum <>0 or ym.typeYNum <>0 
    end
    
   if(@inyMoriType=2 or @inyMoriType=1 or @inyMoriType=0)
   --得到门店销售，退货，赠品，样品，坏货数量及成本
   begin
      
      insert into @tbRealNumOfStorehouse(storesID,productsID,realNum,realMoney)
     
      select pp.StoresID,pp.ProductsID,pp.relNum,pp.relNum*p.CoPrice from ( 
       
      select si.StoresID,si.ProductsID,
             sum(isnull(sm.typeNum,0)-isnull(tm.typeTNum,0)+isnull(gm.typezNum,0)+isnull(gms.typeSzNum,0)+isnull(ym.typeYNum,0)+isnull(bm.typeBNum,0)) as relNum 
     
      
      from(select _s.StoresID,_p.ProductsID from tbStoresInfo  _s,@Products _p) as si 
      left join(
      
      --门店产品销售数量
      select typeID,typeProductID,isnull(sum(typeNum),0) as typeNum from @tbSalesMoney group by typeID,typeProductID) as sm
      on sm.typeID=si.StoresID and sm.typeProductID=si.ProductsID
      left join(
      
      --门店产品退货数量
      select typeTNumID,typeTProductID,isnull(sum(typeTNum),0) as typeTNum from @tbTuiHuoNum group by typeTNumID,typeTProductID) as tm
      on tm.typeTNumID=si.StoresID and tm.typeTProductID=si.ProductsID
      left join(
      
      
      --门店产品赠品数量
      select typeZNumID,typeZProductID,isnull(sum(typezNum),0) as typezNum from @tbGiveNum group by typeZNumID,typeZProductID) as gm
      on gm.typeZNumID=si.StoresID and gm.typeZProductID=si.ProductsID
      left join(
      
      
      --门店产品销售单赠品数量
      select typeSZNumID,typeSZProductID,isnull(sum(typeSzNum),0) as typeSzNum from @tbSalesGiveNum group by typeSZNumID,typeSZProductID) as gms
      on gms.typeSZNumID=si.StoresID and gms.typeSZProductID=si.ProductsID
      left join(
      
      
      --门店产品样品数量
      select typeYNumID,typeYProductID,isnull(sum(typeYNum),0) as typeYNum from @tbModelNum group by typeYNumID,typeYProductID) as ym
      on ym.typeYNumID=si.StoresID and ym.typeYProductID=si.ProductsID
      left join(
      
      --门店产品坏货数量
      select typeBNumID,typeBProductID,isnull(sum(typeBNum),0) as typeBNum from @tbBadNum group by typeBNumID,typeBProductID) as bm
      on bm.typeBNumID=si.StoresID and bm.typeBProductID=si.ProductsID
      
      where sm.typeNum <>0 or tm.typeTNum <>0 or gm.typezNum <>0 or gms.typeSzNum <>0 or ym.typeYNum <>0 or bm.typeBNum <>0 
      group by si.StoresID,si.ProductsID 
      
      
      ) as pp left join @Products as p on p.ProductsID=pp.ProductsID
      
   end
   if(@inyMoriType=2)
   begin
   --业务员
     	insert into @Staff(StaffID,DepartmentsClassID,sName,sType,bDate,eDate,StoresID)
				select s.StaffID, s.DepartmentsClassID,s.sName,s.sType,ss.bdate,ss.edate,ss.StoresID from 
				(select StaffID,StoresID,MIN(bdate) bdate,MAX(edate) edate from tbSales_Staff_StoresDataInfo group by StaffID,StoresID)  ss 
					left join tbStaffInfo s on ss.StaffID=s.StaffID
					where (@dtmbDate between ss.bdate and ss.edate) and (@dtmeDate between ss.bdate and ss.edate) and s.sType=1 ;
   end
   
   --1.1 单品
	  if (@inyMoriType=4)
	  begin  
	   --oMoney:销售额；sMoney：成本额；qMoney：毛利额
       select p.pName,isnull((isnull(pp.oMoney,0)-isnull(th.tMoney,0)),0) as oMoney,
         isnull(qq.sMoney,0) as sMoney,isnull(isnull(pp.oMoney,0)-isnull(th.tMoney,0)-isnull(qq.sMoney,0),0) as qMoney
           from tbProductsInfo as p left join(
	          --销售金额
			   select oli.ProductsID,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(oMoney),0) as oMoney  from tbOrderListInfo as oli left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
			   where  oWorkType=2 and oli.OrderID in( select OrderID from tbOrderWorkingLogInfo 
				where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) and oi.oState=0 and oi.oType=3
				  group by oli.ProductsID) as pp on pp.ProductsID=p.ProductsID full join(
			   
			   --成本金额   
			   select rum.tbProductID,isnull(sum(rum.tbRealNum*pt.CoPrice),0) as sMoney from @tbRealNum as rum 
			      left join @Products as pt on rum.tbProductID=pt.ProductsID group by rum.tbProductID
			     
			    ) as qq on qq.tbProductID=p.ProductsID  full join(
			  
			   --退货金额
			   select typeTProductID,isnull(sum(typeTMoney),0) as tMoney from @tbTuiHuoNum 
			   group by  typeTProductID) as th on th.typeTProductID=p.ProductsID
			
			where p.pState=0 and isnull((isnull(pp.oMoney,0)-isnull(th.tMoney,0)),0)<>0 or
	         isnull(qq.sMoney,0) <>0 or isnull(isnull(pp.oMoney,0)-isnull(th.tMoney,0)-isnull(qq.sMoney,0),0) <>0
	         order by isnull(isnull(pp.oMoney,0)-isnull(th.tMoney,0)-isnull(qq.sMoney,0),0) desc
	  end
	--1.2 品牌
	if(@inyMoriType=3)   
	begin
	    select p.pBrand,isnull(sum(isnull(pp.oMoney,0)-isnull(th.tMoney,0)),0) as oMoney,
         isnull(sum(qq.sMoney),0) as sMoney,isnull(sum(isnull(pp.oMoney,0)-isnull(th.tMoney,0)-isnull(qq.sMoney,0)),0) as qMoney
           from tbProductsInfo as p left join(
	        
	        --销售金额
			select oli.ProductsID,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(oMoney),0) as oMoney  from tbOrderListInfo as oli
			  left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
			   where  oWorkType=2 and oli.OrderID in( select OrderID from tbOrderWorkingLogInfo 
				where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) and oi.oState=0 and oi.oType=3
				  group by oli.ProductsID) as pp on pp.ProductsID=p.ProductsID full join(
		    --成本金额	         
		   select rum.tbProductID,isnull(sum(rum.tbRealNum*pt.CoPrice),0) as sMoney from @tbRealNum as rum 
			      left join @Products as pt on rum.tbProductID=pt.ProductsID group by rum.tbProductID
		    ) as qq on qq.tbProductID=p.ProductsID  full join(
			--退货金额  
		    select typeTProductID,isnull(sum(typeTMoney),0) as tMoney from @tbTuiHuoNum 
			     group by  typeTProductID) as th on th.typeTProductID=p.ProductsID
			
			where p.pState=0   group by p.pBrand  
			 order by isnull(sum(isnull(pp.oMoney,0)-isnull(th.tMoney,0)-isnull(qq.sMoney,0)),0) desc
	end
	--1.3 业务员
	if(@inyMoriType=2) 
	begin
	    
	    select sss.sName,sum(isnull(cdm.oMoney,0)) as oMoney,sum(isnull(cdm.sMoney,0)) as sMoney,isnull(sum(cdm.qMoney),0) as qMoney from (
	    
		select si.StoresID,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)) as oMoney
		 ,sum(isnull(cb.realMoney,0)) as sMoney,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)-isnull(cb.realMoney,0)) as qMoney
		 from tbStoresInfo as si
		
		left join(      
			--销售金额
			select oi.StoresID,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(oMoney),0) as oMoney  from tbOrderListInfo as oli
			  left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
			   where  oWorkType=2 and oli.OrderID in( select OrderID from tbOrderWorkingLogInfo 
				where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) and oi.oState=0 and oi.oType=3
				  group by oi.StoresID
			) as ss on si.StoresID=ss.StoresID 
		full join(  
			--退货金额  
			select typeTNumID,isnull(sum(typeTMoney),0) as tMoney from @tbTuiHuoNum 
			  group by  typeTNumID
			) as ts on ts.typeTNumID=si.StoresID
			
	    full join(
	      --成本金额
	      select storesID,sum(isnull(realMoney,0)) as realMoney from @tbRealNumOfStorehouse
	    	 group by storesID
	    ) as cb on cb.storesID=si.StoresID
	   where ss.oMoney<>0 or ts.tMoney <>0 or cb.realMoney <>0 group by si.StoresID	
	   
	   ) as cdm left join (select s.StoresID,f.sName from  @Staff as s left join tbStaffInfo as f on s.StaffID=f.StaffID) as sss on cdm.StoresID=sss.StoresID
	   
	   group by sss.sName order by qMoney desc
	end
	
	--1.4 客户
	if(@inyMoriType=1) 
	begin
	    
	    select sif.sName,isnull(cdm.oMoney,0) as oMoney,isnull(cdm.sMoney,0) as sMoney,isnull(cdm.qMoney,0) as qMoney from (
	    select si.StoresID,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)) as oMoney
		 ,sum(isnull(cb.realMoney,0)) as sMoney,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)-isnull(cb.realMoney,0)) as qMoney
		 from tbStoresInfo as si
		
		left join(      
			--销售金额
			select oi.StoresID,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(oMoney),0) as oMoney  from tbOrderListInfo as oli
			  left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
			   where  oWorkType=2 and oli.OrderID in( select OrderID from tbOrderWorkingLogInfo 
				where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) and oi.oState=0 and oi.oType=3
				  group by oi.StoresID
			) as ss on si.StoresID=ss.StoresID 
		full join(  
			--退货金额  
			select typeTNumID,isnull(sum(typeTMoney),0) as tMoney from @tbTuiHuoNum 
			  group by  typeTNumID
			) as ts on ts.typeTNumID=si.StoresID
			
	    full join(
	      --成本金额
	      select storesID,sum(isnull(realMoney,0)) as realMoney from @tbRealNumOfStorehouse
	    	 group by storesID
	    ) as cb on cb.storesID=si.StoresID
	   where ss.oMoney<>0 or ts.tMoney <>0 or cb.realMoney <>0 group by si.StoresID	
	   ) as cdm left join tbStoresInfo as sif on cdm.StoresID=sif.StoresID  order by qMoney desc
	end
	
	--1.5 客户
	if(@inyMoriType=0)
	begin
	
	  select ri.rName,isnull(cdm.oMoney,0) as oMoney,isnull(cdm.sMoney,0) as sMoney,isnull(cdm.qMoney,0) as qMoney from (
	  select si.RegionID,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)) as oMoney
		 ,sum(isnull(cb.realMoney,0)) as sMoney,sum(isnull(ss.oMoney,0)-isnull(ts.tMoney,0)-isnull(cb.realMoney,0)) as qMoney
		 from tbStoresInfo as si
		
		left join(      
			--销售金额
			select oi.StoresID,isnull(sum(oQuantity),0) as oQuantity,isnull(sum(oMoney),0) as oMoney  from tbOrderListInfo as oli
			  left join tbOrderInfo as oi on oli.OrderID=oi.OrderID
			   where  oWorkType=2 and oli.OrderID in( select OrderID from tbOrderWorkingLogInfo 
				where oType=5 and pAppendTime between @dtmbDate and @dtmeDate) and oi.oState=0 and oi.oType=3
				  group by oi.StoresID
			) as ss on si.StoresID=ss.StoresID 
		full join(  
			--退货金额  
			select typeTNumID,isnull(sum(typeTMoney),0) as tMoney from @tbTuiHuoNum 
			  group by  typeTNumID
			) as ts on ts.typeTNumID=si.StoresID
			
	    full join(
	      --成本金额
	      select storesID,sum(isnull(realMoney,0)) as realMoney from @tbRealNumOfStorehouse
	    	 group by storesID
	    ) as cb on cb.storesID=si.StoresID
	   where ss.oMoney<>0 or ts.tMoney <>0 or cb.realMoney <>0 group by si.RegionID	
	   ) as cdm left join tbRegionInfo as ri on cdm.RegionID=ri.RegionID order by qMoney desc
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PromotionsData_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PromotionsData_analysis]
	/*促销*/
	@bDate datetime,		--起始时间
	@eDate datetime			--结束时间
AS
begin

declare @AllSumValue money;

--创建永辉销售临时表
If object_id('tempdb..#PromotionsData_YH_StoresData') is  not null
Drop table #PromotionsData_YH_StoresData
Create table #PromotionsData_YH_StoresData (
					tName	varchar(128),	--门店编号
					tValue	money,			--人员编号
					Share	float			--占比
				)
If object_id('tempdb..#tempTable') is  not null
Drop table #tempTable
Create table #tempTable (
					tName	varchar(128),	--门店编号
					tValue	money			--人员编号
				)

--算永辉系统各门店占比
insert #tempTable exec sp_Sales_analysis 0,0,0,'',0,@bDate,@eDate,1,0,0,0;

select @AllSumValue=sum(tValue) from #tempTable;

insert #PromotionsData_YH_StoresData(tName,tValue,Share)
 select tName,tValue,(tValue/@AllSumValue) from #tempTable;



select * from #PromotionsData_YH_StoresData




Drop table #tempTable
Drop table #PromotionsData_YH_StoresData;

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetInvoicingReport]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetInvoicingReport] 
	@dT datetime=getdate ,		--时间点
	@ProductsID int=0,			--产品编号
	@StorageID int=0,			--仓库编号
	@ReType int=1,				--返回表类型,0=日表,1=月表,2=年表,3=区间
	@sDataType	int =0,			--统计数据方式,0=取上期结存成本,1=取本期发生成本
	@edT datetime=null			--区间统计时使用
AS
BEGIN
	--本期
	declare @bDate datetime;
	declare @eDate datetime;
	--上期
	declare @u_bDate datetime;
	declare @u_eDate datetime;
	
	declare @tSQL varchar(128);
	
	if @ReType = 0
	begin
	--上期
		set @u_bDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT)))+' 00:00:00');
		set @u_eDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT)))+' 23:59:59');
	--本期
		set @bDate = convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 00:00:00');
		set @eDate = convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 23:59:59');
	end
	if @ReType = 1 
	begin
	--上期
		set @u_bDate = dateadd(dd,-datepart(dd,DATEADD(month, -1, @dT))+1,DATEADD(month, -1, @dT));--本月第一天
		set @u_eDate = convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,DATEADD(month, -1, @dT)-day(DATEADD(month, -1, @dT))+1)),23)+' 23:59:59');--本月最后一天
	--本期
		set @bDate = dateadd(dd,-datepart(dd,@dT)+1,@dT);--本月第一天
		set @eDate = convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,@dT-day(@dT)+1)),23)+' 23:59:59');--本月最后一天
	end
	if @ReType = 2 
	begin
	--上期
		set @u_bDate = DATEADD(year, DATEDIFF(year, '', DATEADD(year, -1, @dT)), '');--本年第一天
		set @u_eDate = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,DATEADD(year, -1, @dT))+1, 0));--本年最后一天
	--本期
		set @bDate = DATEADD(year, DATEDIFF(year, '', @dT), '');--本年第一天
		set @eDate = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT)+1, 0));--本年最后一天
	end
	
	if @ReType = 3 
	begin
	--上期
		set @u_bDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT)))+' 00:00:00');
		set @u_eDate = convert(datetime,convert(varchar,DATEPART(year,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(month,DATEADD(day, -1, @dT)))+'-'+convert(varchar,DATEPART(day,DATEADD(day, -1, @dT)))+' 23:59:59');
	--本期
		set @bDate = convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 00:00:00');
		set @eDate = convert(datetime,convert(varchar,DATEPART(year,@edT))+'-'+convert(varchar,DATEPART(month,@edT))+'-'+convert(varchar,DATEPART(day,@edT))+' 23:59:59');
		
	--统计方式为日统计
		set @ReType=0;
	end
	
	--最后一天是今天的未来
	if datediff(day,GETDATE(),@eDate)>0
	begin
		set @eDate = getdate();
	end
	
	--删除原数据
	If object_id('tempdb..#InvoicingReport_tmp') is  not null
	Drop table #InvoicingReport_tmp
	--创建新临时表
	Create table #InvoicingReport_tmp (ProductsID int,StorageID int,
						sName varchar(128),
						pBarcode varchar(50),
						pToBoxNo varchar(10),
						pName varchar(128),
						pPrice money,
						beginQuantity numeric(18,6),		--系统期初数量
						UpStorage numeric(18,6),			--上期结存
						UpStorageIn numeric(18,6),			--上期入库未结存
						UpStorageOut numeric(18,6),			--上期出库未结存
						LastStorage numeric(18,6),			--期末结存

						StorageIn numeric(18,6),			--本期入库
						StorageOut numeric(18,6),			--本期出库

						ProductClassID int,

						beginMoney numeric(18,6),			--系统期初金额,数量*产品固定成本
						UpStorageMoney numeric(18,6),		--上期结存总成本
						UpStorageInMoney numeric(18,6),		--上期入库总成本
						UpStorageOutMoney numeric(18,6),	--上期出库总成本
						LastStorageMoney numeric(18,6),		--期末结存总成本

						StorageInMoney numeric(18,6),		--本期入库成本
						StorageOutMoney numeric(18,6)		--本期出库成本

					)


--全局期初
	declare @BeginData table
	(
		ProductsID int,
		StorageID int,
		ProductClassID int,
		sName varchar(128),
		pBarcode varchar(50),
		pToBoxNo int,
		pName varchar(128),
		pPrice numeric(18,6),
		bStorage numeric(18,6),
		bMoney numeric(18,6)
	);
	insert into @BeginData(ProductsID,StorageID,ProductClassID,sName,pBarcode,pToBoxNo,pName,pPrice,bStorage,bMoney)
		select p.ProductsID,p.StorageID,p.ProductClassID,p.sName,p.pBarcode,p.pToBoxNo,p.pName,p.pPrice,isnull(beginData.pQuantity,0) as pQuantity,ISNULL(beginData.bMoney,0) as bMoney
		from (select * from tbProductsInfo,tbStorageInfo where pState=0) as p left join
		(select *, (select isnull(tbProductsStorageLogInfo.pQuantity*tbProductsInfo.pPrice,0) from tbProductsInfo where ProductsID=tbProductsStorageLogInfo.ProductsID)as bMoney 
				from tbProductsStorageLogInfo where pState=0 and pType=-1) as beginData on p.ProductsID=beginData.ProductsID and p.StorageID= beginData.StorageID;

	--上期
	declare @UpData table
	(
		ProductsID int,
		StorageID int,
		uStorage numeric(18,6),
		uMoney numeric(18,6),
		uInMoney numeric(18,6),
		uInQuantity numeric(18,6),
		uOutMoney numeric(18,6),
		uOutQuantity numeric(18,6)
	);

	--是否已有上期数据
	if exists(select 0 from tbReportInvoicingDataInfo where rType=@ReType and datediff(day,rBDateTime,@u_bDate)=0 and datediff(day,rEdateTime,@u_eDate)=0)
	begin
		insert into @UpData(ProductsID,StorageID,uStorage,uMoney,uInMoney,uInQuantity,uOutMoney,uOutQuantity)
			select ProductsID,StorageID,bQuantity,bMoney,InMoney,InQuantity,OutMoney,OutQuantity from tbReportInvoicingDataInfo where rType=@ReType and datediff(day,rBDateTime,@u_bDate)=0 and datediff(day,rEdateTime,@u_eDate)=0;
	end
	else
	begin
		--没有上期数据时:计算本年度第一天到截止时间内的数据为上期
		insert into @UpData(ProductsID,StorageID,uStorage,uMoney,uInMoney,uInQuantity,uOutMoney,uOutQuantity)
			select u.ProductsID,u.StorageID,b.bStorage,b.bMoney,u.InMoney,u.InQuantity,u.OutMoney,u.OutQuantity from dbo.fun_GetProductInOutByDate(DATEADD(year, DATEDIFF(year, '', @u_bDate), ''),@u_eDate,@sDataType) as u right join @BeginData as b on u.ProductsID=b.ProductsID and u.StorageID=b.StorageID and u.ProductClassID=b.ProductClassID;
	end

	--本期
	declare @ThisData table
	(
		ProductsID int,
		StorageID int,
		tStorage numeric(18,6),
		tMoney numeric(18,6),
		tInMoney numeric(18,6),
		tInQuantity numeric(18,6),
		tOutMoney numeric(18,6),
		tOutQuantity numeric(18,6)
	);
	
	insert into @ThisData(ProductsID,StorageID,tStorage,tMoney,tInMoney,tInQuantity,tOutMoney,tOutQuantity)
				select ProductsID,StorageID,0,0,InMoney,InQuantity,OutMoney,OutQuantity from dbo.fun_GetProductInOutByDate(@bDate,@eDate,@sDataType);
	
	insert into #InvoicingReport_tmp(ProductsID,StorageID,sName,pBarcode,pToBoxNo,pName,pPrice,
	beginQuantity,UpStorage,UpStorageIn,UpStorageOut,
	StorageIn,StorageOut,ProductClassID,
	beginMoney,
	UpStorageMoney,UpStorageInMoney,UpStorageOutMoney,
	StorageInMoney,
	StorageOutMoney)
	--商品列表
	select b.ProductsID,b.StorageID,b.sName,b.pBarcode,b.pToBoxNo,b.pName,b.pPrice,
	isnull(b.bStorage,0) as beginQuantity,
	isnull(u.uStorage,0) as UpStorage,
	isnull(u.uInQuantity,0) as UpStorageIn,
	isnull(u.uOutQuantity,0) as UpStorageOut,
	isnull(t.tInQuantity,0) as StorageIn,
	isnull(t.tOutQuantity,0) as StorageOut,
	b.ProductClassID,
	isnull(b.bMoney,0) as beginMoney,
	
	isnull(u.uMoney,0) as UpStorageMoney,
	isnull(u.uInMoney,0) as UpStorageInMoney,
	isnull(u.uOutMoney,0) as UpStorageOutMoney,
	
	isnull(t.tInMoney,0) as StorageInMoney,--本期
	--ISNULL(t.tOutMoney,0) as StorageOutMoney
	case  when (isnull(uuu.uuQuantity,0)+isnull(uuu.uuInQuantity,0)-isnull(uuu.uuOutQuantity,0)+isnull(tt.ttInQuantity,0))<>0 then
	isnull(t.tOutQuantity,0)*((isnull(uuu.uuMoney,0)+isnull(uuu.uuInMoney,0)-isnull(uuu.uuOutMoney,0)+isnull(tt.ttInMoney,0))/ (isnull(uuu.uuQuantity,0)+isnull(uuu.uuInQuantity,0)-isnull(uuu.uuOutQuantity,0)+isnull(tt.ttInQuantity,0)))
	else 0
	end as StorageOutMoney
	
	 from @BeginData as b 
	 left join @UpData as u on b.ProductsID=u.ProductsID and b.StorageID=u.StorageID 
	 left join @ThisData as t on b.ProductsID=t.ProductsID and b.StorageID=t.StorageID 
	 left join (
		select tt.ProductsID,
				SUM(ISNULL(tt.tInQuantity,0)) as ttInQuantity,
				SUM(ISNULL(tt.tOutQuantity,0)) as ttOutQuantity,
				SUM(ISNULL(tt.tInMoney,0)) as ttInMoney,
				SUM(ISNULL(tt.tOutMoney,0)) as ttOutMoney
		from @ThisData as tt group by tt.ProductsID --用于计算成本,不分仓库
	) as tt on tt.ProductsID=b.ProductsID
	left join(
		select uu.ProductsID,
				SUM(ISNULL(uu.uStorage,0)) as uuQuantity,
				SUM(ISNULL(uu.uInQuantity,0)) as uuInQuantity,
				SUM(ISNULL(uu.uOutQuantity,0)) as uuOutQuantity,
				SUM(ISNULL(uu.uMoney,0)) as uuMoney,
				SUM(ISNULL(uu.uInMoney,0)) as uuInMoney,
				SUM(ISNULL(uu.uOutMoney,0)) as uuOutMoney
		from @UpData as uu group by uu.ProductsID
	) as uuu on uuu.ProductsID=b.ProductsID;
	
	

	--更新期末数据
	update #InvoicingReport_tmp set LastStorage=StorageIn-StorageOut+UpStorage+UpStorageIn-UpStorageOut,
								LastStorageMoney =StorageInMoney-StorageOutMoney+UpStorageMoney+UpStorageInMoney-UpStorageOutMoney;


	if @ProductsID !=0 and @StorageID!=0
	begin
		select * from #InvoicingReport_tmp where ProductsID=@ProductsID and StorageID=@StorageID   order by ProductClassID,ProductsID desc;
	end 
	else if @StorageID!=0
	begin
		select * from #InvoicingReport_tmp where StorageID=@StorageID  order by ProductClassID,ProductsID desc;
	end
	else if @ProductsID !=0
	begin
		select * from #InvoicingReport_tmp where ProductsID=@ProductsID  order by ProductClassID,ProductsID desc;
	end 
	else
	begin
		select * from #InvoicingReport_tmp order by ProductClassID,ProductsID desc;--where UpStorage<>0 or UpStorageIn<>0 or UpStorageOut<>0 or LastStorage<>0 or StorageIn<>0 or StorageOut<>0 
																			--or UpStorageMoney<>0 or UpStorageInMoney<>0 or UpStorageOutMoney<>0 or LastStorageMoney<>0 or StorageInMoney<>0 or StorageOutMoney<>0 order by ProductsID desc;
	end
	
	Drop table #InvoicingReport_tmp;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ErpData_analysis]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ErpData_analysis]
	@bDate datetime,			--开始时间
	@eDate datetime,			--结束时间
	@ShowType int = 7,			--显示类型,1=按门店,2=业务员,3=促销员,4=产品,5=品牌,6=系统,7=综合，含公司费用
	
	@StoresID int = 0,			--门店客户编号
	@StaffID int = 0,			--业务员编号
	@StaffIDB int = 0,			--促销员编号
	@Brand varchar(128) = '',	--品牌名称,模糊
	@RegionID int = 0,			--地区编号
	@ProductID int = 0,			--产品编号
	@YHsysID int = 0			--系统编号
AS
begin

	declare @tSQL varchar(3000);	--临时sql
	declare @tSQLwhere varchar(3000);

	declare @AllSales money,@AllSales_Count int;		--销售额
	declare @AllCost money,@tCost money;			--成本
	declare @AllReturns money,@AllReturns_Cost money;		--退货
	declare @AllBadgoods money,@AllBadgoods_Count int;		--坏货
	declare @AllGifts money,@AllGifts_Count int;		--赠品
	declare @AllSalesCost money;	--销售费用
	declare @AllCompCost money;		--公司费用
	
	declare @tProductID int,@tS_PRICE money,@tS_QUANTITY int;
	
	declare @tStoresID int,@tStoresID_YH int,@tsName varchar(128),@tsCode varchar(50),@tYHsysID int,@tRegionID int,@sIsFZYH int,@AllSumValue money,@tempValue money;
	
	declare @tStaffID int,@tsType int;
	
	declare @tbDate datetime,@teDate datetime;
	
	declare @tsIsFZYH int;
	
	set @tSQL = '';
	set @tSQLwhere = '';
	
	set @AllSales = 0;
	set @AllCost = 0;
	set @AllReturns = 0;
	set @AllBadgoods = 0;
	set @AllGifts = 0;
	set @AllSalesCost = 0;
	set @AllCompCost = 0;
	
	set @tStoresID = 0;
	set @tYHsysID = 0;
	set @tRegionID = 0;
	set @sIsFZYH = 0;
	
	set @tStaffID = 0;
	set @tsType = 0;
	
	
	/*产品动态成本*/
	If object_id('tempdb..#ErpProductCostPrice_antmp') is  not null
	Drop table #ErpProductCostPrice_antmp
	--创建新临时表
	Create table #ErpProductCostPrice_antmp (CostVelenceID int,ProductsID int,		--产品编号
						cPrice money,			--成本
						bdate datetime,			--开始时间
						edate datetime			--结束时间
					)
	--产品变价后，产品成本列表
	insert into #ErpProductCostPrice_antmp exec sp_GetProductCostValence;
	
	/*人员*/	
	--删除原数据
	If object_id('tempdb..#Sales_Staff_StoresData') is  not null
	Drop table #Sales_Staff_StoresData
	--创建新临时表
	Create table #Sales_Staff_StoresData (StaffStoresID int,StoresID int,		--门店编号
						StaffID int,			--人员编号
						bdate datetime,			--上岗时间
						edate datetime,			--下岗时间
						StoresName varchar(128),	--门店名称
					StaffName varchar(50)			--人员名称
					)
	
	/*非综合统计返回表*/
	If object_id('tempdb..#ErpData_analysisData') is  not null
	Drop table #ErpData_analysisData
	--创建新临时表
	Create table #ErpData_analysisData (StoresID int,		--门店编号
						sName varchar(128),			--门店名称
						--sCode varchar(50),			--门店编码
						Sales money,				--销售额
						SalesFees money,			--销售费用
						GiftsFees money,				--赠品金额
						BadgoodsFees money,				--坏货金额
						ReturnsFees money,				--退货金额
						CostFees money,					--成本金额
						Profit money					--利润
					)
	/*销售数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List') is  not null
	Drop table #Sales_Staff_StoresData_List
	--创建新临时表
	Create table #Sales_Staff_StoresData_List (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						ProductsID int,		--产品
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sNum int,				--数量
						sPrice money			--金额
					)
	/*退货数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List_B') is  not null
	Drop table #Sales_Staff_StoresData_List_B
	--创建新临时表
	Create table #Sales_Staff_StoresData_List_B (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						ProductsID int,		--产品
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sNum int,				--数量
						sPrice money			--金额
					)
	/*成本数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List_C') is  not null
	Drop table #Sales_Staff_StoresData_List_C
	--创建新临时表
	Create table #Sales_Staff_StoresData_List_C (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						ProductsID int,		--产品
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sNum int,				--数量
						sPrice money			--金额
					)
	/*坏货数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List_D') is  not null
	Drop table #Sales_Staff_StoresData_List_D
	--创建新临时表
	Create table #Sales_Staff_StoresData_List_D (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						ProductsID int,		--产品
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sNum int,				--数量
						sPrice money			--金额
					)
	/*赠品数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List_E') is  not null
	Drop table #Sales_Staff_StoresData_List_E
	--创建新临时表
	Create table #Sales_Staff_StoresData_List_E (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						ProductsID int,		--产品
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sNum int,				--数量
						sPrice money			--金额
					)
	/*销售数据*/
	If object_id('tempdb..#Sales_Staff_StoresData_List_F') is  not null
	Drop table #Sales_Staff_StoresData_List_F
	--创建新临时表
	Create table #Sales_Staff_StoresData_List_F (
						ErpOrderID int,		--Erp销售数据编号
						StoresID int,		--门店编号
						StaffID int,			--人员编号
						sdate datetime,			--发生时间
						sPrice money			--金额
					)
	/*存储福州永辉个超市数据*/
	If object_id('tempdb..#Sales_Staff_StoresSum') is  not null
	Drop table #Sales_Staff_StoresSum
	--创建新临时表
	Create table #Sales_Staff_StoresSum (StoresID int,sName varchar(128),tValue money)
	
	/*存储产品分析数据*/
	If object_id('tempdb..#Products_analysis_List_t') is  not null
	Drop table #Products_analysis_List_t
	--创建新临时表
	Create table #Products_analysis_List_t (
						ProductsID int,		--产品编号
						S_TOTAL money,			--总金额
						S_QUANTITY int,			--总数量
						BadgoodsFees money,			--坏货
						ReturnsFees money,			--退货
						CostFees money,				--成本
						Profit money				--利润
					)
	/*临时,地区条件*/
	If object_id('tempdb..#Sales_Staff_StoresRegion') is  not null
	Drop table #Sales_Staff_StoresRegion
	--创建新临时表
	Create table #Sales_Staff_StoresRegion (nodeid int,tname varchar(50),pnodeid int)

	--指定门店,客户
	if @StoresID > 0 
		begin
			set @tSQLwhere = ' and s.StoresID='+CONVERT(varchar(50),@StoresID);
		end
	--指定地区
	if @RegionID > 0
		begin
		
			insert into #Sales_Staff_StoresRegion exec sp_GetRegionNodeTable @RegionID,'',0;
			set @tSQLwhere = @tSQLwhere + ' and s.StoresID in(select StoresID from tbStoresInfo where RegionID in(select nodeid from #Sales_Staff_StoresRegion))';
	
		end

	--永辉物理编号
	select @tStoresID_YH=StoresID from tbStoresInfo where sCode='1020101001';
	
	
							
	if @ShowType = 7--综合统计
		begin
			--发货
			select @AllSales=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate;
				
			--退货
			select @AllReturns=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate;
			
			--退货成本
			select @AllReturns_Cost=isnull(sum(isnull(te.tValue,0)),0) from(
				select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue
				 from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
				) as te;
			
			--坏货
			select @AllBadgoods=isnull(sum(isnull(te.tValue,0)),0) from(
				select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue
				 from tbErpOrderInfo as e where e.R_ID=6 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
				) as te;
			
			--赠品
			select @AllGifts=isnull(sum(isnull(te.tValue,0)),0) from(
				select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue
				 from tbErpOrderInfo as e where e.R_ID=2 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
				) as te;
			
			--发货成本
			select @AllCost=isnull(sum(isnull(te.tValue,0)),0) from(
				select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
					from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
				) as te;
				
			--销售费用
			select @AllSalesCost=isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where mType=0 and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate
			
			--公司费用
			select @AllCompCost=isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where mType=1 and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate
			
			
			select @AllSales,@AllCost+@AllBadgoods+@AllGifts-@AllReturns_Cost,@AllReturns_Cost,@AllBadgoods,@AllGifts,@AllSalesCost,@AllCompCost;
		end;
		
	if @ShowType = 1 --按门店、客户统计
	begin
		
		--算福州永辉个超市占比
		insert into #Sales_Staff_StoresSum(StoresID,sName,tValue) 
			select StoresID,sName,tValue from fun_YHData(@bDate,@eDate);
		
		select @AllSumValue=isnull(sum(isnull(tValue,0)),0) from #Sales_Staff_StoresSum;
		
		select @tempValue=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@tStoresID_YH;
		
		if @StoresID > 0
		begin
			declare ocur cursor for select StoresID,sName,sCode,YHsysID,RegionID,sIsFZYH from tbStoresInfo where sState=0 and StoresID=@StoresID
		end
		else
		begin
			declare ocur cursor for select StoresID,sName,sCode,YHsysID,RegionID,sIsFZYH from tbStoresInfo where sState=0 and StoresID<>@tStoresID_YH
		end
		
		open ocur
		FETCH NEXT FROM ocur INTO @tStoresID,@tsName,@tsCode,@tYHsysID,@tRegionID,@sIsFZYH
		WHILE @@FETCH_STATUS = 0
		begin
			if @sIsFZYH = 0--统计普通门店、客户数据			
				begin
					--发货
					select @AllSales=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@tStoresID;
						
					--退货
					select @AllReturns=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@tStoresID;
					
					--退货成本
					select @AllReturns_Cost=isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te;
					
					--成本
					select @AllCost=isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te;
						
					--坏货
					select @AllBadgoods=isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=6 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te;
					
					--赠品
					select @AllGifts=isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=2 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te;
					
					--销售费用
					select @AllSalesCost=isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where StoresID=@tStoresID and mType=0 and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate
					
					insert into #ErpData_analysisData(StoresID,sName,Sales,SalesFees,GiftsFees,BadgoodsFees,ReturnsFees,CostFees,Profit)
						select s.StoresID,s.sName,@AllSales,@AllSalesCost,@AllGifts,@AllBadgoods,@AllReturns_Cost,(@AllCost-@AllReturns_Cost+@AllGifts+@AllBadgoods),(@AllSales-@AllSalesCost-(@AllCost-@AllReturns_Cost+@AllGifts+@AllBadgoods)) 
							from tbStoresInfo as s where s.StoresID=@tStoresID
				end
				else--统计福州永辉配送各超市数据
				begin

					
					--发货
					select @AllSales=isnull(@tempValue,0)*(isnull(tvalue,0)/@AllSumValue) 
						from #Sales_Staff_StoresSum where StoresID=@tStoresID;
					
					/*
					--退货
					select @AllSales=(select isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=0 and e.C_CODE='1020101001')*(tvalue/@AllSumValue) 
						from #Sales_Staff_StoresSum where StoresID=@tStoresID;
					*/
					
					--退货
					select @AllReturns=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate and e.StoresID=@tStoresID;
					
					--退货成本
					select @AllReturns_Cost=isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=5 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te;
					
					--成本
					select @AllCost=(select isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID_YH and e.R_ID=1 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te) *(isnull(tvalue,0)/@AllSumValue) 
						from #Sales_Staff_StoresSum where StoresID=@tStoresID;
					
					--坏货
					select @AllBadgoods=(select isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=6 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te) *(isnull(tvalue,0)/@AllSumValue)
						from #Sales_Staff_StoresSum where StoresID=@tStoresID;
					
					--赠品
					select @AllGifts=(select isnull(sum(isnull(te.tValue,0)),0) from(
						select e.S_QUANTITY*isnull((select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate),0) as tValue 
							from tbErpOrderInfo as e where e.StoresID=@tStoresID and e.R_ID=2 and e.O_CREATETIME>=@bDate and e.O_CREATETIME<=@eDate
						) as te) *(isnull(tvalue,0)/@AllSumValue)
						from #Sales_Staff_StoresSum where StoresID=@tStoresID;
					
					--销售费用
					select @AllSalesCost=isnull(sum(isnull(mFees,0)),0) from tbMarketingFeesInfo where StoresID=@tStoresID and mType=0 and mIsIncomeExpenditure=0 and mDateTime>=@bDate and mDateTime<=@eDate;
					
					
					insert into #ErpData_analysisData(StoresID,sName,Sales,SalesFees,GiftsFees,BadgoodsFees,ReturnsFees,CostFees,Profit)
						select s.StoresID,s.sName,@AllSales,@AllSalesCost,@AllGifts,@AllBadgoods,@AllReturns_Cost,(@AllCost-@AllReturns_Cost+@AllGifts+@AllBadgoods),(@AllSales-@AllSalesCost-(@AllCost-@AllReturns_Cost+@AllGifts+@AllBadgoods)) 
							from tbStoresInfo as s where s.StoresID=@tStoresID;
				end
				
			FETCH NEXT FROM ocur INTO @tStoresID,@tsName,@tsCode,@tYHsysID,@tRegionID,@sIsFZYH
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标

		select StoresID,sName,Sales,SalesFees,GiftsFees,BadgoodsFees,ReturnsFees,CostFees,Profit from #ErpData_analysisData order by Profit desc;
	end
	
	if @ShowType = 2 or  @ShowType = 3 --业务员,促销员
	begin
		--所有人员所有上下岗记录
		delete #Sales_Staff_StoresData;
		
		if @ShowType = 2
		begin
			set @tsType = 1;
			insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList 0,@bDate,@eDate,@tsType;
		end
		else if @ShowType = 3
		begin
			set @tsType = 2;
			insert into #Sales_Staff_StoresData(StaffStoresID,StoresID,StaffID,bdate,edate,StoresName,StaffName) exec sp_GetStaff_StoresList 0,@bDate,@eDate,@tsType;
		end
		
		--存成本数据
		declare @tTable table(cPrice money);
		declare @tTableL table(sName varchar(128),Sales money,SalesFees money,GiftsFees money,BadgoodsFees money,ReturnsFees money,CostFees money,Profit money);
		declare @tAllCostFees money;
		
		--组织销售数据
		if @StaffID > 0--指定业务员
		begin
			declare ocur cursor for select StoresID,StaffID,bdate,edate,(select sIsFZYH from tbStoresInfo where tbStoresInfo.StoresID=s.StoresID) sIsFZYH from #Sales_Staff_StoresData s where StaffID = @StaffID
		end
		else if @StaffIDB > 0 --指定促销员
		begin
			declare ocur cursor for select StoresID,StaffID,bdate,edate,(select sIsFZYH from tbStoresInfo where tbStoresInfo.StoresID=s.StoresID) sIsFZYH from #Sales_Staff_StoresData s where StaffID = @StaffIDB
		end
		else
		begin
			declare ocur cursor for select StoresID,StaffID,bdate,edate,(select sIsFZYH from tbStoresInfo where tbStoresInfo.StoresID=s.StoresID) sIsFZYH from #Sales_Staff_StoresData s
		end

		open ocur
		FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate,@tsIsFZYH
		WHILE @@FETCH_STATUS = 0
		begin
			if @tsIsFZYH<>1
			begin
				--发货
				insert into #Sales_Staff_StoresData_List(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,e.S_PRICE 
					from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=1 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate 	
				
				--退货
				insert into #Sales_Staff_StoresData_List_B(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=5 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--成本
				insert into #Sales_Staff_StoresData_List_C(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=1 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--坏货
				insert into #Sales_Staff_StoresData_List_D(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=6 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--赠品
				insert into #Sales_Staff_StoresData_List_E(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=2 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--销售费用
				insert into #Sales_Staff_StoresData_List_F(StoresID,StaffID,sdate,sPrice)
					select m.StoresID,ss.StaffID,m.mDateTime,m.mFees
						from tbMarketingFeesInfo m left join #Sales_Staff_StoresData ss on m.StoresID=ss.StoresID where m.StoresID=@tStoresID and m.mType=0 and m.mIsIncomeExpenditure=0 and m.mDateTime>=@tbDate and m.mDateTime<=@teDate
					
			end
			else--计算走永辉物流的
			begin

				--福州永辉各门店销售额，用于计算比例
				delete #Sales_Staff_StoresSum;
				
				insert into #Sales_Staff_StoresSum(StoresID,sName,tValue) 
					select StoresID,sName,tValue from fun_YHData(@tbDate,@teDate);
				
				select @AllSumValue=isnull(sum(isnull(tValue,0)),0) from #Sales_Staff_StoresSum;
			
				--永辉配送的总销售额
				select @tempValue=isnull(sum(isnull(e.S_TOTAL,0)),0) from tbErpOrderInfo as e where e.R_ID=1 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate and e.StoresID=@tStoresID_YH;
				
				--发货
				insert into #Sales_Staff_StoresData_List(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select 0,@tStoresID,0,ss.StaffID,null,0,(select isnull(@tempValue,0)*(isnull(tvalue,0)/@AllSumValue) from #Sales_Staff_StoresSum where StoresID=@tStoresID)  
					from #Sales_Staff_StoresData ss where ss.StoresID=@tStoresID 	
				
				--成本
				delete @tTable;
				
				insert into @tTable
					select isnull(e.S_QUANTITY,0)*(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e where e.R_ID=1 and e.StoresID=@tStoresID_YH and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				--总成本
				select @tAllCostFees=sum(cPrice) from @tTable	
				
				insert into #Sales_Staff_StoresData_List_C(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select 0,@tStoresID,0,ss.StaffID,null,0,
					(select isnull(@tAllCostFees*(isnull(tvalue,0)/@AllSumValue),0) from #Sales_Staff_StoresSum where StoresID=@tStoresID) 
						from #Sales_Staff_StoresData ss where ss.StoresID=@tStoresID

				
				--退货
				insert into #Sales_Staff_StoresData_List_B(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=5 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				
				--坏货
				insert into #Sales_Staff_StoresData_List_D(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=6 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--赠品
				insert into #Sales_Staff_StoresData_List_E(ErpOrderID,StoresID,ProductsID,StaffID,sdate,sNum,sPrice)
					select e.ErpOrderID,e.StoresID,e.ProductsID,ss.StaffID,e.O_CREATETIME,e.S_QUANTITY,(select top 1 t.cPrice from #ErpProductCostPrice_antmp as t where t.ProductsID=e.ProductsID and e.O_CREATETIME>=t.bdate and e.O_CREATETIME<=t.edate)
						from tbErpOrderInfo e left join #Sales_Staff_StoresData ss on e.StoresID=ss.StoresID where e.StoresID=@tStoresID and e.R_ID=2 and e.O_CREATETIME>=@tbDate and e.O_CREATETIME<=@teDate
				
				--销售费用
				insert into #Sales_Staff_StoresData_List_F(StoresID,StaffID,sdate,sPrice)
					select m.StoresID,ss.StaffID,m.mDateTime,m.mFees
						from tbMarketingFeesInfo m left join #Sales_Staff_StoresData ss on m.StoresID=ss.StoresID where m.StoresID=@tStoresID and m.mType=0 and m.mIsIncomeExpenditure=0 and m.mDateTime>=@tbDate and m.mDateTime<=@teDate
				
				
			end	
			FETCH NEXT FROM ocur INTO @tStoresID,@tStaffID,@tbDate,@teDate,@tsIsFZYH
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		
		declare @tV_a money,@tV_b money,@tV_c money,@tV_d money,@tV_e money,@tV_f money;
		
		declare ocur cursor for select StaffID,sName from tbStaffInfo where sType=@tsType
		open ocur
		FETCH NEXT FROM ocur INTO @tStaffID,@tsName
		WHILE @@FETCH_STATUS = 0
		begin
		
			select @tV_a=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List where StaffID=@tStaffID;
			select @tV_b=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List_F where StaffID=@tStaffID;
			select @tV_c=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List_E where StaffID=@tStaffID;
			select @tV_d=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List_D where StaffID=@tStaffID;
			select @tV_e=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List_B where StaffID=@tStaffID;
			select @tV_f=isnull(sum(isnull(sPrice,0)),0) from #Sales_Staff_StoresData_List_C where StaffID=@tStaffID;
			
			insert into @tTableL(sName,Sales,SalesFees,GiftsFees,BadgoodsFees,ReturnsFees,CostFees,Profit)
				select @tsName,@tV_a,@tV_b,@tV_c,@tV_d,@tV_e,@tV_f,(@tV_a-(@tV_f-@tV_e+@tV_d+@tV_c)-@tV_b)
				
			FETCH NEXT FROM ocur INTO @tStaffID,@tsName
		end
		CLOSE ocur--关闭游标
		DEALLOCATE ocur--释放游标
		
		select sName,Sales,SalesFees,GiftsFees,BadgoodsFees,ReturnsFees,CostFees,Profit from @tTableL order by Profit desc;		
		
	end
	
	if @ShowType = 4 -- 产品
	begin
		if @ProductID > 0
		begin
			exec sp_Products_analysis @bDate,@eDate,1,@ProductID;
		end
		else
		begin
			exec sp_Products_analysis @bDate,@eDate,1;
		end

	end
	
	if @ShowType = 5 -- 品牌
	begin
		if @Brand!=''
		begin
			exec sp_Products_analysis @bDate,@eDate,2,0,@Brand;
		end
		else
		begin
			exec sp_Products_analysis @bDate,@eDate,2;
		end
		
	end
	
	Drop table #ErpProductCostPrice_antmp
	Drop table #Sales_Staff_StoresData
	Drop table #ErpData_analysisData
	Drop table #Sales_Staff_StoresRegion
	Drop table #Sales_Staff_StoresData_List
	Drop table #Sales_Staff_StoresData_List_B
	Drop table #Sales_Staff_StoresData_List_C
	Drop table #Sales_Staff_StoresData_List_D
	Drop table #Sales_Staff_StoresData_List_E
	Drop table #Sales_Staff_StoresData_List_F
	Drop table #Sales_Staff_StoresSum
	Drop table #Products_analysis_List_t;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DayReportInvoicing]    Script Date: 10/11/2016 09:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- 每日/月/年统计,存档,进销存
-- =============================================
CREATE PROCEDURE [dbo].[sp_DayReportInvoicing]
	(
	@dT datetime 
	)
AS
begin
	declare @ThisMonthLastDay datetime;--本月最后一天
	declare @ThisYearLastDay datetime;--本年最后一天

	if @dT is null
	begin
		set @dT = getdate();
	end

	--删除原数据
	If object_id('tempdb..#DayInvoicingReport_tmp') is  not null
	Drop table #DayInvoicingReport_tmp
	--创建新临时表
	Create table #DayInvoicingReport_tmp (ProductsID int,StorageID int,
						sName varchar(128),
						pBarcode varchar(50),
						pToBoxNo varchar(10),
						pName varchar(128),
						pPrice money,
						beginQuantity numeric(18,6),
						UpStorage numeric(18,6),
						UpStorageIn numeric(18,6),
						UpStorageOut numeric(18,6),
						LastStorage numeric(18,6),
						StorageIn numeric(18,6),
						StorageOut numeric(18,6),
						ProductClassID int,

						beginMoney numeric(18,6),
						UpStorageMoney numeric(18,6),
						UpStorageInMoney numeric(18,6),
						UpStorageOutMoney numeric(18,6),
						LastStorageMoney numeric(18,6),

						StorageInMoney numeric(18,6),
						StorageOutMoney numeric(18,6)
					)


	--判断是否可进行月统计
	set @ThisMonthLastDay = dateadd(dd,-day(dateadd(m,1,@dT)),dateadd(m,1,@dT));

	if datediff(day,@dT,@ThisMonthLastDay)=0
	begin
		delete #DayInvoicingReport_tmp;
		insert into #DayInvoicingReport_tmp(ProductsID ,StorageID ,sName ,pBarcode ,pToBoxNo ,
							pName ,pPrice ,beginQuantity ,UpStorage ,UpStorageIn ,UpStorageOut ,
							LastStorage ,--LastStorageIn ,LastStorageOut ,
							StorageIn ,StorageOut ,ProductClassID,
							beginMoney,
							UpStorageMoney,UpStorageInMoney,UpStorageOutMoney,
							LastStorageMoney,--LastStorageInMoney,LastStorageOutMoney,
							StorageInMoney,StorageOutMoney)
			exec sp_GetInvoicingReport @dT,0,0,1,0;

			delete tbReportInvoicingDataInfo where datediff(month,rDateTime,@dT)=0 and rType=1;--清理当月旧记录

			insert into tbReportInvoicingDataInfo(ProductsID,StorageID,bQuantity,bMoney,InQuantity,InMoney,OutQuantity,OutMoney,eQuantity,eMoney,rType,rDateTime,rBDateTime,rEdateTime)
				select ProductsID,StorageID,
													(UpStorage+UpStorageIn-UpStorageOut	),--期初数量
													(UpStorageMoney+UpStorageInMoney-UpStorageOutMoney	),--期初成本
													StorageIn,StorageInMoney,--本期进库
													StorageOut,StorageOutMoney,--本期出库
													(LastStorage),--期末数量
													(LastStorageMoney),--期末成本
													1,@dT,dateadd(dd,-datepart(dd,@dT)+1,@dT),convert(datetime,convert(varchar(10),dateadd(day,-1,dateadd(month,1,@dT-day(@dT)+1)),23)+' 23:59:59') from #DayInvoicingReport_tmp;

	end

	--判断是否可进行年统计
	set @ThisYearLastDay = dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT)+1, 0));
	if datediff(day,@dT,@ThisYearLastDay)=0
	begin
		delete #DayInvoicingReport_tmp;
		insert into #DayInvoicingReport_tmp(ProductsID ,StorageID ,sName ,pBarcode ,pToBoxNo ,
							pName ,pPrice ,beginQuantity ,UpStorage ,UpStorageIn ,UpStorageOut ,
							LastStorage ,--LastStorageIn ,LastStorageOut ,
							StorageIn ,StorageOut ,ProductClassID,
							beginMoney,
							UpStorageMoney,UpStorageInMoney,UpStorageOutMoney,
							LastStorageMoney,--LastStorageInMoney,LastStorageOutMoney,
							StorageInMoney,StorageOutMoney )
			exec sp_GetInvoicingReport @dT,0,0,2,0;

			delete tbReportInvoicingDataInfo where datediff(year,rDateTime,@dT)=0 and rType=2;--清理当年旧记录
			insert into tbReportInvoicingDataInfo(ProductsID,StorageID,bQuantity,bMoney,InQuantity,InMoney,OutQuantity,OutMoney,eQuantity,eMoney,rType,rDateTime,rBDateTime,rEdateTime)
				select ProductsID,StorageID,
													(UpStorage+UpStorageIn-UpStorageOut
													),--期初数量
													(UpStorageMoney+UpStorageInMoney-UpStorageOutMoney
													),--期初成本
													StorageIn,StorageInMoney,--本期进库
													StorageOut,StorageOutMoney,--本期出库
													(LastStorage--+LastStorageIn-LastStorageOut
													),--期末数量
													(LastStorageMoney--+LastStorageInMoney-LastStorageOutMoney
													),--期末成本
													2,@dT,DATEADD(year, DATEDIFF(year, '', @dT), ''),dateadd(ms,-3,DATEADD(yy, DATEDIFF(yy,0,@dT)+1, 0)) from #DayInvoicingReport_tmp;

	end
	
	--日统计
	delete #DayInvoicingReport_tmp;
	insert into #DayInvoicingReport_tmp(ProductsID ,StorageID ,sName ,pBarcode ,pToBoxNo ,
						pName ,pPrice ,beginQuantity ,UpStorage ,UpStorageIn ,UpStorageOut ,
						LastStorage ,--LastStorageIn ,LastStorageOut ,
						StorageIn ,StorageOut ,ProductClassID,
						beginMoney,
						UpStorageMoney,UpStorageInMoney,UpStorageOutMoney,
						LastStorageMoney,--LastStorageInMoney,LastStorageOutMoney,
						StorageInMoney,StorageOutMoney )
		exec sp_GetInvoicingReport @dT,0,0,0,0;

	delete tbReportInvoicingDataInfo where datediff(day,rDateTime,@dT)=0 and rType=0;--清理当天旧记录

	insert into tbReportInvoicingDataInfo(ProductsID,ProductClassID,StorageID,bQuantity,bMoney,InQuantity,InMoney,OutQuantity,OutMoney,eQuantity,eMoney,rType,rDateTime,rBDateTime,rEdateTime,BadQuantity,BadMoney)
		select ProductsID,ProductClassID,StorageID,
													isnull((UpStorage+UpStorageIn-UpStorageOut
													),0),--期初数量
													isnull((UpStorageMoney+UpStorageInMoney-UpStorageOutMoney
													),0),--期初成本
													isnull(StorageIn,0),isnull(StorageInMoney,0),--本期进库
													isnull(StorageOut,0),isnull(StorageOutMoney,0),--本期出库
													isnull((LastStorage--+LastStorageIn-LastStorageOut
													),0),--期末数量
													isnull((LastStorageMoney--+LastStorageInMoney-LastStorageOutMoney
													),0),--期末成本
													0,@dT,convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 00:00:00'),convert(datetime,convert(varchar,DATEPART(year,@dT))+'-'+convert(varchar,DATEPART(month,@dT))+'-'+convert(varchar,DATEPART(day,@dT))+' 23:59:59'),0,0 from #DayInvoicingReport_tmp;

	Drop table #DayInvoicingReport_tmp;

end
GO
/****** Object:  Default [DF_tb_M_ExpressTemplatesInfo_mAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tb_M_ExpressTemplatesInfo] ADD  CONSTRAINT [DF_tb_M_ExpressTemplatesInfo_mAppendTime]  DEFAULT (getdate()) FOR [mAppendTime]
GO
/****** Object:  Default [DF_tb_M_GoodsCatInfo_mUpdateTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tb_M_GoodsCatInfo] ADD  CONSTRAINT [DF_tb_M_GoodsCatInfo_mUpdateTime]  DEFAULT (getdate()) FOR [mUpdateTime]
GO
/****** Object:  Default [DF_tb_M_GoodsInfo_m_IsDeltet]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tb_M_GoodsInfo] ADD  CONSTRAINT [DF_tb_M_GoodsInfo_m_IsDeltet]  DEFAULT ((0)) FOR [m_IsDeltet]
GO
/****** Object:  Default [DF_tb_M_GoodsInfo_m_UpdateTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tb_M_GoodsInfo] ADD  CONSTRAINT [DF_tb_M_GoodsInfo_m_UpdateTime]  DEFAULT (getdate()) FOR [m_UpdateTime]
GO
/****** Object:  Default [DF_tb_M_SendGoodsInfo_mAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tb_M_SendGoodsInfo] ADD  CONSTRAINT [DF_tb_M_SendGoodsInfo_mAppendTime]  DEFAULT (getdate()) FOR [mAppendTime]
GO
/****** Object:  Default [DF_tbAPMoneyInfo_aNPMoney]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbAPMoneyInfo] ADD  CONSTRAINT [DF_tbAPMoneyInfo_aNPMoney]  DEFAULT ((0)) FOR [aNPMoney]
GO
/****** Object:  Default [DF_tbAPMoneyInfo_FeesSubjectID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbAPMoneyInfo] ADD  CONSTRAINT [DF_tbAPMoneyInfo_FeesSubjectID]  DEFAULT ((0)) FOR [FeesSubjectID]
GO
/****** Object:  Default [DF_tbAPMoneyInfo_aAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbAPMoneyInfo] ADD  CONSTRAINT [DF_tbAPMoneyInfo_aAppendTime]  DEFAULT (getdate()) FOR [aAppendTime]
GO
/****** Object:  Default [DF_tbARMoneyInfo_aAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbARMoneyInfo] ADD  CONSTRAINT [DF_tbARMoneyInfo_aAppendTime]  DEFAULT (getdate()) FOR [aAppendTime]
GO
/****** Object:  Default [DF_tbBankCapitalAccountInfo_cDirection]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbBankCapitalAccountInfo] ADD  CONSTRAINT [DF_tbBankCapitalAccountInfo_cDirection]  DEFAULT ((0)) FOR [cDirection]
GO
/****** Object:  Default [DF_tbBankInfo_bAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbBankInfo] ADD  CONSTRAINT [DF_tbBankInfo_bAppendTime]  DEFAULT (getdate()) FOR [bAppendTime]
GO
/****** Object:  Default [DF_tbBankMoneyInfo_bAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbBankMoneyInfo] ADD  CONSTRAINT [DF_tbBankMoneyInfo_bAppendTime]  DEFAULT (getdate()) FOR [bAppendTime]
GO
/****** Object:  Default [DF_tbBankMoneyInfo_isBegin]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbBankMoneyInfo] ADD  CONSTRAINT [DF_tbBankMoneyInfo_isBegin]  DEFAULT ((0)) FOR [isBegin]
GO
/****** Object:  Default [DF_tbCertificateDataInfo_toObject]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateDataInfo] ADD  CONSTRAINT [DF_tbCertificateDataInfo_toObject]  DEFAULT ((0)) FOR [toObject]
GO
/****** Object:  Default [DF_tbCertificateDataInfo_toObjectID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateDataInfo] ADD  CONSTRAINT [DF_tbCertificateDataInfo_toObjectID]  DEFAULT ((0)) FOR [toObjectID]
GO
/****** Object:  Default [DF_tbCertificateDataInfo_cdMoneyB]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateDataInfo] ADD  CONSTRAINT [DF_tbCertificateDataInfo_cdMoneyB]  DEFAULT ((0)) FOR [cdMoneyB]
GO
/****** Object:  Default [DF_tbCertificateInfo_cNumber]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateInfo] ADD  CONSTRAINT [DF_tbCertificateInfo_cNumber]  DEFAULT ((0)) FOR [cNumber]
GO
/****** Object:  Default [DF_tbCertificateInfo_BankID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateInfo] ADD  CONSTRAINT [DF_tbCertificateInfo_BankID]  DEFAULT ((0)) FOR [BankID]
GO
/****** Object:  Default [DF_tbCertificateInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateInfo] ADD  CONSTRAINT [DF_tbCertificateInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbCertificateInfo_cSteps]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateInfo] ADD  CONSTRAINT [DF_tbCertificateInfo_cSteps]  DEFAULT ((0)) FOR [cSteps]
GO
/****** Object:  Default [DF_tbCertificatePicInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificatePicInfo] ADD  CONSTRAINT [DF_tbCertificatePicInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbCertificateWorkingLogInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCertificateWorkingLogInfo] ADD  CONSTRAINT [DF_tbCertificateWorkingLogInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbCostValenceInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCostValenceInfo] ADD  CONSTRAINT [DF_tbCostValenceInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbCustomersClassInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbCustomersClassInfo] ADD  CONSTRAINT [DF_tbCustomersClassInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbDataToMailInfo_dAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbDataToMailInfo] ADD  CONSTRAINT [DF_tbDataToMailInfo_dAppendTime]  DEFAULT (getdate()) FOR [dAppendTime]
GO
/****** Object:  Default [DF_tbDepartmentsClassInfo_dAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbDepartmentsClassInfo] ADD  CONSTRAINT [DF_tbDepartmentsClassInfo_dAppendTime]  DEFAULT (getdate()) FOR [dAppendTime]
GO
/****** Object:  Default [DF_tbErpOrderInfo_StoresID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_StoresID]  DEFAULT ((0)) FOR [StoresID]
GO
/****** Object:  Default [DF_tbErpOrderInfo_StaffID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_StaffID]  DEFAULT ((0)) FOR [StaffID]
GO
/****** Object:  Default [DF_tbErpOrderInfo_PROMOTIONS]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_PROMOTIONS]  DEFAULT ((0)) FOR [PROMOTIONS]
GO
/****** Object:  Default [DF_tbErpOrderInfo_IsCheck]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_IsCheck]  DEFAULT ((0)) FOR [IsCheck]
GO
/****** Object:  Default [DF_tbErpOrderInfo_storageid]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_storageid]  DEFAULT ((6540)) FOR [storageid]
GO
/****** Object:  Default [DF_tbErpOrderInfo_eAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbErpOrderInfo] ADD  CONSTRAINT [DF_tbErpOrderInfo_eAppendTime]  DEFAULT (getdate()) FOR [eAppendTime]
GO
/****** Object:  Default [DF_tbEventLogInfo_eAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbEventLogInfo] ADD  CONSTRAINT [DF_tbEventLogInfo_eAppendTime]  DEFAULT (getdate()) FOR [eAppendTime]
GO
/****** Object:  Default [DF_tbFeesSubjectClassInfo_cAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectClassInfo] ADD  CONSTRAINT [DF_tbFeesSubjectClassInfo_cAppendTime]  DEFAULT (getdate()) FOR [cAppendTime]
GO
/****** Object:  Default [DF_tbFeesSubjectClassInfo_cDirection]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectClassInfo] ADD  CONSTRAINT [DF_tbFeesSubjectClassInfo_cDirection]  DEFAULT ((0)) FOR [cDirection]
GO
/****** Object:  Default [DF_tbFeesSubjectClassInfo_cCode]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectClassInfo] ADD  CONSTRAINT [DF_tbFeesSubjectClassInfo_cCode]  DEFAULT ('') FOR [cCode]
GO
/****** Object:  Default [DF_tbFeesSubjectClassInfo_cType]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectClassInfo] ADD  CONSTRAINT [DF_tbFeesSubjectClassInfo_cType]  DEFAULT ((0)) FOR [cType]
GO
/****** Object:  Default [DF_tbFeesSubjectInfo_FeesSubjectClassID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectInfo] ADD  CONSTRAINT [DF_tbFeesSubjectInfo_FeesSubjectClassID]  DEFAULT ((0)) FOR [FeesSubjectClassID]
GO
/****** Object:  Default [DF_tbFeesSubjectInfo_fDebitCredit]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectInfo] ADD  CONSTRAINT [DF_tbFeesSubjectInfo_fDebitCredit]  DEFAULT ((0)) FOR [fDebitCredit]
GO
/****** Object:  Default [DF_tbFeesSubjectMoneyDataInfo_fAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbFeesSubjectMoneyDataInfo] ADD  CONSTRAINT [DF_tbFeesSubjectMoneyDataInfo_fAppendTime]  DEFAULT (getdate()) FOR [fAppendTime]
GO
/****** Object:  Default [DF_tbMarketingFeesInfo_mIsIncomeExpenditure]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMarketingFeesInfo] ADD  CONSTRAINT [DF_tbMarketingFeesInfo_mIsIncomeExpenditure]  DEFAULT ((0)) FOR [mIsIncomeExpenditure]
GO
/****** Object:  Default [DF_tbMonthlyStatementAppendDataInfo_aAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMonthlyStatementAppendDataInfo] ADD  CONSTRAINT [DF_tbMonthlyStatementAppendDataInfo_aAppendTime]  DEFAULT (getdate()) FOR [aAppendTime]
GO
/****** Object:  Default [DF_tbMonthlyStatementAppendMoneyDataInfo_mAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMonthlyStatementAppendMoneyDataInfo] ADD  CONSTRAINT [DF_tbMonthlyStatementAppendMoneyDataInfo_mAppendTime]  DEFAULT (getdate()) FOR [mAppendTime]
GO
/****** Object:  Default [DF_tbMonthlyStatementDataInfo_sAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMonthlyStatementDataInfo] ADD  CONSTRAINT [DF_tbMonthlyStatementDataInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbMonthlyStatementInfo_sAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMonthlyStatementInfo] ADD  CONSTRAINT [DF_tbMonthlyStatementInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbMonthlyStatementWorkingLogInfo_mAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbMonthlyStatementWorkingLogInfo] ADD  CONSTRAINT [DF_tbMonthlyStatementWorkingLogInfo_mAppendTime]  DEFAULT (getdate()) FOR [mAppendTime]
GO
/****** Object:  Default [DF_tbOrderFieldInfo_fPrint]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderFieldInfo] ADD  CONSTRAINT [DF_tbOrderFieldInfo_fPrint]  DEFAULT ((0)) FOR [fPrint]
GO
/****** Object:  Default [DF_tbOrderFieldInfo_fPrintAdd]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderFieldInfo] ADD  CONSTRAINT [DF_tbOrderFieldInfo_fPrintAdd]  DEFAULT ((0)) FOR [fPrintAdd]
GO
/****** Object:  Default [DF_tbOrderFieldValueInfo_oAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderFieldValueInfo] ADD  CONSTRAINT [DF_tbOrderFieldValueInfo_oAppendTime]  DEFAULT (getdate()) FOR [oAppendTime]
GO
/****** Object:  Default [DF_tbOrderInfo_oAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderInfo] ADD  CONSTRAINT [DF_tbOrderInfo_oAppendTime]  DEFAULT (getdate()) FOR [oAppendTime]
GO
/****** Object:  Default [DF_tbOrderInfo_oPrepay]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderInfo] ADD  CONSTRAINT [DF_tbOrderInfo_oPrepay]  DEFAULT ((0)) FOR [oPrepay]
GO
/****** Object:  Default [DF_tbOrderListInfo_oAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderListInfo] ADD  CONSTRAINT [DF_tbOrderListInfo_oAppendTime]  DEFAULT (getdate()) FOR [oAppendTime]
GO
/****** Object:  Default [DF_tbOrderListInfo_IsGifts]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderListInfo] ADD  CONSTRAINT [DF_tbOrderListInfo_IsGifts]  DEFAULT ((0)) FOR [IsGifts]
GO
/****** Object:  Default [DF_tbOrderListInfo_PriceClassID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderListInfo] ADD  CONSTRAINT [DF_tbOrderListInfo_PriceClassID]  DEFAULT ((0)) FOR [PriceClassID]
GO
/****** Object:  Default [DF_tbOrderNOFullInfo_oNextOrderID]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderNOFullInfo] ADD  CONSTRAINT [DF_tbOrderNOFullInfo_oNextOrderID]  DEFAULT ((0)) FOR [oNextOrderID]
GO
/****** Object:  Default [DF_tbOrderNOFullInfo_oAppendTimie]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderNOFullInfo] ADD  CONSTRAINT [DF_tbOrderNOFullInfo_oAppendTimie]  DEFAULT (getdate()) FOR [oAppendTimie]
GO
/****** Object:  Default [DF_tbOrderWorkingLogInfo_pAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbOrderWorkingLogInfo] ADD  CONSTRAINT [DF_tbOrderWorkingLogInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF_tbPaymentSystemInfo_pAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbPaymentSystemInfo] ADD  CONSTRAINT [DF_tbPaymentSystemInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF__tbPriceCl__pIsEd__01D345B0]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbPriceClassDefaultPriceInfo] ADD  DEFAULT ((0)) FOR [pIsEdit]
GO
/****** Object:  Default [DF_tbPriceClassInfo_pAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbPriceClassInfo] ADD  CONSTRAINT [DF_tbPriceClassInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF_tbProductClassInfo_pAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbProductClassInfo] ADD  CONSTRAINT [DF_tbProductClassInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF_tbProductFieldInfo_pfAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbProductFieldInfo] ADD  CONSTRAINT [DF_tbProductFieldInfo_pfAppendTime]  DEFAULT (getdate()) FOR [pfAppendTime]
GO
/****** Object:  Default [DF_tbProductPriceNOAutoInfo_PriceRMB]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbProductPriceNOAutoInfo] ADD  CONSTRAINT [DF_tbProductPriceNOAutoInfo_PriceRMB]  DEFAULT ((0)) FOR [PriceRMB]
GO
/****** Object:  Default [DF_tbProductPriceNOAutoInfo_ppAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbProductPriceNOAutoInfo] ADD  CONSTRAINT [DF_tbProductPriceNOAutoInfo_ppAppendTime]  DEFAULT (getdate()) FOR [ppAppendTime]
GO
/****** Object:  Default [DF_tbProductsFieldValueInfo_pfvAppendTime]    Script Date: 10/11/2016 09:51:45 ******/
ALTER TABLE [dbo].[tbProductsFieldValueInfo] ADD  CONSTRAINT [DF_tbProductsFieldValueInfo_pfvAppendTime]  DEFAULT (getdate()) FOR [pfvAppendTime]
GO
/****** Object:  Default [DF_tbProductsInfo_ProductClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_ProductClassID]  DEFAULT ((0)) FOR [ProductClassID]
GO
/****** Object:  Default [DF_tbProductsInfo_pMaxUnits]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pMaxUnits]  DEFAULT ('') FOR [pMaxUnits]
GO
/****** Object:  Default [DF_tbProductsInfo_pPrice]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pPrice]  DEFAULT ((0)) FOR [pPrice]
GO
/****** Object:  Default [DF_tbProductsInfo_pSellingPrice]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pSellingPrice]  DEFAULT ((0)) FOR [pSellingPrice]
GO
/****** Object:  Default [DF_tbProductsInfo_pState]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pState]  DEFAULT ((0)) FOR [pState]
GO
/****** Object:  Default [DF_tbProductsInfo_pDoDayQuantity]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pDoDayQuantity]  DEFAULT ((0)) FOR [pDoDayQuantity]
GO
/****** Object:  Default [DF_tbProductsInfo_pAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsInfo] ADD  CONSTRAINT [DF_tbProductsInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF_tbProductsStorageLogInfo_pAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbProductsStorageLogInfo] ADD  CONSTRAINT [DF_tbProductsStorageLogInfo_pAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
/****** Object:  Default [DF_tbRegionInfo$_rAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbRegionInfo] ADD  CONSTRAINT [DF_tbRegionInfo$_rAppendTime]  DEFAULT (getdate()) FOR [rAppendTime]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_ProductClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_ProductClassID]  DEFAULT ((0)) FOR [ProductClassID]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_bMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_bMoney]  DEFAULT ((0)) FOR [bMoney]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_InMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_InMoney]  DEFAULT ((0)) FOR [InMoney]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_OutMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_OutMoney]  DEFAULT ((0)) FOR [OutMoney]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_eMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_eMoney]  DEFAULT ((0)) FOR [eMoney]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_BadQuantity]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_BadQuantity]  DEFAULT ((0)) FOR [BadQuantity]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_BadMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_BadMoney]  DEFAULT ((0)) FOR [BadMoney]
GO
/****** Object:  Default [DF_tbReportInvoicingDataInfo_rDateTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbReportInvoicingDataInfo] ADD  CONSTRAINT [DF_tbReportInvoicingDataInfo_rDateTime]  DEFAULT (getdate()) FOR [rDateTime]
GO
/****** Object:  Default [DF_tbSalesInfo_sIsYH]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbSalesInfo] ADD  CONSTRAINT [DF_tbSalesInfo_sIsYH]  DEFAULT ((0)) FOR [sIsYH]
GO
/****** Object:  Default [DF_tbStaffAnalysisDataInfo_aAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStaffAnalysisDataInfo] ADD  CONSTRAINT [DF_tbStaffAnalysisDataInfo_aAppendTime]  DEFAULT (getdate()) FOR [aAppendTime]
GO
/****** Object:  Default [DF_tbStaffInfo_DepartmentsClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStaffInfo] ADD  CONSTRAINT [DF_tbStaffInfo_DepartmentsClassID]  DEFAULT ((0)) FOR [DepartmentsClassID]
GO
/****** Object:  Default [DF_tbStockProductInfo_StorageID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStockProductInfo] ADD  CONSTRAINT [DF_tbStockProductInfo_StorageID]  DEFAULT ((1)) FOR [StorageID]
GO
/****** Object:  Default [DF_tbStockProductInfo_sAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStockProductInfo] ADD  CONSTRAINT [DF_tbStockProductInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbStocktakeInfo_StockID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStocktakeInfo] ADD  CONSTRAINT [DF_tbStocktakeInfo_StockID]  DEFAULT ((0)) FOR [StockID]
GO
/****** Object:  Default [DF_tbStorageInfo_sAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStorageInfo] ADD  CONSTRAINT [DF_tbStorageInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF__tbStorage__Stora__1F63A897]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStorageInfo] ADD  DEFAULT ((0)) FOR [StorageClassID]
GO
/****** Object:  Default [DF_tbStorageInfo_sState]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStorageInfo] ADD  CONSTRAINT [DF_tbStorageInfo_sState]  DEFAULT ((0)) FOR [sState]
GO
/****** Object:  Default [DF_tbStoresInfo_sCode]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sCode]  DEFAULT ('') FOR [sCode]
GO
/****** Object:  Default [DF_tbStoresInfo_sLicense]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sLicense]  DEFAULT ('') FOR [sLicense]
GO
/****** Object:  Default [DF_tbStoresInfo_CustomersClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_CustomersClassID]  DEFAULT ((0)) FOR [CustomersClassID]
GO
/****** Object:  Default [DF_tbStoresInfo_PriceClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_PriceClassID]  DEFAULT ((0)) FOR [PriceClassID]
GO
/****** Object:  Default [DF_tbStoresInfo_sType]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sType]  DEFAULT ('') FOR [sType]
GO
/****** Object:  Default [DF_tbStoresInfo_RegionID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_RegionID]  DEFAULT ((0)) FOR [RegionID]
GO
/****** Object:  Default [DF_tbStoresInfo_YHsysID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_YHsysID]  DEFAULT ((0)) FOR [YHsysID]
GO
/****** Object:  Default [DF_tbStoresInfo_sState]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sState]  DEFAULT ((0)) FOR [sState]
GO
/****** Object:  Default [DF_tbStoresInfo_sIsFZYH]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sIsFZYH]  DEFAULT ((0)) FOR [sIsFZYH]
GO
/****** Object:  Default [DF_tbStoresInfo_sDoDay]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sDoDay]  DEFAULT ((0)) FOR [sDoDay]
GO
/****** Object:  Default [DF_tbStoresInfo_sDoDayMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sDoDayMoney]  DEFAULT ((0)) FOR [sDoDayMoney]
GO
/****** Object:  Default [DF_tbStoresInfo_PaymentSystemID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_PaymentSystemID]  DEFAULT ((0)) FOR [PaymentSystemID]
GO
/****** Object:  Default [DF_tbStoresInfo_sAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoresInfo] ADD  CONSTRAINT [DF_tbStoresInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbStoreStorehouseInfo_sCode]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoreStorehouseInfo] ADD  CONSTRAINT [DF_tbStoreStorehouseInfo_sCode]  DEFAULT ('') FOR [sCode]
GO
/****** Object:  Default [DF_tbStoreStorehouseInfo_pMoney]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbStoreStorehouseInfo] ADD  CONSTRAINT [DF_tbStoreStorehouseInfo_pMoney]  DEFAULT ((0)) FOR [pMoney]
GO
/****** Object:  Default [DF_tbSupplierClassInfo_sAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbSupplierClassInfo] ADD  CONSTRAINT [DF_tbSupplierClassInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbSupplierInfo_SupplierClassID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbSupplierInfo] ADD  CONSTRAINT [DF_tbSupplierInfo_SupplierClassID]  DEFAULT ((0)) FOR [SupplierClassID]
GO
/****** Object:  Default [DF_tbSupplierInfo_sLicense]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbSupplierInfo] ADD  CONSTRAINT [DF_tbSupplierInfo_sLicense]  DEFAULT ('') FOR [sLicense]
GO
/****** Object:  Default [DF_tbSupplierInfo_sAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbSupplierInfo] ADD  CONSTRAINT [DF_tbSupplierInfo_sAppendTime]  DEFAULT (getdate()) FOR [sAppendTime]
GO
/****** Object:  Default [DF_tbUserFailedLoginLogInfo_errcount]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserFailedLoginLogInfo] ADD  CONSTRAINT [DF_tbUserFailedLoginLogInfo_errcount]  DEFAULT ((0)) FOR [errcount]
GO
/****** Object:  Default [DF_tbUserFailedLoginLogInfo_lastupdate]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserFailedLoginLogInfo] ADD  CONSTRAINT [DF_tbUserFailedLoginLogInfo_lastupdate]  DEFAULT (getdate()) FOR [lastupdate]
GO
/****** Object:  Default [DF_tbUserInfo_StaffID]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_StaffID]  DEFAULT ((0)) FOR [StaffID]
GO
/****** Object:  Default [DF_tbUserInfo_uType]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_uType]  DEFAULT ((0)) FOR [uType]
GO
/****** Object:  Default [DF_tbUserInfo_olTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_olTime]  DEFAULT ((0)) FOR [olTime]
GO
/****** Object:  Default [DF_online_userid]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_userid]  DEFAULT ((-1)) FOR [UserID]
GO
/****** Object:  Default [DF_online_ip]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_ip]  DEFAULT ('0.0.0.0') FOR [oIP]
GO
/****** Object:  Default [DF_online_username]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_username]  DEFAULT ('') FOR [oUserName]
GO
/****** Object:  Default [DF_online_nickname]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_nickname]  DEFAULT ('') FOR [UserGroupsID]
GO
/****** Object:  Default [DF_online_password]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_password]  DEFAULT ('') FOR [UserSPID]
GO
/****** Object:  Default [DF_online_groupid]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_groupid]  DEFAULT ((0)) FOR [oAppendTime]
GO
/****** Object:  Default [DF_online_olimg]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineLogInfo] ADD  CONSTRAINT [DF_online_olimg]  DEFAULT ('') FOR [oLastTime]
GO
/****** Object:  Default [DF_onlinetime_thismonth]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineTime_Bak] ADD  CONSTRAINT [DF_onlinetime_thismonth]  DEFAULT ((0)) FOR [thismonth]
GO
/****** Object:  Default [DF_onlinetime_total]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineTime_Bak] ADD  CONSTRAINT [DF_onlinetime_total]  DEFAULT ((0)) FOR [total]
GO
/****** Object:  Default [DF_onlinetime_lastupdate]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbUserOnLineTime_Bak] ADD  CONSTRAINT [DF_onlinetime_lastupdate]  DEFAULT (getdate()) FOR [lastupdate]
GO
/****** Object:  Default [DF_tbYHsysInfo_yAppendTime]    Script Date: 10/11/2016 09:51:46 ******/
ALTER TABLE [dbo].[tbYHsysInfo] ADD  CONSTRAINT [DF_tbYHsysInfo_yAppendTime]  DEFAULT (getdate()) FOR [yAppendTime]
GO

--添加管理员账号:admin 密码:88888888
insert into tbUserInfo(uName,StaffID,uPWD,uCode,uPermissions,uAppendTime,uUpAppendTime,uLastIP,uType,uEstate,olTime) values('admin',0,'8ddcff3a80f4189ca1c9d4d902c3c909','f7b5c','X',getdate(),getdate(),'',0,0,1);