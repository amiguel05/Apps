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
 	public abstract class  _ORIGEN : SqlClientEntity
	{
	  public _ORIGEN()
		{
		  this.QuerySource = "ORIGEN";
			this.MappingName = "ORIGEN";
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
			
			return base.LoadFromSql("[proc_ORIGENLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int ORI_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.ORI_ID, ORI_ID);

		   
		   return base.LoadFromSql("[proc_ORIGENLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter ORI_ID
   {
      get 
      {
            return new SqlParameter("@ORI_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter ORI_CODIGO
   {
      get 
      {
            return new SqlParameter("@ORI_CODIGO", SqlDbType.Char, 3);
      }
   }
   public static SqlParameter ORI_DESCRIPCION
   {
      get 
      {
            return new SqlParameter("@ORI_DESCRIPCION", SqlDbType.Char, 40);
      }
   }
   public static SqlParameter ORI_ESTADO
   {
      get 
      {
            return new SqlParameter("@ORI_ESTADO", SqlDbType.Char, 1);
      }
   }
   public static SqlParameter ORI_EMS_GROUP
   {
      get 
      {
            return new SqlParameter("@ORI_EMS_GROUP", SqlDbType.Char, 2);
      }
   }
   public static SqlParameter ORI_APP_GROUP
   {
      get 
      {
            return new SqlParameter("@ORI_APP_GROUP", SqlDbType.Char, 2);
      }
   }
   public static SqlParameter ORI_COURIER_GROUP
   {
      get 
      {
            return new SqlParameter("@ORI_COURIER_GROUP", SqlDbType.Char, 2);
      }
   }
   public static SqlParameter ORI_EQUIVALENTE
   {
      get 
      {
            return new SqlParameter("@ORI_EQUIVALENTE", SqlDbType.Char, 3);
      }
   }
   public static SqlParameter ORI_CORREO_INT
   {
      get 
      {
            return new SqlParameter("@ORI_CORREO_INT", SqlDbType.Char, 2);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  ORI_ID="ORI_ID";
public const string  ORI_CODIGO="ORI_CODIGO";
public const string  ORI_DESCRIPCION="ORI_DESCRIPCION";
public const string  ORI_ESTADO="ORI_ESTADO";
public const string  ORI_EMS_GROUP="ORI_EMS_GROUP";
public const string  ORI_APP_GROUP="ORI_APP_GROUP";
public const string  ORI_COURIER_GROUP="ORI_COURIER_GROUP";
public const string  ORI_EQUIVALENTE="ORI_EQUIVALENTE";
public const string  ORI_CORREO_INT="ORI_CORREO_INT";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[ORI_ID]=_ORIGEN.PropertyNames.ORI_ID;
ht[ORI_CODIGO]=_ORIGEN.PropertyNames.ORI_CODIGO;
ht[ORI_DESCRIPCION]=_ORIGEN.PropertyNames.ORI_DESCRIPCION;
ht[ORI_ESTADO]=_ORIGEN.PropertyNames.ORI_ESTADO;
ht[ORI_EMS_GROUP]=_ORIGEN.PropertyNames.ORI_EMS_GROUP;
ht[ORI_APP_GROUP]=_ORIGEN.PropertyNames.ORI_APP_GROUP;
ht[ORI_COURIER_GROUP]=_ORIGEN.PropertyNames.ORI_COURIER_GROUP;
ht[ORI_EQUIVALENTE]=_ORIGEN.PropertyNames.ORI_EQUIVALENTE;
ht[ORI_CORREO_INT]=_ORIGEN.PropertyNames.ORI_CORREO_INT;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string ORI_ID ="ORI_ID";
      public const string ORI_CODIGO ="ORI_CODIGO";
      public const string ORI_DESCRIPCION ="ORI_DESCRIPCION";
      public const string ORI_ESTADO ="ORI_ESTADO";
      public const string ORI_EMS_GROUP ="ORI_EMS_GROUP";
      public const string ORI_APP_GROUP ="ORI_APP_GROUP";
      public const string ORI_COURIER_GROUP ="ORI_COURIER_GROUP";
      public const string ORI_EQUIVALENTE ="ORI_EQUIVALENTE";
      public const string ORI_CORREO_INT ="ORI_CORREO_INT";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[ORI_ID]=_ORIGEN.ColumnNames.ORI_ID;
      ht[ORI_CODIGO]=_ORIGEN.ColumnNames.ORI_CODIGO;
      ht[ORI_DESCRIPCION]=_ORIGEN.ColumnNames.ORI_DESCRIPCION;
      ht[ORI_ESTADO]=_ORIGEN.ColumnNames.ORI_ESTADO;
      ht[ORI_EMS_GROUP]=_ORIGEN.ColumnNames.ORI_EMS_GROUP;
      ht[ORI_APP_GROUP]=_ORIGEN.ColumnNames.ORI_APP_GROUP;
      ht[ORI_COURIER_GROUP]=_ORIGEN.ColumnNames.ORI_COURIER_GROUP;
      ht[ORI_EQUIVALENTE]=_ORIGEN.ColumnNames.ORI_EQUIVALENTE;
      ht[ORI_CORREO_INT]=_ORIGEN.ColumnNames.ORI_CORREO_INT;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string ORI_ID = "s_ORI_ID";
      public const string ORI_CODIGO = "s_ORI_CODIGO";
      public const string ORI_DESCRIPCION = "s_ORI_DESCRIPCION";
      public const string ORI_ESTADO = "s_ORI_ESTADO";
      public const string ORI_EMS_GROUP = "s_ORI_EMS_GROUP";
      public const string ORI_APP_GROUP = "s_ORI_APP_GROUP";
      public const string ORI_COURIER_GROUP = "s_ORI_COURIER_GROUP";
      public const string ORI_EQUIVALENTE = "s_ORI_EQUIVALENTE";
      public const string ORI_CORREO_INT = "s_ORI_CORREO_INT";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int ORI_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.ORI_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.ORI_ID, value);      }  }
 public virtual string ORI_CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_CODIGO, value);      }  }
 public virtual string ORI_DESCRIPCION 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_DESCRIPCION); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_DESCRIPCION, value);      }  }
 public virtual string ORI_ESTADO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_ESTADO); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_ESTADO, value);      }  }
 public virtual string ORI_EMS_GROUP 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_EMS_GROUP); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_EMS_GROUP, value);      }  }
 public virtual string ORI_APP_GROUP 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_APP_GROUP); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_APP_GROUP, value);      }  }
 public virtual string ORI_COURIER_GROUP 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_COURIER_GROUP); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_COURIER_GROUP, value);      }  }
 public virtual string ORI_EQUIVALENTE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_EQUIVALENTE); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_EQUIVALENTE, value);      }  }
 public virtual string ORI_CORREO_INT 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ORI_CORREO_INT); 
     }
   set 
     {
       base.Setstring(ColumnNames.ORI_CORREO_INT, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_ORI_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_ID) ? string.Empty : base.GetintAsString(ColumnNames.ORI_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_ID); 
				else 
					this.ORI_ID = base.SetintAsString(ColumnNames.ORI_ID, value); 
			} 
		} 
public virtual string s_ORI_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_CODIGO); 
				else 
					this.ORI_CODIGO = base.SetstringAsString(ColumnNames.ORI_CODIGO, value); 
			} 
		} 
public virtual string s_ORI_DESCRIPCION 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_DESCRIPCION) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_DESCRIPCION); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_DESCRIPCION); 
				else 
					this.ORI_DESCRIPCION = base.SetstringAsString(ColumnNames.ORI_DESCRIPCION, value); 
			} 
		} 
public virtual string s_ORI_ESTADO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_ESTADO) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_ESTADO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_ESTADO); 
				else 
					this.ORI_ESTADO = base.SetstringAsString(ColumnNames.ORI_ESTADO, value); 
			} 
		} 
public virtual string s_ORI_EMS_GROUP 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_EMS_GROUP) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_EMS_GROUP); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_EMS_GROUP); 
				else 
					this.ORI_EMS_GROUP = base.SetstringAsString(ColumnNames.ORI_EMS_GROUP, value); 
			} 
		} 
public virtual string s_ORI_APP_GROUP 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_APP_GROUP) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_APP_GROUP); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_APP_GROUP); 
				else 
					this.ORI_APP_GROUP = base.SetstringAsString(ColumnNames.ORI_APP_GROUP, value); 
			} 
		} 
public virtual string s_ORI_COURIER_GROUP 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_COURIER_GROUP) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_COURIER_GROUP); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_COURIER_GROUP); 
				else 
					this.ORI_COURIER_GROUP = base.SetstringAsString(ColumnNames.ORI_COURIER_GROUP, value); 
			} 
		} 
public virtual string s_ORI_EQUIVALENTE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_EQUIVALENTE) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_EQUIVALENTE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_EQUIVALENTE); 
				else 
					this.ORI_EQUIVALENTE = base.SetstringAsString(ColumnNames.ORI_EQUIVALENTE, value); 
			} 
		} 
public virtual string s_ORI_CORREO_INT 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ORI_CORREO_INT) ? string.Empty : base.GetstringAsString(ColumnNames.ORI_CORREO_INT); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ORI_CORREO_INT); 
				else 
					this.ORI_CORREO_INT = base.SetstringAsString(ColumnNames.ORI_CORREO_INT, value); 
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
				 public WhereParameter ORI_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_ID, Parameters.ORI_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_CODIGO, Parameters.ORI_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_DESCRIPCION 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_DESCRIPCION, Parameters.ORI_DESCRIPCION); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_ESTADO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_ESTADO, Parameters.ORI_ESTADO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_EMS_GROUP 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_EMS_GROUP, Parameters.ORI_EMS_GROUP); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_APP_GROUP 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_APP_GROUP, Parameters.ORI_APP_GROUP); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_COURIER_GROUP 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_COURIER_GROUP, Parameters.ORI_COURIER_GROUP); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_EQUIVALENTE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_EQUIVALENTE, Parameters.ORI_EQUIVALENTE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ORI_CORREO_INT 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ORI_CORREO_INT, Parameters.ORI_CORREO_INT); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter ORI_ID 
		    {
				get
		        {
					if(_ORI_ID_W == null)
	        	    {
						_ORI_ID_W = TearOff.ORI_ID;
					}
					return _ORI_ID_W;
				}
			}
public WhereParameter ORI_CODIGO 
		    {
				get
		        {
					if(_ORI_CODIGO_W == null)
	        	    {
						_ORI_CODIGO_W = TearOff.ORI_CODIGO;
					}
					return _ORI_CODIGO_W;
				}
			}
public WhereParameter ORI_DESCRIPCION 
		    {
				get
		        {
					if(_ORI_DESCRIPCION_W == null)
	        	    {
						_ORI_DESCRIPCION_W = TearOff.ORI_DESCRIPCION;
					}
					return _ORI_DESCRIPCION_W;
				}
			}
public WhereParameter ORI_ESTADO 
		    {
				get
		        {
					if(_ORI_ESTADO_W == null)
	        	    {
						_ORI_ESTADO_W = TearOff.ORI_ESTADO;
					}
					return _ORI_ESTADO_W;
				}
			}
public WhereParameter ORI_EMS_GROUP 
		    {
				get
		        {
					if(_ORI_EMS_GROUP_W == null)
	        	    {
						_ORI_EMS_GROUP_W = TearOff.ORI_EMS_GROUP;
					}
					return _ORI_EMS_GROUP_W;
				}
			}
public WhereParameter ORI_APP_GROUP 
		    {
				get
		        {
					if(_ORI_APP_GROUP_W == null)
	        	    {
						_ORI_APP_GROUP_W = TearOff.ORI_APP_GROUP;
					}
					return _ORI_APP_GROUP_W;
				}
			}
public WhereParameter ORI_COURIER_GROUP 
		    {
				get
		        {
					if(_ORI_COURIER_GROUP_W == null)
	        	    {
						_ORI_COURIER_GROUP_W = TearOff.ORI_COURIER_GROUP;
					}
					return _ORI_COURIER_GROUP_W;
				}
			}
public WhereParameter ORI_EQUIVALENTE 
		    {
				get
		        {
					if(_ORI_EQUIVALENTE_W == null)
	        	    {
						_ORI_EQUIVALENTE_W = TearOff.ORI_EQUIVALENTE;
					}
					return _ORI_EQUIVALENTE_W;
				}
			}
public WhereParameter ORI_CORREO_INT 
		    {
				get
		        {
					if(_ORI_CORREO_INT_W == null)
	        	    {
						_ORI_CORREO_INT_W = TearOff.ORI_CORREO_INT;
					}
					return _ORI_CORREO_INT_W;
				}
			}

			
			private WhereParameter _ORI_ID_W = null;
private WhereParameter _ORI_CODIGO_W = null;
private WhereParameter _ORI_DESCRIPCION_W = null;
private WhereParameter _ORI_ESTADO_W = null;
private WhereParameter _ORI_EMS_GROUP_W = null;
private WhereParameter _ORI_APP_GROUP_W = null;
private WhereParameter _ORI_COURIER_GROUP_W = null;
private WhereParameter _ORI_EQUIVALENTE_W = null;
private WhereParameter _ORI_CORREO_INT_W = null;
	
			
			public void WhereClauseReset()
			{
			 _ORI_ID_W = null;
_ORI_CODIGO_W = null;
_ORI_DESCRIPCION_W = null;
_ORI_ESTADO_W = null;
_ORI_EMS_GROUP_W = null;
_ORI_APP_GROUP_W = null;
_ORI_COURIER_GROUP_W = null;
_ORI_EQUIVALENTE_W = null;
_ORI_CORREO_INT_W = null;
	
			 
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
				  public AggregateParameter ORI_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_ID, Parameters.ORI_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_CODIGO, Parameters.ORI_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_DESCRIPCION 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_DESCRIPCION, Parameters.ORI_DESCRIPCION);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_ESTADO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_ESTADO, Parameters.ORI_ESTADO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_EMS_GROUP 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_EMS_GROUP, Parameters.ORI_EMS_GROUP);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_APP_GROUP 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_APP_GROUP, Parameters.ORI_APP_GROUP);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_COURIER_GROUP 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_COURIER_GROUP, Parameters.ORI_COURIER_GROUP);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_EQUIVALENTE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_EQUIVALENTE, Parameters.ORI_EQUIVALENTE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ORI_CORREO_INT 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ORI_CORREO_INT, Parameters.ORI_CORREO_INT);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter ORI_ID 
		    {
				get
		        {
					if(_ORI_ID_W == null)
	        	    {
						_ORI_ID_W = TearOff.ORI_ID;
					}
					return _ORI_ID_W;
				}
			}
public AggregateParameter ORI_CODIGO 
		    {
				get
		        {
					if(_ORI_CODIGO_W == null)
	        	    {
						_ORI_CODIGO_W = TearOff.ORI_CODIGO;
					}
					return _ORI_CODIGO_W;
				}
			}
public AggregateParameter ORI_DESCRIPCION 
		    {
				get
		        {
					if(_ORI_DESCRIPCION_W == null)
	        	    {
						_ORI_DESCRIPCION_W = TearOff.ORI_DESCRIPCION;
					}
					return _ORI_DESCRIPCION_W;
				}
			}
public AggregateParameter ORI_ESTADO 
		    {
				get
		        {
					if(_ORI_ESTADO_W == null)
	        	    {
						_ORI_ESTADO_W = TearOff.ORI_ESTADO;
					}
					return _ORI_ESTADO_W;
				}
			}
public AggregateParameter ORI_EMS_GROUP 
		    {
				get
		        {
					if(_ORI_EMS_GROUP_W == null)
	        	    {
						_ORI_EMS_GROUP_W = TearOff.ORI_EMS_GROUP;
					}
					return _ORI_EMS_GROUP_W;
				}
			}
public AggregateParameter ORI_APP_GROUP 
		    {
				get
		        {
					if(_ORI_APP_GROUP_W == null)
	        	    {
						_ORI_APP_GROUP_W = TearOff.ORI_APP_GROUP;
					}
					return _ORI_APP_GROUP_W;
				}
			}
public AggregateParameter ORI_COURIER_GROUP 
		    {
				get
		        {
					if(_ORI_COURIER_GROUP_W == null)
	        	    {
						_ORI_COURIER_GROUP_W = TearOff.ORI_COURIER_GROUP;
					}
					return _ORI_COURIER_GROUP_W;
				}
			}
public AggregateParameter ORI_EQUIVALENTE 
		    {
				get
		        {
					if(_ORI_EQUIVALENTE_W == null)
	        	    {
						_ORI_EQUIVALENTE_W = TearOff.ORI_EQUIVALENTE;
					}
					return _ORI_EQUIVALENTE_W;
				}
			}
public AggregateParameter ORI_CORREO_INT 
		    {
				get
		        {
					if(_ORI_CORREO_INT_W == null)
	        	    {
						_ORI_CORREO_INT_W = TearOff.ORI_CORREO_INT;
					}
					return _ORI_CORREO_INT_W;
				}
			}

			
			private AggregateParameter _ORI_ID_W = null;
private AggregateParameter _ORI_CODIGO_W = null;
private AggregateParameter _ORI_DESCRIPCION_W = null;
private AggregateParameter _ORI_ESTADO_W = null;
private AggregateParameter _ORI_EMS_GROUP_W = null;
private AggregateParameter _ORI_APP_GROUP_W = null;
private AggregateParameter _ORI_COURIER_GROUP_W = null;
private AggregateParameter _ORI_EQUIVALENTE_W = null;
private AggregateParameter _ORI_CORREO_INT_W = null;

			
			public void AggregateClauseReset()
			{
			  _ORI_ID_W = null;
_ORI_CODIGO_W = null;
_ORI_DESCRIPCION_W = null;
_ORI_ESTADO_W = null;
_ORI_EMS_GROUP_W = null;
_ORI_APP_GROUP_W = null;
_ORI_COURIER_GROUP_W = null;
_ORI_EQUIVALENTE_W = null;
_ORI_CORREO_INT_W = null;

			  
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
			cmd.CommandText = "[proc_ORIGENInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.ORI_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_ORIGENUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_ORIGENDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.ORI_ID); 

	p.SourceColumn = ColumnNames.ORI_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.ORI_ID); 
 p.SourceColumn = ColumnNames.ORI_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_CODIGO); 
 p.SourceColumn = ColumnNames.ORI_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_DESCRIPCION); 
 p.SourceColumn = ColumnNames.ORI_DESCRIPCION; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_ESTADO); 
 p.SourceColumn = ColumnNames.ORI_ESTADO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_EMS_GROUP); 
 p.SourceColumn = ColumnNames.ORI_EMS_GROUP; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_APP_GROUP); 
 p.SourceColumn = ColumnNames.ORI_APP_GROUP; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_COURIER_GROUP); 
 p.SourceColumn = ColumnNames.ORI_COURIER_GROUP; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_EQUIVALENTE); 
 p.SourceColumn = ColumnNames.ORI_EQUIVALENTE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_CORREO_INT); 
 p.SourceColumn = ColumnNames.ORI_CORREO_INT; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			