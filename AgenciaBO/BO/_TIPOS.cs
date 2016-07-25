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
 	public abstract class  _TIPOS : SqlClientEntity
	{
	  public _TIPOS()
		{
		  this.QuerySource = "TIPOS";
			this.MappingName = "TIPOS";
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
			
			return base.LoadFromSql("[proc_TIPOSLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int TIPO_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.TIPO_ID, TIPO_ID);

		   
		   return base.LoadFromSql("[proc_TIPOSLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter TIPO_ID
   {
      get 
      {
            return new SqlParameter("@TIPO_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter TIPO_NOMBRE
   {
      get 
      {
            return new SqlParameter("@TIPO_NOMBRE", SqlDbType.VarChar, 60);
      }
   }
   public static SqlParameter TIPO_DESCR
   {
      get 
      {
            return new SqlParameter("@TIPO_DESCR", SqlDbType.VarChar, 200);
      }
   }
   public static SqlParameter TIPO_CODIGO
   {
      get 
      {
            return new SqlParameter("@TIPO_CODIGO", SqlDbType.VarChar, 10);
      }
   }
   public static SqlParameter GRUPO_TIPO_ID
   {
      get 
      {
            return new SqlParameter("@GRUPO_TIPO_ID", SqlDbType.Int, 0);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  TIPO_ID="TIPO_ID";
public const string  TIPO_NOMBRE="TIPO_NOMBRE";
public const string  TIPO_DESCR="TIPO_DESCR";
public const string  TIPO_CODIGO="TIPO_CODIGO";
public const string  GRUPO_TIPO_ID="GRUPO_TIPO_ID";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[TIPO_ID]=_TIPOS.PropertyNames.TIPO_ID;
ht[TIPO_NOMBRE]=_TIPOS.PropertyNames.TIPO_NOMBRE;
ht[TIPO_DESCR]=_TIPOS.PropertyNames.TIPO_DESCR;
ht[TIPO_CODIGO]=_TIPOS.PropertyNames.TIPO_CODIGO;
ht[GRUPO_TIPO_ID]=_TIPOS.PropertyNames.GRUPO_TIPO_ID;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string TIPO_ID ="TIPO_ID";
      public const string TIPO_NOMBRE ="TIPO_NOMBRE";
      public const string TIPO_DESCR ="TIPO_DESCR";
      public const string TIPO_CODIGO ="TIPO_CODIGO";
      public const string GRUPO_TIPO_ID ="GRUPO_TIPO_ID";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[TIPO_ID]=_TIPOS.ColumnNames.TIPO_ID;
      ht[TIPO_NOMBRE]=_TIPOS.ColumnNames.TIPO_NOMBRE;
      ht[TIPO_DESCR]=_TIPOS.ColumnNames.TIPO_DESCR;
      ht[TIPO_CODIGO]=_TIPOS.ColumnNames.TIPO_CODIGO;
      ht[GRUPO_TIPO_ID]=_TIPOS.ColumnNames.GRUPO_TIPO_ID;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string TIPO_ID = "s_TIPO_ID";
      public const string TIPO_NOMBRE = "s_TIPO_NOMBRE";
      public const string TIPO_DESCR = "s_TIPO_DESCR";
      public const string TIPO_CODIGO = "s_TIPO_CODIGO";
      public const string GRUPO_TIPO_ID = "s_GRUPO_TIPO_ID";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int TIPO_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.TIPO_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.TIPO_ID, value);      }  }
 public virtual string TIPO_NOMBRE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.TIPO_NOMBRE); 
     }
   set 
     {
       base.Setstring(ColumnNames.TIPO_NOMBRE, value);      }  }
 public virtual string TIPO_DESCR 
 {
   get 
     { 
       return base.Getstring(ColumnNames.TIPO_DESCR); 
     }
   set 
     {
       base.Setstring(ColumnNames.TIPO_DESCR, value);      }  }
 public virtual string TIPO_CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.TIPO_CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.TIPO_CODIGO, value);      }  }
 public virtual int GRUPO_TIPO_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.GRUPO_TIPO_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.GRUPO_TIPO_ID, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_TIPO_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.TIPO_ID) ? string.Empty : base.GetintAsString(ColumnNames.TIPO_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.TIPO_ID); 
				else 
					this.TIPO_ID = base.SetintAsString(ColumnNames.TIPO_ID, value); 
			} 
		} 
public virtual string s_TIPO_NOMBRE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.TIPO_NOMBRE) ? string.Empty : base.GetstringAsString(ColumnNames.TIPO_NOMBRE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.TIPO_NOMBRE); 
				else 
					this.TIPO_NOMBRE = base.SetstringAsString(ColumnNames.TIPO_NOMBRE, value); 
			} 
		} 
public virtual string s_TIPO_DESCR 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.TIPO_DESCR) ? string.Empty : base.GetstringAsString(ColumnNames.TIPO_DESCR); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.TIPO_DESCR); 
				else 
					this.TIPO_DESCR = base.SetstringAsString(ColumnNames.TIPO_DESCR, value); 
			} 
		} 
public virtual string s_TIPO_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.TIPO_CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.TIPO_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.TIPO_CODIGO); 
				else 
					this.TIPO_CODIGO = base.SetstringAsString(ColumnNames.TIPO_CODIGO, value); 
			} 
		} 
public virtual string s_GRUPO_TIPO_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.GRUPO_TIPO_ID) ? string.Empty : base.GetintAsString(ColumnNames.GRUPO_TIPO_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.GRUPO_TIPO_ID); 
				else 
					this.GRUPO_TIPO_ID = base.SetintAsString(ColumnNames.GRUPO_TIPO_ID, value); 
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
				 public WhereParameter TIPO_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.TIPO_ID, Parameters.TIPO_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter TIPO_NOMBRE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.TIPO_NOMBRE, Parameters.TIPO_NOMBRE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter TIPO_DESCR 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.TIPO_DESCR, Parameters.TIPO_DESCR); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter TIPO_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.TIPO_CODIGO, Parameters.TIPO_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter GRUPO_TIPO_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.GRUPO_TIPO_ID, Parameters.GRUPO_TIPO_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter TIPO_ID 
		    {
				get
		        {
					if(_TIPO_ID_W == null)
	        	    {
						_TIPO_ID_W = TearOff.TIPO_ID;
					}
					return _TIPO_ID_W;
				}
			}
public WhereParameter TIPO_NOMBRE 
		    {
				get
		        {
					if(_TIPO_NOMBRE_W == null)
	        	    {
						_TIPO_NOMBRE_W = TearOff.TIPO_NOMBRE;
					}
					return _TIPO_NOMBRE_W;
				}
			}
public WhereParameter TIPO_DESCR 
		    {
				get
		        {
					if(_TIPO_DESCR_W == null)
	        	    {
						_TIPO_DESCR_W = TearOff.TIPO_DESCR;
					}
					return _TIPO_DESCR_W;
				}
			}
public WhereParameter TIPO_CODIGO 
		    {
				get
		        {
					if(_TIPO_CODIGO_W == null)
	        	    {
						_TIPO_CODIGO_W = TearOff.TIPO_CODIGO;
					}
					return _TIPO_CODIGO_W;
				}
			}
public WhereParameter GRUPO_TIPO_ID 
		    {
				get
		        {
					if(_GRUPO_TIPO_ID_W == null)
	        	    {
						_GRUPO_TIPO_ID_W = TearOff.GRUPO_TIPO_ID;
					}
					return _GRUPO_TIPO_ID_W;
				}
			}

			
			private WhereParameter _TIPO_ID_W = null;
private WhereParameter _TIPO_NOMBRE_W = null;
private WhereParameter _TIPO_DESCR_W = null;
private WhereParameter _TIPO_CODIGO_W = null;
private WhereParameter _GRUPO_TIPO_ID_W = null;
	
			
			public void WhereClauseReset()
			{
			 _TIPO_ID_W = null;
_TIPO_NOMBRE_W = null;
_TIPO_DESCR_W = null;
_TIPO_CODIGO_W = null;
_GRUPO_TIPO_ID_W = null;
	
			 
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
				  public AggregateParameter TIPO_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.TIPO_ID, Parameters.TIPO_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter TIPO_NOMBRE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.TIPO_NOMBRE, Parameters.TIPO_NOMBRE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter TIPO_DESCR 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.TIPO_DESCR, Parameters.TIPO_DESCR);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter TIPO_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.TIPO_CODIGO, Parameters.TIPO_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter GRUPO_TIPO_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.GRUPO_TIPO_ID, Parameters.GRUPO_TIPO_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter TIPO_ID 
		    {
				get
		        {
					if(_TIPO_ID_W == null)
	        	    {
						_TIPO_ID_W = TearOff.TIPO_ID;
					}
					return _TIPO_ID_W;
				}
			}
public AggregateParameter TIPO_NOMBRE 
		    {
				get
		        {
					if(_TIPO_NOMBRE_W == null)
	        	    {
						_TIPO_NOMBRE_W = TearOff.TIPO_NOMBRE;
					}
					return _TIPO_NOMBRE_W;
				}
			}
public AggregateParameter TIPO_DESCR 
		    {
				get
		        {
					if(_TIPO_DESCR_W == null)
	        	    {
						_TIPO_DESCR_W = TearOff.TIPO_DESCR;
					}
					return _TIPO_DESCR_W;
				}
			}
public AggregateParameter TIPO_CODIGO 
		    {
				get
		        {
					if(_TIPO_CODIGO_W == null)
	        	    {
						_TIPO_CODIGO_W = TearOff.TIPO_CODIGO;
					}
					return _TIPO_CODIGO_W;
				}
			}
public AggregateParameter GRUPO_TIPO_ID 
		    {
				get
		        {
					if(_GRUPO_TIPO_ID_W == null)
	        	    {
						_GRUPO_TIPO_ID_W = TearOff.GRUPO_TIPO_ID;
					}
					return _GRUPO_TIPO_ID_W;
				}
			}

			
			private AggregateParameter _TIPO_ID_W = null;
private AggregateParameter _TIPO_NOMBRE_W = null;
private AggregateParameter _TIPO_DESCR_W = null;
private AggregateParameter _TIPO_CODIGO_W = null;
private AggregateParameter _GRUPO_TIPO_ID_W = null;

			
			public void AggregateClauseReset()
			{
			  _TIPO_ID_W = null;
_TIPO_NOMBRE_W = null;
_TIPO_DESCR_W = null;
_TIPO_CODIGO_W = null;
_GRUPO_TIPO_ID_W = null;

			  
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
			cmd.CommandText = "[proc_TIPOSInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.TIPO_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_TIPOSUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_TIPOSDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.TIPO_ID); 

	p.SourceColumn = ColumnNames.TIPO_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.TIPO_ID); 
 p.SourceColumn = ColumnNames.TIPO_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.TIPO_NOMBRE); 
 p.SourceColumn = ColumnNames.TIPO_NOMBRE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.TIPO_DESCR); 
 p.SourceColumn = ColumnNames.TIPO_DESCR; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.TIPO_CODIGO); 
 p.SourceColumn = ColumnNames.TIPO_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.GRUPO_TIPO_ID); 
 p.SourceColumn = ColumnNames.GRUPO_TIPO_ID; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			