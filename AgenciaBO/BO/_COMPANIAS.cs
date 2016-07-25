/*
'===============================================================================
'  Generated From - CSharp_dOOdads_BusinessEntity.vbgen
' 
'  The supporting base class <%= GetBaseClass %> is in the Architecture directory in "dOOdads".
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easilly done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  _YourObject
'  {
'
'  }
'  Modified by Manfredo Ferreras,  Only work with C#
'===============================================================================
*/
using System;
using System.Data;
using System.Data.SqlClient;
using Agencia2.BO;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace Agencia2.BO
{
 	public abstract class  _COMPANIAS : SqlClientEntity
	{
	  public _COMPANIAS()
		{
		  this.QuerySource = "COMPANIAS";
			this.MappingName = "COMPANIAS";
		 }
		 
		public override void AddNew()
		{
			base.AddNew();
		}
		
		public override void FlushData()
		{
			this._whereClause = null;
			this._aggregateClause = null;
			base.FlushData();
		}
		
		public bool LoadAll() 
		{
			ListDictionary parameters = null;
			
			return base.LoadFromSql("[proc_COMPANIASLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int COM_CODIGO)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.COM_CODIGO, COM_CODIGO);

		   
		   return base.LoadFromSql("[proc_COMPANIASLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter COM_CODIGO
   {
      get 
      {
            return new SqlParameter("@COM_CODIGO", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter COM_DESCRIPCION
   {
      get 
      {
            return new SqlParameter("@COM_DESCRIPCION", SqlDbType.VarChar, 40);
      }
   }
   public static SqlParameter COM_RNC
   {
      get 
      {
            return new SqlParameter("@COM_RNC", SqlDbType.VarChar, 15);
      }
   }
   public static SqlParameter COM_ANO_PROC
   {
      get 
      {
            return new SqlParameter("@COM_ANO_PROC", SqlDbType.Decimal, 0);
      }
   }
   public static SqlParameter COM_MES_PROC
   {
      get 
      {
            return new SqlParameter("@COM_MES_PROC", SqlDbType.Decimal, 0);
      }
   }
   public static SqlParameter COM_RESPONSABLE
   {
      get 
      {
            return new SqlParameter("@COM_RESPONSABLE", SqlDbType.NVarChar, 80);
      }
   }
   public static SqlParameter COM_DIRECCION
   {
      get 
      {
            return new SqlParameter("@COM_DIRECCION", SqlDbType.VarChar, 80);
      }
   }
   public static SqlParameter COM_TELEFONO
   {
      get 
      {
            return new SqlParameter("@COM_TELEFONO", SqlDbType.VarChar, 12);
      }
   }
   public static SqlParameter COM_FAX
   {
      get 
      {
            return new SqlParameter("@COM_FAX", SqlDbType.VarChar, 12);
      }
   }
   public static SqlParameter COM_EMAIL
   {
      get 
      {
            return new SqlParameter("@COM_EMAIL", SqlDbType.VarChar, 30);
      }
   }
   public static SqlParameter COM_ESTADO
   {
      get 
      {
            return new SqlParameter("@COM_ESTADO", SqlDbType.VarChar, 1);
      }
   }
   public static SqlParameter COM_FEC_CREA
   {
      get 
      {
            return new SqlParameter("@COM_FEC_CREA", SqlDbType.DateTime, 0);
      }
   }
   public static SqlParameter COMA_USR_CREA
   {
      get 
      {
            return new SqlParameter("@COMA_USR_CREA", SqlDbType.VarChar, 10);
      }
   }
   public static SqlParameter COM_DIREC_INTERNET
   {
      get 
      {
            return new SqlParameter("@COM_DIREC_INTERNET", SqlDbType.VarChar, 60);
      }
   }
   public static SqlParameter COM_RESP_TELEFONO
   {
      get 
      {
            return new SqlParameter("@COM_RESP_TELEFONO", SqlDbType.VarChar, 12);
      }
   }
   public static SqlParameter COM_RESP_TEL_EXT
   {
      get 
      {
            return new SqlParameter("@COM_RESP_TEL_EXT", SqlDbType.VarChar, 4);
      }
   }
   public static SqlParameter COM_RESP_CARGO
   {
      get 
      {
            return new SqlParameter("@COM_RESP_CARGO", SqlDbType.VarChar, 30);
      }
   }
   public static SqlParameter COM_RESP_EMAIL
   {
      get 
      {
            return new SqlParameter("@COM_RESP_EMAIL", SqlDbType.VarChar, 40);
      }
   }
   public static SqlParameter COM_DESCORTA
   {
      get 
      {
            return new SqlParameter("@COM_DESCORTA", SqlDbType.NVarChar, 40);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  COM_CODIGO="COM_CODIGO";
public const string  COM_DESCRIPCION="COM_DESCRIPCION";
public const string  COM_RNC="COM_RNC";
public const string  COM_ANO_PROC="COM_ANO_PROC";
public const string  COM_MES_PROC="COM_MES_PROC";
public const string  COM_RESPONSABLE="COM_RESPONSABLE";
public const string  COM_DIRECCION="COM_DIRECCION";
public const string  COM_TELEFONO="COM_TELEFONO";
public const string  COM_FAX="COM_FAX";
public const string  COM_EMAIL="COM_EMAIL";
public const string  COM_ESTADO="COM_ESTADO";
public const string  COM_FEC_CREA="COM_FEC_CREA";
public const string  COMA_USR_CREA="COMA_USR_CREA";
public const string  COM_DIREC_INTERNET="COM_DIREC_INTERNET";
public const string  COM_RESP_TELEFONO="COM_RESP_TELEFONO";
public const string  COM_RESP_TEL_EXT="COM_RESP_TEL_EXT";
public const string  COM_RESP_CARGO="COM_RESP_CARGO";
public const string  COM_RESP_EMAIL="COM_RESP_EMAIL";
public const string  COM_DESCORTA="COM_DESCORTA";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[COM_CODIGO]=_COMPANIAS.PropertyNames.COM_CODIGO;
ht[COM_DESCRIPCION]=_COMPANIAS.PropertyNames.COM_DESCRIPCION;
ht[COM_RNC]=_COMPANIAS.PropertyNames.COM_RNC;
ht[COM_ANO_PROC]=_COMPANIAS.PropertyNames.COM_ANO_PROC;
ht[COM_MES_PROC]=_COMPANIAS.PropertyNames.COM_MES_PROC;
ht[COM_RESPONSABLE]=_COMPANIAS.PropertyNames.COM_RESPONSABLE;
ht[COM_DIRECCION]=_COMPANIAS.PropertyNames.COM_DIRECCION;
ht[COM_TELEFONO]=_COMPANIAS.PropertyNames.COM_TELEFONO;
ht[COM_FAX]=_COMPANIAS.PropertyNames.COM_FAX;
ht[COM_EMAIL]=_COMPANIAS.PropertyNames.COM_EMAIL;
ht[COM_ESTADO]=_COMPANIAS.PropertyNames.COM_ESTADO;
ht[COM_FEC_CREA]=_COMPANIAS.PropertyNames.COM_FEC_CREA;
ht[COMA_USR_CREA]=_COMPANIAS.PropertyNames.COMA_USR_CREA;
ht[COM_DIREC_INTERNET]=_COMPANIAS.PropertyNames.COM_DIREC_INTERNET;
ht[COM_RESP_TELEFONO]=_COMPANIAS.PropertyNames.COM_RESP_TELEFONO;
ht[COM_RESP_TEL_EXT]=_COMPANIAS.PropertyNames.COM_RESP_TEL_EXT;
ht[COM_RESP_CARGO]=_COMPANIAS.PropertyNames.COM_RESP_CARGO;
ht[COM_RESP_EMAIL]=_COMPANIAS.PropertyNames.COM_RESP_EMAIL;
ht[COM_DESCORTA]=_COMPANIAS.PropertyNames.COM_DESCORTA;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string COM_CODIGO ="COM_CODIGO";
      public const string COM_DESCRIPCION ="COM_DESCRIPCION";
      public const string COM_RNC ="COM_RNC";
      public const string COM_ANO_PROC ="COM_ANO_PROC";
      public const string COM_MES_PROC ="COM_MES_PROC";
      public const string COM_RESPONSABLE ="COM_RESPONSABLE";
      public const string COM_DIRECCION ="COM_DIRECCION";
      public const string COM_TELEFONO ="COM_TELEFONO";
      public const string COM_FAX ="COM_FAX";
      public const string COM_EMAIL ="COM_EMAIL";
      public const string COM_ESTADO ="COM_ESTADO";
      public const string COM_FEC_CREA ="COM_FEC_CREA";
      public const string COMA_USR_CREA ="COMA_USR_CREA";
      public const string COM_DIREC_INTERNET ="COM_DIREC_INTERNET";
      public const string COM_RESP_TELEFONO ="COM_RESP_TELEFONO";
      public const string COM_RESP_TEL_EXT ="COM_RESP_TEL_EXT";
      public const string COM_RESP_CARGO ="COM_RESP_CARGO";
      public const string COM_RESP_EMAIL ="COM_RESP_EMAIL";
      public const string COM_DESCORTA ="COM_DESCORTA";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[COM_CODIGO]=_COMPANIAS.ColumnNames.COM_CODIGO;
      ht[COM_DESCRIPCION]=_COMPANIAS.ColumnNames.COM_DESCRIPCION;
      ht[COM_RNC]=_COMPANIAS.ColumnNames.COM_RNC;
      ht[COM_ANO_PROC]=_COMPANIAS.ColumnNames.COM_ANO_PROC;
      ht[COM_MES_PROC]=_COMPANIAS.ColumnNames.COM_MES_PROC;
      ht[COM_RESPONSABLE]=_COMPANIAS.ColumnNames.COM_RESPONSABLE;
      ht[COM_DIRECCION]=_COMPANIAS.ColumnNames.COM_DIRECCION;
      ht[COM_TELEFONO]=_COMPANIAS.ColumnNames.COM_TELEFONO;
      ht[COM_FAX]=_COMPANIAS.ColumnNames.COM_FAX;
      ht[COM_EMAIL]=_COMPANIAS.ColumnNames.COM_EMAIL;
      ht[COM_ESTADO]=_COMPANIAS.ColumnNames.COM_ESTADO;
      ht[COM_FEC_CREA]=_COMPANIAS.ColumnNames.COM_FEC_CREA;
      ht[COMA_USR_CREA]=_COMPANIAS.ColumnNames.COMA_USR_CREA;
      ht[COM_DIREC_INTERNET]=_COMPANIAS.ColumnNames.COM_DIREC_INTERNET;
      ht[COM_RESP_TELEFONO]=_COMPANIAS.ColumnNames.COM_RESP_TELEFONO;
      ht[COM_RESP_TEL_EXT]=_COMPANIAS.ColumnNames.COM_RESP_TEL_EXT;
      ht[COM_RESP_CARGO]=_COMPANIAS.ColumnNames.COM_RESP_CARGO;
      ht[COM_RESP_EMAIL]=_COMPANIAS.ColumnNames.COM_RESP_EMAIL;
      ht[COM_DESCORTA]=_COMPANIAS.ColumnNames.COM_DESCORTA;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string COM_CODIGO = "s_COM_CODIGO";
      public const string COM_DESCRIPCION = "s_COM_DESCRIPCION";
      public const string COM_RNC = "s_COM_RNC";
      public const string COM_ANO_PROC = "s_COM_ANO_PROC";
      public const string COM_MES_PROC = "s_COM_MES_PROC";
      public const string COM_RESPONSABLE = "s_COM_RESPONSABLE";
      public const string COM_DIRECCION = "s_COM_DIRECCION";
      public const string COM_TELEFONO = "s_COM_TELEFONO";
      public const string COM_FAX = "s_COM_FAX";
      public const string COM_EMAIL = "s_COM_EMAIL";
      public const string COM_ESTADO = "s_COM_ESTADO";
      public const string COM_FEC_CREA = "s_COM_FEC_CREA";
      public const string COMA_USR_CREA = "s_COMA_USR_CREA";
      public const string COM_DIREC_INTERNET = "s_COM_DIREC_INTERNET";
      public const string COM_RESP_TELEFONO = "s_COM_RESP_TELEFONO";
      public const string COM_RESP_TEL_EXT = "s_COM_RESP_TEL_EXT";
      public const string COM_RESP_CARGO = "s_COM_RESP_CARGO";
      public const string COM_RESP_EMAIL = "s_COM_RESP_EMAIL";
      public const string COM_DESCORTA = "s_COM_DESCORTA";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int COM_CODIGO 
 {
   get 
     { 
       return base.Getint(ColumnNames.COM_CODIGO); 
     }
   set 
     {
       base.Setint(ColumnNames.COM_CODIGO, value);      }  }
 public virtual string COM_DESCRIPCION 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_DESCRIPCION); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_DESCRIPCION, value);      }  }
 public virtual string COM_RNC 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RNC); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RNC, value);      }  }
 public virtual decimal COM_ANO_PROC 
 {
   get 
     { 
       return base.Getdecimal(ColumnNames.COM_ANO_PROC); 
     }
   set 
     {
       base.Setdecimal(ColumnNames.COM_ANO_PROC, value);      }  }
 public virtual decimal COM_MES_PROC 
 {
   get 
     { 
       return base.Getdecimal(ColumnNames.COM_MES_PROC); 
     }
   set 
     {
       base.Setdecimal(ColumnNames.COM_MES_PROC, value);      }  }
 public virtual string COM_RESPONSABLE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RESPONSABLE); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RESPONSABLE, value);      }  }
 public virtual string COM_DIRECCION 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_DIRECCION); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_DIRECCION, value);      }  }
 public virtual string COM_TELEFONO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_TELEFONO); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_TELEFONO, value);      }  }
 public virtual string COM_FAX 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_FAX); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_FAX, value);      }  }
 public virtual string COM_EMAIL 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_EMAIL); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_EMAIL, value);      }  }
 public virtual string COM_ESTADO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_ESTADO); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_ESTADO, value);      }  }
 public virtual DateTime COM_FEC_CREA 
 {
   get 
     { 
       return base.GetDateTime(ColumnNames.COM_FEC_CREA); 
     }
   set 
     {
       base.SetDateTime(ColumnNames.COM_FEC_CREA, value);      }  }
 public virtual string COMA_USR_CREA 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COMA_USR_CREA); 
     }
   set 
     {
       base.Setstring(ColumnNames.COMA_USR_CREA, value);      }  }
 public virtual string COM_DIREC_INTERNET 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_DIREC_INTERNET); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_DIREC_INTERNET, value);      }  }
 public virtual string COM_RESP_TELEFONO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RESP_TELEFONO); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RESP_TELEFONO, value);      }  }
 public virtual string COM_RESP_TEL_EXT 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RESP_TEL_EXT); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RESP_TEL_EXT, value);      }  }
 public virtual string COM_RESP_CARGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RESP_CARGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RESP_CARGO, value);      }  }
 public virtual string COM_RESP_EMAIL 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_RESP_EMAIL); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_RESP_EMAIL, value);      }  }
 public virtual string COM_DESCORTA 
 {
   get 
     { 
       return base.Getstring(ColumnNames.COM_DESCORTA); 
     }
   set 
     {
       base.Setstring(ColumnNames.COM_DESCORTA, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_COM_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_CODIGO) ? string.Empty : base.GetintAsString(ColumnNames.COM_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_CODIGO); 
				else 
					this.COM_CODIGO = base.SetintAsString(ColumnNames.COM_CODIGO, value); 
			} 
		} 
public virtual string s_COM_DESCRIPCION 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_DESCRIPCION) ? string.Empty : base.GetstringAsString(ColumnNames.COM_DESCRIPCION); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_DESCRIPCION); 
				else 
					this.COM_DESCRIPCION = base.SetstringAsString(ColumnNames.COM_DESCRIPCION, value); 
			} 
		} 
public virtual string s_COM_RNC 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RNC) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RNC); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RNC); 
				else 
					this.COM_RNC = base.SetstringAsString(ColumnNames.COM_RNC, value); 
			} 
		} 
public virtual string s_COM_ANO_PROC 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_ANO_PROC) ? string.Empty : base.GetdecimalAsString(ColumnNames.COM_ANO_PROC); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_ANO_PROC); 
				else 
					this.COM_ANO_PROC = base.SetdecimalAsString(ColumnNames.COM_ANO_PROC, value); 
			} 
		} 
public virtual string s_COM_MES_PROC 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_MES_PROC) ? string.Empty : base.GetdecimalAsString(ColumnNames.COM_MES_PROC); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_MES_PROC); 
				else 
					this.COM_MES_PROC = base.SetdecimalAsString(ColumnNames.COM_MES_PROC, value); 
			} 
		} 
public virtual string s_COM_RESPONSABLE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RESPONSABLE) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RESPONSABLE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RESPONSABLE); 
				else 
					this.COM_RESPONSABLE = base.SetstringAsString(ColumnNames.COM_RESPONSABLE, value); 
			} 
		} 
public virtual string s_COM_DIRECCION 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_DIRECCION) ? string.Empty : base.GetstringAsString(ColumnNames.COM_DIRECCION); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_DIRECCION); 
				else 
					this.COM_DIRECCION = base.SetstringAsString(ColumnNames.COM_DIRECCION, value); 
			} 
		} 
public virtual string s_COM_TELEFONO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_TELEFONO) ? string.Empty : base.GetstringAsString(ColumnNames.COM_TELEFONO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_TELEFONO); 
				else 
					this.COM_TELEFONO = base.SetstringAsString(ColumnNames.COM_TELEFONO, value); 
			} 
		} 
public virtual string s_COM_FAX 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_FAX) ? string.Empty : base.GetstringAsString(ColumnNames.COM_FAX); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_FAX); 
				else 
					this.COM_FAX = base.SetstringAsString(ColumnNames.COM_FAX, value); 
			} 
		} 
public virtual string s_COM_EMAIL 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_EMAIL) ? string.Empty : base.GetstringAsString(ColumnNames.COM_EMAIL); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_EMAIL); 
				else 
					this.COM_EMAIL = base.SetstringAsString(ColumnNames.COM_EMAIL, value); 
			} 
		} 
public virtual string s_COM_ESTADO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_ESTADO) ? string.Empty : base.GetstringAsString(ColumnNames.COM_ESTADO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_ESTADO); 
				else 
					this.COM_ESTADO = base.SetstringAsString(ColumnNames.COM_ESTADO, value); 
			} 
		} 
public virtual string s_COM_FEC_CREA 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_FEC_CREA) ? string.Empty : base.GetDateTimeAsString(ColumnNames.COM_FEC_CREA); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_FEC_CREA); 
				else 
					this.COM_FEC_CREA = base.SetDateTimeAsString(ColumnNames.COM_FEC_CREA, value); 
			} 
		} 
public virtual string s_COMA_USR_CREA 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COMA_USR_CREA) ? string.Empty : base.GetstringAsString(ColumnNames.COMA_USR_CREA); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COMA_USR_CREA); 
				else 
					this.COMA_USR_CREA = base.SetstringAsString(ColumnNames.COMA_USR_CREA, value); 
			} 
		} 
public virtual string s_COM_DIREC_INTERNET 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_DIREC_INTERNET) ? string.Empty : base.GetstringAsString(ColumnNames.COM_DIREC_INTERNET); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_DIREC_INTERNET); 
				else 
					this.COM_DIREC_INTERNET = base.SetstringAsString(ColumnNames.COM_DIREC_INTERNET, value); 
			} 
		} 
public virtual string s_COM_RESP_TELEFONO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RESP_TELEFONO) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RESP_TELEFONO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RESP_TELEFONO); 
				else 
					this.COM_RESP_TELEFONO = base.SetstringAsString(ColumnNames.COM_RESP_TELEFONO, value); 
			} 
		} 
public virtual string s_COM_RESP_TEL_EXT 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RESP_TEL_EXT) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RESP_TEL_EXT); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RESP_TEL_EXT); 
				else 
					this.COM_RESP_TEL_EXT = base.SetstringAsString(ColumnNames.COM_RESP_TEL_EXT, value); 
			} 
		} 
public virtual string s_COM_RESP_CARGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RESP_CARGO) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RESP_CARGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RESP_CARGO); 
				else 
					this.COM_RESP_CARGO = base.SetstringAsString(ColumnNames.COM_RESP_CARGO, value); 
			} 
		} 
public virtual string s_COM_RESP_EMAIL 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_RESP_EMAIL) ? string.Empty : base.GetstringAsString(ColumnNames.COM_RESP_EMAIL); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_RESP_EMAIL); 
				else 
					this.COM_RESP_EMAIL = base.SetstringAsString(ColumnNames.COM_RESP_EMAIL, value); 
			} 
		} 
public virtual string s_COM_DESCORTA 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.COM_DESCORTA) ? string.Empty : base.GetstringAsString(ColumnNames.COM_DESCORTA); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.COM_DESCORTA); 
				else 
					this.COM_DESCORTA = base.SetstringAsString(ColumnNames.COM_DESCORTA, value); 
			} 
		} 

		#endregion		
		
	  #region Where Clause
	  public class WhereClause
		{
			public WhereClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffWhereParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffWhereParameter(this);
					}

					return _tearOff;
				}
			}

			#region WhereParameter TearOff's
			public class TearOffWhereParameter
			{
				public TearOffWhereParameter(WhereClause clause)
				{
					this._clause = clause;
				}
				 public WhereParameter COM_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_CODIGO, Parameters.COM_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_DESCRIPCION 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_DESCRIPCION, Parameters.COM_DESCRIPCION); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RNC 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RNC, Parameters.COM_RNC); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_ANO_PROC 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_ANO_PROC, Parameters.COM_ANO_PROC); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_MES_PROC 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_MES_PROC, Parameters.COM_MES_PROC); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RESPONSABLE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RESPONSABLE, Parameters.COM_RESPONSABLE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_DIRECCION 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_DIRECCION, Parameters.COM_DIRECCION); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_TELEFONO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_TELEFONO, Parameters.COM_TELEFONO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_FAX 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_FAX, Parameters.COM_FAX); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_EMAIL 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_EMAIL, Parameters.COM_EMAIL); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_ESTADO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_ESTADO, Parameters.COM_ESTADO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_FEC_CREA 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_FEC_CREA, Parameters.COM_FEC_CREA); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COMA_USR_CREA 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COMA_USR_CREA, Parameters.COMA_USR_CREA); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_DIREC_INTERNET 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_DIREC_INTERNET, Parameters.COM_DIREC_INTERNET); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RESP_TELEFONO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RESP_TELEFONO, Parameters.COM_RESP_TELEFONO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RESP_TEL_EXT 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RESP_TEL_EXT, Parameters.COM_RESP_TEL_EXT); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RESP_CARGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RESP_CARGO, Parameters.COM_RESP_CARGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_RESP_EMAIL 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_RESP_EMAIL, Parameters.COM_RESP_EMAIL); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter COM_DESCORTA 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.COM_DESCORTA, Parameters.COM_DESCORTA); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter COM_CODIGO 
		    {
				get
		        {
					if(_COM_CODIGO_W == null)
	        	    {
						_COM_CODIGO_W = TearOff.COM_CODIGO;
					}
					return _COM_CODIGO_W;
				}
			}
public WhereParameter COM_DESCRIPCION 
		    {
				get
		        {
					if(_COM_DESCRIPCION_W == null)
	        	    {
						_COM_DESCRIPCION_W = TearOff.COM_DESCRIPCION;
					}
					return _COM_DESCRIPCION_W;
				}
			}
public WhereParameter COM_RNC 
		    {
				get
		        {
					if(_COM_RNC_W == null)
	        	    {
						_COM_RNC_W = TearOff.COM_RNC;
					}
					return _COM_RNC_W;
				}
			}
public WhereParameter COM_ANO_PROC 
		    {
				get
		        {
					if(_COM_ANO_PROC_W == null)
	        	    {
						_COM_ANO_PROC_W = TearOff.COM_ANO_PROC;
					}
					return _COM_ANO_PROC_W;
				}
			}
public WhereParameter COM_MES_PROC 
		    {
				get
		        {
					if(_COM_MES_PROC_W == null)
	        	    {
						_COM_MES_PROC_W = TearOff.COM_MES_PROC;
					}
					return _COM_MES_PROC_W;
				}
			}
public WhereParameter COM_RESPONSABLE 
		    {
				get
		        {
					if(_COM_RESPONSABLE_W == null)
	        	    {
						_COM_RESPONSABLE_W = TearOff.COM_RESPONSABLE;
					}
					return _COM_RESPONSABLE_W;
				}
			}
public WhereParameter COM_DIRECCION 
		    {
				get
		        {
					if(_COM_DIRECCION_W == null)
	        	    {
						_COM_DIRECCION_W = TearOff.COM_DIRECCION;
					}
					return _COM_DIRECCION_W;
				}
			}
public WhereParameter COM_TELEFONO 
		    {
				get
		        {
					if(_COM_TELEFONO_W == null)
	        	    {
						_COM_TELEFONO_W = TearOff.COM_TELEFONO;
					}
					return _COM_TELEFONO_W;
				}
			}
public WhereParameter COM_FAX 
		    {
				get
		        {
					if(_COM_FAX_W == null)
	        	    {
						_COM_FAX_W = TearOff.COM_FAX;
					}
					return _COM_FAX_W;
				}
			}
public WhereParameter COM_EMAIL 
		    {
				get
		        {
					if(_COM_EMAIL_W == null)
	        	    {
						_COM_EMAIL_W = TearOff.COM_EMAIL;
					}
					return _COM_EMAIL_W;
				}
			}
public WhereParameter COM_ESTADO 
		    {
				get
		        {
					if(_COM_ESTADO_W == null)
	        	    {
						_COM_ESTADO_W = TearOff.COM_ESTADO;
					}
					return _COM_ESTADO_W;
				}
			}
public WhereParameter COM_FEC_CREA 
		    {
				get
		        {
					if(_COM_FEC_CREA_W == null)
	        	    {
						_COM_FEC_CREA_W = TearOff.COM_FEC_CREA;
					}
					return _COM_FEC_CREA_W;
				}
			}
public WhereParameter COMA_USR_CREA 
		    {
				get
		        {
					if(_COMA_USR_CREA_W == null)
	        	    {
						_COMA_USR_CREA_W = TearOff.COMA_USR_CREA;
					}
					return _COMA_USR_CREA_W;
				}
			}
public WhereParameter COM_DIREC_INTERNET 
		    {
				get
		        {
					if(_COM_DIREC_INTERNET_W == null)
	        	    {
						_COM_DIREC_INTERNET_W = TearOff.COM_DIREC_INTERNET;
					}
					return _COM_DIREC_INTERNET_W;
				}
			}
public WhereParameter COM_RESP_TELEFONO 
		    {
				get
		        {
					if(_COM_RESP_TELEFONO_W == null)
	        	    {
						_COM_RESP_TELEFONO_W = TearOff.COM_RESP_TELEFONO;
					}
					return _COM_RESP_TELEFONO_W;
				}
			}
public WhereParameter COM_RESP_TEL_EXT 
		    {
				get
		        {
					if(_COM_RESP_TEL_EXT_W == null)
	        	    {
						_COM_RESP_TEL_EXT_W = TearOff.COM_RESP_TEL_EXT;
					}
					return _COM_RESP_TEL_EXT_W;
				}
			}
public WhereParameter COM_RESP_CARGO 
		    {
				get
		        {
					if(_COM_RESP_CARGO_W == null)
	        	    {
						_COM_RESP_CARGO_W = TearOff.COM_RESP_CARGO;
					}
					return _COM_RESP_CARGO_W;
				}
			}
public WhereParameter COM_RESP_EMAIL 
		    {
				get
		        {
					if(_COM_RESP_EMAIL_W == null)
	        	    {
						_COM_RESP_EMAIL_W = TearOff.COM_RESP_EMAIL;
					}
					return _COM_RESP_EMAIL_W;
				}
			}
public WhereParameter COM_DESCORTA 
		    {
				get
		        {
					if(_COM_DESCORTA_W == null)
	        	    {
						_COM_DESCORTA_W = TearOff.COM_DESCORTA;
					}
					return _COM_DESCORTA_W;
				}
			}

			
			private WhereParameter _COM_CODIGO_W = null;
private WhereParameter _COM_DESCRIPCION_W = null;
private WhereParameter _COM_RNC_W = null;
private WhereParameter _COM_ANO_PROC_W = null;
private WhereParameter _COM_MES_PROC_W = null;
private WhereParameter _COM_RESPONSABLE_W = null;
private WhereParameter _COM_DIRECCION_W = null;
private WhereParameter _COM_TELEFONO_W = null;
private WhereParameter _COM_FAX_W = null;
private WhereParameter _COM_EMAIL_W = null;
private WhereParameter _COM_ESTADO_W = null;
private WhereParameter _COM_FEC_CREA_W = null;
private WhereParameter _COMA_USR_CREA_W = null;
private WhereParameter _COM_DIREC_INTERNET_W = null;
private WhereParameter _COM_RESP_TELEFONO_W = null;
private WhereParameter _COM_RESP_TEL_EXT_W = null;
private WhereParameter _COM_RESP_CARGO_W = null;
private WhereParameter _COM_RESP_EMAIL_W = null;
private WhereParameter _COM_DESCORTA_W = null;
	
			
			public void WhereClauseReset()
			{
			 _COM_CODIGO_W = null;
_COM_DESCRIPCION_W = null;
_COM_RNC_W = null;
_COM_ANO_PROC_W = null;
_COM_MES_PROC_W = null;
_COM_RESPONSABLE_W = null;
_COM_DIRECCION_W = null;
_COM_TELEFONO_W = null;
_COM_FAX_W = null;
_COM_EMAIL_W = null;
_COM_ESTADO_W = null;
_COM_FEC_CREA_W = null;
_COMA_USR_CREA_W = null;
_COM_DIREC_INTERNET_W = null;
_COM_RESP_TELEFONO_W = null;
_COM_RESP_TEL_EXT_W = null;
_COM_RESP_CARGO_W = null;
_COM_RESP_EMAIL_W = null;
_COM_DESCORTA_W = null;
	
			 
			 this._entity.Query.FlushWhereParameters();
			}
			
			private BusinessEntity _entity;
			private TearOffWhereParameter _tearOff;
			
		}
		
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
				{
					_whereClause = new WhereClause(this);
				}
		
				return _whereClause;
			}
		}
		
		private WhereClause _whereClause = null;	
		#endregion
		
		#region Aggregate Clause
		public class AggregateClause
		{
			public AggregateClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffAggregateParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffAggregateParameter(this);
					}

					return _tearOff;
				}
			}

			#region AggregateParameter TearOff's
			public class TearOffAggregateParameter
			{
				public TearOffAggregateParameter(AggregateClause clause)
				{
					this._clause = clause;
				}
				  public AggregateParameter COM_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_CODIGO, Parameters.COM_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_DESCRIPCION 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_DESCRIPCION, Parameters.COM_DESCRIPCION);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RNC 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RNC, Parameters.COM_RNC);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_ANO_PROC 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_ANO_PROC, Parameters.COM_ANO_PROC);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_MES_PROC 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_MES_PROC, Parameters.COM_MES_PROC);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RESPONSABLE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RESPONSABLE, Parameters.COM_RESPONSABLE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_DIRECCION 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_DIRECCION, Parameters.COM_DIRECCION);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_TELEFONO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_TELEFONO, Parameters.COM_TELEFONO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_FAX 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_FAX, Parameters.COM_FAX);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_EMAIL 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_EMAIL, Parameters.COM_EMAIL);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_ESTADO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_ESTADO, Parameters.COM_ESTADO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_FEC_CREA 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_FEC_CREA, Parameters.COM_FEC_CREA);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COMA_USR_CREA 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COMA_USR_CREA, Parameters.COMA_USR_CREA);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_DIREC_INTERNET 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_DIREC_INTERNET, Parameters.COM_DIREC_INTERNET);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RESP_TELEFONO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RESP_TELEFONO, Parameters.COM_RESP_TELEFONO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RESP_TEL_EXT 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RESP_TEL_EXT, Parameters.COM_RESP_TEL_EXT);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RESP_CARGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RESP_CARGO, Parameters.COM_RESP_CARGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_RESP_EMAIL 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_RESP_EMAIL, Parameters.COM_RESP_EMAIL);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter COM_DESCORTA 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.COM_DESCORTA, Parameters.COM_DESCORTA);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter COM_CODIGO 
		    {
				get
		        {
					if(_COM_CODIGO_W == null)
	        	    {
						_COM_CODIGO_W = TearOff.COM_CODIGO;
					}
					return _COM_CODIGO_W;
				}
			}
public AggregateParameter COM_DESCRIPCION 
		    {
				get
		        {
					if(_COM_DESCRIPCION_W == null)
	        	    {
						_COM_DESCRIPCION_W = TearOff.COM_DESCRIPCION;
					}
					return _COM_DESCRIPCION_W;
				}
			}
public AggregateParameter COM_RNC 
		    {
				get
		        {
					if(_COM_RNC_W == null)
	        	    {
						_COM_RNC_W = TearOff.COM_RNC;
					}
					return _COM_RNC_W;
				}
			}
public AggregateParameter COM_ANO_PROC 
		    {
				get
		        {
					if(_COM_ANO_PROC_W == null)
	        	    {
						_COM_ANO_PROC_W = TearOff.COM_ANO_PROC;
					}
					return _COM_ANO_PROC_W;
				}
			}
public AggregateParameter COM_MES_PROC 
		    {
				get
		        {
					if(_COM_MES_PROC_W == null)
	        	    {
						_COM_MES_PROC_W = TearOff.COM_MES_PROC;
					}
					return _COM_MES_PROC_W;
				}
			}
public AggregateParameter COM_RESPONSABLE 
		    {
				get
		        {
					if(_COM_RESPONSABLE_W == null)
	        	    {
						_COM_RESPONSABLE_W = TearOff.COM_RESPONSABLE;
					}
					return _COM_RESPONSABLE_W;
				}
			}
public AggregateParameter COM_DIRECCION 
		    {
				get
		        {
					if(_COM_DIRECCION_W == null)
	        	    {
						_COM_DIRECCION_W = TearOff.COM_DIRECCION;
					}
					return _COM_DIRECCION_W;
				}
			}
public AggregateParameter COM_TELEFONO 
		    {
				get
		        {
					if(_COM_TELEFONO_W == null)
	        	    {
						_COM_TELEFONO_W = TearOff.COM_TELEFONO;
					}
					return _COM_TELEFONO_W;
				}
			}
public AggregateParameter COM_FAX 
		    {
				get
		        {
					if(_COM_FAX_W == null)
	        	    {
						_COM_FAX_W = TearOff.COM_FAX;
					}
					return _COM_FAX_W;
				}
			}
public AggregateParameter COM_EMAIL 
		    {
				get
		        {
					if(_COM_EMAIL_W == null)
	        	    {
						_COM_EMAIL_W = TearOff.COM_EMAIL;
					}
					return _COM_EMAIL_W;
				}
			}
public AggregateParameter COM_ESTADO 
		    {
				get
		        {
					if(_COM_ESTADO_W == null)
	        	    {
						_COM_ESTADO_W = TearOff.COM_ESTADO;
					}
					return _COM_ESTADO_W;
				}
			}
public AggregateParameter COM_FEC_CREA 
		    {
				get
		        {
					if(_COM_FEC_CREA_W == null)
	        	    {
						_COM_FEC_CREA_W = TearOff.COM_FEC_CREA;
					}
					return _COM_FEC_CREA_W;
				}
			}
public AggregateParameter COMA_USR_CREA 
		    {
				get
		        {
					if(_COMA_USR_CREA_W == null)
	        	    {
						_COMA_USR_CREA_W = TearOff.COMA_USR_CREA;
					}
					return _COMA_USR_CREA_W;
				}
			}
public AggregateParameter COM_DIREC_INTERNET 
		    {
				get
		        {
					if(_COM_DIREC_INTERNET_W == null)
	        	    {
						_COM_DIREC_INTERNET_W = TearOff.COM_DIREC_INTERNET;
					}
					return _COM_DIREC_INTERNET_W;
				}
			}
public AggregateParameter COM_RESP_TELEFONO 
		    {
				get
		        {
					if(_COM_RESP_TELEFONO_W == null)
	        	    {
						_COM_RESP_TELEFONO_W = TearOff.COM_RESP_TELEFONO;
					}
					return _COM_RESP_TELEFONO_W;
				}
			}
public AggregateParameter COM_RESP_TEL_EXT 
		    {
				get
		        {
					if(_COM_RESP_TEL_EXT_W == null)
	        	    {
						_COM_RESP_TEL_EXT_W = TearOff.COM_RESP_TEL_EXT;
					}
					return _COM_RESP_TEL_EXT_W;
				}
			}
public AggregateParameter COM_RESP_CARGO 
		    {
				get
		        {
					if(_COM_RESP_CARGO_W == null)
	        	    {
						_COM_RESP_CARGO_W = TearOff.COM_RESP_CARGO;
					}
					return _COM_RESP_CARGO_W;
				}
			}
public AggregateParameter COM_RESP_EMAIL 
		    {
				get
		        {
					if(_COM_RESP_EMAIL_W == null)
	        	    {
						_COM_RESP_EMAIL_W = TearOff.COM_RESP_EMAIL;
					}
					return _COM_RESP_EMAIL_W;
				}
			}
public AggregateParameter COM_DESCORTA 
		    {
				get
		        {
					if(_COM_DESCORTA_W == null)
	        	    {
						_COM_DESCORTA_W = TearOff.COM_DESCORTA;
					}
					return _COM_DESCORTA_W;
				}
			}

			
			private AggregateParameter _COM_CODIGO_W = null;
private AggregateParameter _COM_DESCRIPCION_W = null;
private AggregateParameter _COM_RNC_W = null;
private AggregateParameter _COM_ANO_PROC_W = null;
private AggregateParameter _COM_MES_PROC_W = null;
private AggregateParameter _COM_RESPONSABLE_W = null;
private AggregateParameter _COM_DIRECCION_W = null;
private AggregateParameter _COM_TELEFONO_W = null;
private AggregateParameter _COM_FAX_W = null;
private AggregateParameter _COM_EMAIL_W = null;
private AggregateParameter _COM_ESTADO_W = null;
private AggregateParameter _COM_FEC_CREA_W = null;
private AggregateParameter _COMA_USR_CREA_W = null;
private AggregateParameter _COM_DIREC_INTERNET_W = null;
private AggregateParameter _COM_RESP_TELEFONO_W = null;
private AggregateParameter _COM_RESP_TEL_EXT_W = null;
private AggregateParameter _COM_RESP_CARGO_W = null;
private AggregateParameter _COM_RESP_EMAIL_W = null;
private AggregateParameter _COM_DESCORTA_W = null;

			
			public void AggregateClauseReset()
			{
			  _COM_CODIGO_W = null;
_COM_DESCRIPCION_W = null;
_COM_RNC_W = null;
_COM_ANO_PROC_W = null;
_COM_MES_PROC_W = null;
_COM_RESPONSABLE_W = null;
_COM_DIRECCION_W = null;
_COM_TELEFONO_W = null;
_COM_FAX_W = null;
_COM_EMAIL_W = null;
_COM_ESTADO_W = null;
_COM_FEC_CREA_W = null;
_COMA_USR_CREA_W = null;
_COM_DIREC_INTERNET_W = null;
_COM_RESP_TELEFONO_W = null;
_COM_RESP_TEL_EXT_W = null;
_COM_RESP_CARGO_W = null;
_COM_RESP_EMAIL_W = null;
_COM_DESCORTA_W = null;

			  
			  this._entity.Query.FlushAggregateParameters();
			}
			
			private BusinessEntity _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
		
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
				{
					_aggregateClause = new AggregateClause(this);
				}
		
				return _aggregateClause;
			}
		}
		
		private AggregateClause _aggregateClause = null;	
		#endregion
		
		protected override IDbCommand GetInsertCommand() 
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_COMPANIASInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.COM_CODIGO.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_COMPANIASUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_COMPANIASDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.COM_CODIGO); 

	p.SourceColumn = ColumnNames.COM_CODIGO;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.COM_CODIGO); 
 p.SourceColumn = ColumnNames.COM_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_DESCRIPCION); 
 p.SourceColumn = ColumnNames.COM_DESCRIPCION; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RNC); 
 p.SourceColumn = ColumnNames.COM_RNC; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_ANO_PROC); 
 p.SourceColumn = ColumnNames.COM_ANO_PROC; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_MES_PROC); 
 p.SourceColumn = ColumnNames.COM_MES_PROC; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RESPONSABLE); 
 p.SourceColumn = ColumnNames.COM_RESPONSABLE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_DIRECCION); 
 p.SourceColumn = ColumnNames.COM_DIRECCION; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_TELEFONO); 
 p.SourceColumn = ColumnNames.COM_TELEFONO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_FAX); 
 p.SourceColumn = ColumnNames.COM_FAX; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_EMAIL); 
 p.SourceColumn = ColumnNames.COM_EMAIL; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_ESTADO); 
 p.SourceColumn = ColumnNames.COM_ESTADO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_FEC_CREA); 
 p.SourceColumn = ColumnNames.COM_FEC_CREA; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COMA_USR_CREA); 
 p.SourceColumn = ColumnNames.COMA_USR_CREA; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_DIREC_INTERNET); 
 p.SourceColumn = ColumnNames.COM_DIREC_INTERNET; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RESP_TELEFONO); 
 p.SourceColumn = ColumnNames.COM_RESP_TELEFONO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RESP_TEL_EXT); 
 p.SourceColumn = ColumnNames.COM_RESP_TEL_EXT; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RESP_CARGO); 
 p.SourceColumn = ColumnNames.COM_RESP_CARGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_RESP_EMAIL); 
 p.SourceColumn = ColumnNames.COM_RESP_EMAIL; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_DESCORTA); 
 p.SourceColumn = ColumnNames.COM_DESCORTA; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			