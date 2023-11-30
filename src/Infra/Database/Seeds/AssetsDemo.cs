using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Seeds;

public static class AssetsDemo
{
	public static void AssetsSeed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AssetModel>().HasData
		(
			new AssetModel
			{
				Id = 1,
				Symbol = "ALPA4", Name = "ALPARGATAS", AvailableQuantity = 201257220,
				Price = (decimal)20.63
			},
			new AssetModel
			{
				Id = 3,
				Symbol = "ABEV3", Name = "AMBEV S/A", AvailableQuantity = 201257220,
				Price = (decimal)14.51
			},
			new AssetModel
			{
				Id = 4,
				Symbol = "AMER3", Name = "AMERICANAS", AvailableQuantity = 596875824,
				Price = (decimal)15.93
			},
			new AssetModel
			{
				Id = 5,
				Symbol = "ASAI3", Name = "ASSAI", AvailableQuantity = 794531367,
				Price = (decimal)15.65
			},
			new AssetModel
			{
				Id = 6,
				Symbol = "AZUL4", Name = "AZUL", AvailableQuantity = 327741172,
				Price = (decimal)11.58
			},
			new AssetModel
			{
				Id = 7,
				Symbol = "B3SA3", Name = "B3", AvailableQuantity = 327741172,
				Price = (decimal)10.72
			},
			new AssetModel
			{
				Id = 8,
				Symbol = "BPAN4", Name = "BANCO PAN", AvailableQuantity = 341124068,
				Price = (decimal)7.08
			},
			new AssetModel
			{
				Id = 9, Symbol = "BBSE3", Name = "BBSEGURIDADE", AvailableQuantity = 671629692,
				Price = (decimal)27.88
			},
			new AssetModel
			{
				Id = 10, Symbol = "BRML3", Name = "BR MALLS PAR", AvailableQuantity = 828273884,
				Price = (decimal)7.82
			},
			new AssetModel
			{
				Id = 11, Symbol = "BBDC3", Name = "BRADESCO", AvailableQuantity = 1516726535,
				Price = (decimal)14.16
			},
			new AssetModel
			{
				Id = 12, Symbol = "BBDC4", Name = "BRADESCO", AvailableQuantity = 201257220,
				Price = (decimal)17.05
			},
			new AssetModel
			{
				Id = 13, Symbol = "BRAP4", Name = "BRADESPAR", AvailableQuantity = 251402249,
				Price = (decimal)22.33
			},
			new AssetModel
			{
				Id = 14, Symbol = "BBAS3", Name = "BRASIL", AvailableQuantity = 1420530937,
				Price = (decimal)34.67
			},
			new AssetModel
			{
				Id = 15, Symbol = "BRKM5", Name = "BRASKEM", AvailableQuantity = 264975728,
				Price = (decimal)34.08
			},
			new AssetModel
			{
				Id = 16, Symbol = "BRFS3", Name = "BRF SA", AvailableQuantity = 1076512610,
				Price = (decimal)16.07
			},
			new AssetModel
			{
				Id = 17, Symbol = "BPAC11", Name = "BTGP BANCO", AvailableQuantity = 1301655996,
				Price = (decimal)22.47
			},
			new AssetModel
			{
				Id = 18, Symbol = "CRFB3", Name = "CARREFOUR BR", AvailableQuantity = 410988561,
				Price = (decimal)16.93
			},
			new AssetModel
			{
				Id = 19, Symbol = "CCRO3", Name = "CCR SA", AvailableQuantity = 1115693556,
				Price = (decimal)12.28
			},
			new AssetModel
			{
				Id = 20, Symbol = "CMIG4", Name = "CEMIG", AvailableQuantity = 1448479060,
				Price = (decimal)10.65
			},
			new AssetModel
			{
				Id = 21, Symbol = "CIEL3", Name = "CIELO", AvailableQuantity = 1144359228,
				Price = (decimal)4.08
			},
			new AssetModel
			{
				Id = 22, Symbol = "COGN3", Name = "COGNA ON", AvailableQuantity = 1828106676,
				Price = (decimal)2.22
			},
			new AssetModel
			{
				Id = 23, Symbol = "CPLE6", Name = "COPEL", AvailableQuantity = 1563365506,
				Price = (decimal)6.90
			},
			new AssetModel
			{
				Id = 24, Symbol = "CSAN3", Name = "COSAN", AvailableQuantity = 1171063698,
				Price = (decimal)17.49
			},
			new AssetModel
			{
				Id = 25, Symbol = "CPFE3", Name = "CPFL ENERGIA", AvailableQuantity = 187732538,
				Price = (decimal)32.14
			},
			new AssetModel
			{
				Id = 26, Symbol = "CMIN3", Name = "CSNMINERACAO", AvailableQuantity = 1120593365,
				Price = (decimal)3.40
			},
			new AssetModel
			{
				Id = 27, Symbol = "CVCB3", Name = "CVC BRASIL", AvailableQuantity = 276543929,
				Price = (decimal)6.76
			},
			new AssetModel
			{
				Id = 28, Symbol = "CYRE3", Name = "CYRELA REALT", AvailableQuantity = 281609283,
				Price = (decimal)12.26
			},
			new AssetModel
			{
				Id = 29, Symbol = "DXCO3", Name = "DEXCO", AvailableQuantity = 295712871,
				Price = (decimal)9.71
			},
			new AssetModel
			{
				Id = 30, Symbol = "ECOR3", Name = "ECORODOVIAS", AvailableQuantity = 339237914,
				Price = (decimal)5.40
			},
			new AssetModel
			{
				Id = 31, Symbol = "ELET3", Name = "ELETROBRAS", AvailableQuantity = 985704248,
				Price = (decimal)44.63
			},
			new AssetModel
			{
				Id = 32, Symbol = "ELET6", Name = "ELETROBRAS", AvailableQuantity = 242987127,
				Price = (decimal)45.67
			},
			new AssetModel
			{
				Id = 33, Symbol = "EMBR3", Name = "EMBRAER", AvailableQuantity = 734588205,
				Price = (decimal)11.87
			},
			new AssetModel
			{
				Id = 34, Symbol = "ENBR3", Name = "ENERGIAS BR", AvailableQuantity = 230931405,
				Price = (decimal)21.29
			},
			new AssetModel
			{
				Id = 35, Symbol = "ENGI11", Name = "ENERGISA", AvailableQuantity = 248477689,
				Price = (decimal)40.65
			},
			new AssetModel
			{
				Id = 36, Symbol = "ENEV3", Name = "ENEVA", AvailableQuantity = 1557479978,
				Price = (decimal)14.35
			},
			new AssetModel
			{
				Id = 37, Symbol = "EGIE3", Name = "ENGIE BRASIL", AvailableQuantity = 255217329,
				Price = (decimal)42.17
			},
			new AssetModel
			{
				Id = 38, Symbol = "EQTL3", Name = "EQUATORIAL", AvailableQuantity = 1100513485,
				Price = (decimal)23.05
			},
			new AssetModel
			{
				Id = 39, Symbol = "EZTC3", Name = "EZTEC", AvailableQuantity = 101618236,
				Price = (decimal)16.37
			},
			new AssetModel
			{
				Id = 40, Symbol = "FLRY3", Name = "FLEURY", AvailableQuantity = 303373882,
				Price = (decimal)15.27
			},
			new AssetModel
			{
				Id = 41, Symbol = "GGBR4", Name = "GERDAU", AvailableQuantity = 1097534498,
				Price = (decimal)23.81
			},
			new AssetModel
			{
				Id = 42, Symbol = "GOAU4", Name = "GERDAU MET", AvailableQuantity = 698275321,
				Price = (decimal)9.94
			},
			new AssetModel
			{
				Id = 43, Symbol = "GOLL4", Name = "GOL", AvailableQuantity = 167095214,
				Price = (decimal)7.97
			},
			new AssetModel
			{
				Id = 44, Symbol = "NTCO3", Name = "GRUPO NATURA", AvailableQuantity = 834914221,
				Price = (decimal)15.84
			},
			new AssetModel
			{
				Id = 45, Symbol = "SOMA3", Name = "GRUPO SOMA", AvailableQuantity = 489316435,
				Price = (decimal)9.77
			},
			new AssetModel
			{
				Id = 46, Symbol = "HAPV3", Name = "HAPVIDA", AvailableQuantity = 201257220,
				Price = (decimal)5.95
			},
			new AssetModel
			{
				Id = 47, Symbol = "HYPE3", Name = "HYPERA", AvailableQuantity = 410253528,
				Price = (decimal)39.93
			},
			new AssetModel
			{
				Id = 48, Symbol = "IGTI11", Name = "IGUATEMI SA", AvailableQuantity = 180013980,
				Price = (decimal)18.87
			},
			new AssetModel
			{
				Id = 49, Symbol = "IRBR3", Name = "IRBBRASIL RE", AvailableQuantity = 1255286531,
				Price = (decimal)2.00
			},
			new AssetModel
			{
				Id = 50, Symbol = "ITSA4", Name = "ITAUSA", AvailableQuantity = 201257220,
				Price = (decimal)8.47
			},
			new AssetModel
			{
				Id = 51, Symbol = "ITUB4", Name = "ITAUUNIBANCO", AvailableQuantity = 201257220,
				Price = (decimal)23.26
			},
			new AssetModel
			{
				Id = 52, Symbol = "JBSS3", Name = "JBS", AvailableQuantity = 1290736673,
				Price = (decimal)30.73
			},
			new AssetModel
			{
				Id = 53, Symbol = "JHSF3", Name = "JHSF PART", AvailableQuantity = 305915142,
				Price = (decimal)5.60
			},
			new AssetModel
			{
				Id = 54, Symbol = "KLBN11", Name = "KLABIN S/A", AvailableQuantity = 812994397,
				Price = (decimal)18.90
			},
			new AssetModel
			{
				Id = 55, Symbol = "RENT3", Name = "LOCALIZA", AvailableQuantity = 735708470,
				Price = (decimal)55.42
			},
			new AssetModel
			{
				Id = 56, Symbol = "LWSA3", Name = "LOCAWEB", AvailableQuantity = 418965264,
				Price = (decimal)6.74
			},
			new AssetModel
			{
				Id = 57, Symbol = "LREN3", Name = "LOJAS RENNER", AvailableQuantity = 977821540,
				Price = (decimal)24.42
			},
			new AssetModel
			{
				Id = 58, Symbol = "MGLU3", Name = "MAGAZ LUIZA", AvailableQuantity = 201257220,
				Price = (decimal)2.86
			},
			new AssetModel
			{
				Id = 59, Symbol = "MRFG3", Name = "MARFRIG", AvailableQuantity = 348234011,
				Price = (decimal)13.39
			},
			new AssetModel
			{
				Id = 60, Symbol = "CASH3", Name = "MELIUZ", AvailableQuantity = 548153725,
				Price = (decimal)1.08
			},
			new AssetModel
			{
				Id = 61, Symbol = "BEEF3", Name = "MINERVA", AvailableQuantity = 260409710,
				Price = (decimal)13.22
			},
			new AssetModel
			{
				Id = 62, Symbol = "MRVE3", Name = "MRV", AvailableQuantity = 294647234,
				Price = (decimal)8.68
			},
			new AssetModel
			{
				Id = 63, Symbol = "MULT3", Name = "MULTIPLAN", AvailableQuantity = 272718548,
				Price = (decimal)23.98
			},
			new AssetModel
			{
				Id = 64, Symbol = "PCAR3", Name = "PACUCAR-CBD", AvailableQuantity = 156946474,
				Price = (decimal)16.90
			},
			new AssetModel
			{
				Id = 65, Symbol = "PETR3", Name = "PETROBRAS", AvailableQuantity = 201257220,
				Price = (decimal)31.93
			},
			new AssetModel
			{
				Id = 66, Symbol = "PETR4", Name = "PETROBRAS", AvailableQuantity = 201257220,
				Price = (decimal)29.33
			},
			new AssetModel
			{
				Id = 67, Symbol = "PRIO3", Name = "PETRORIO", AvailableQuantity = 839159130,
				Price = (decimal)22.67
			},
			new AssetModel
			{
				Id = 68, Symbol = "PETZ3", Name = "PETZ", AvailableQuantity = 336154589,
				Price = (decimal)9.87
			},
			new AssetModel
			{
				Id = 69, Symbol = "POSI3", Name = "POSITIVO TEC", AvailableQuantity = 78053723,
				Price = (decimal)6.64
			},
			new AssetModel
			{
				Id = 70, Symbol = "QUAL3", Name = "QUALICORP", AvailableQuantity = 277027077,
				Price = (decimal)10.43
			},
			new AssetModel
			{
				Id = 71, Symbol = "RADL3", Name = "RAIADROGASIL", AvailableQuantity = 1071076905,
				Price = (decimal)20.03
			},
			new AssetModel
			{
				Id = 72, Symbol = "RDOR3", Name = "REDE D OR", AvailableQuantity = 772010260,
				Price = (decimal)30.25
			},
			new AssetModel
			{
				Id = 73, Symbol = "RAIL3", Name = "RUMO SA", AvailableQuantity = 1216056103,
				Price = (decimal)16.09
			},
			new AssetModel
			{
				Id = 74, Symbol = "SBSP3", Name = "SABESP", AvailableQuantity = 340001934,
				Price = (decimal)43.55
			},
			new AssetModel
			{
				Id = 75, Symbol = "SANB11", Name = "SANTANDER BR", AvailableQuantity = 362703399,
				Price = (decimal)27.53
			},
			new AssetModel
			{
				Id = 76, Symbol = "CSNA3", Name = "SID NACIONAL", AvailableQuantity = 642398790,
				Price = (decimal)14.41
			},
			new AssetModel
			{
				Id = 77, Symbol = "SLCE3", Name = "SLC AGRICOLA", AvailableQuantity = 96270946,
				Price = (decimal)42.35
			},
			new AssetModel
			{
				Id = 78, Symbol = "SULA11", Name = "SUL AMERICA", AvailableQuantity = 283167854,
				Price = (decimal)22.10
			},
			new AssetModel
			{
				Id = 79, Symbol = "SUZB3", Name = "SUZANO SA", AvailableQuantity = 726779281,
				Price = (decimal)46.91
			},
			new AssetModel
			{
				Id = 80, Symbol = "TAEE11", Name = "TAESA", AvailableQuantity = 218568234,
				Price = (decimal)40.25
			},
			new AssetModel
			{
				Id = 81, Symbol = "VIVT3", Name = "TELEF BRASIL", AvailableQuantity = 413890875,
				Price = (decimal)46.83
			},
			new AssetModel
			{
				Id = 82, Symbol = "TIMS3", Name = "TIM", AvailableQuantity = 808619532,
				Price = (decimal)12.90
			},
			new AssetModel
			{
				Id = 83, Symbol = "TOTS3", Name = "TOTVS", AvailableQuantity = 519851955,
				Price = (decimal)25.89
			},
			new AssetModel
			{
				Id = 84, Symbol = "UGPA3", Name = "ULTRAPAR", AvailableQuantity = 1086067887,
				Price = (decimal)12.46
			},
			new AssetModel
			{
				Id = 85, Symbol = "USIM5", Name = "USIMINAS", AvailableQuantity = 514680651,
				Price = (decimal)8.91
			},
			new AssetModel
			{
				Id = 86, Symbol = "VALE3", Name = "VALE", AvailableQuantity = 201257220,
				Price = (decimal)69.21
			},
			new AssetModel
			{
				Id = 87, Symbol = "VIIA3", Name = "VIA", AvailableQuantity = 1596295753,
				Price = (decimal)2.51
			},
			new AssetModel
			{
				Id = 88, Symbol = "VBBR3", Name = "VIBRA", AvailableQuantity = 1131883365,
				Price = (decimal)16.54
			},
			new AssetModel
			{
				Id = 89, Symbol = "WEGE3", Name = "WEG", AvailableQuantity = 1484859030,
				Price = (decimal)25.84
			},
			new AssetModel
			{
				Id = 90, Symbol = "YDUQ3", Name = "YDUQS PART", AvailableQuantity = 300833122,
				Price = (decimal)13.90
			},
			new AssetModel
			{
				Id = 91,
				Symbol = "RRRP3", Name = "3R PETROLEUM", AvailableQuantity = 200372163,
				Price = (decimal)29.43
			}
		);
	}
}