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
 	public abstract class  _GRUPO_CODIGOS : SqlClientEntity
	{
	  public _GRUPO_CODIGOS()
		{
		  this.QuerySource = "GRUPO_CODIGOS";
			this.MappingName = "GRUPO_CODIGOS";
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
			
			return base.LoadFromSql("[proc_GRUPO_CODIGOSLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int GRUPO_COD_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.GRUPO_COD_ID, GRUPO_COD_ID);

		   
		   return base.LoadFromSql("[proc_GRUPO_CODIGOSLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter GRUPO_COD_ID
   {
      get 
      {
            return new SqlParameter("@GRUPO_COD_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter CODIGO
   {
      get 
      {
            return new SqlParameter("@CODIGO", SqlDbType.VarChar, 10);
      }
   }
   public static SqlParameter NOMBRE
   {
      get 
      {
            return new SqlParameter("@NOMBRE", SqlDbType.VarChar, 60);
      }
   }
   public static SqlParameter DESCR
   {
      get 
      {
            return new SqlParameter("@DESCR", SqlDbType.VarChar, 200);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  GRUPO_COD_ID="GRUPO_COD_ID";
public const string  CODIGO="CODIGO";
public const string  NOMBRE="NOMBRE";
public const string  DESCR="DESCR";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[GRUPO_COD_ID]=_GRUPO_CODIGOS.PropertyNames.GRUPO_COD_ID;
ht[CODIGO]=_GRUPO_CODIGOS.PropertyNames.CODIGO;
ht[NOMBRE]=_GRUPO_CODIGOS.PropertyNames.NOMBRE;
ht[DESCR]=_GRUPO_CODIGOS.PropertyNames.DESCR;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string GRUPO_COD_ID ="GRUPO_COD_ID";
      public const string CODIGO ="CODIGO";
      public const string NOMBRE ="NOMBRE";
      public const string DESCR ="DESCR";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[GRUPO_COD_ID]=_GRUPO_CODIGOS.ColumnNames.GRUPO_COD_ID;
      ht[CODIGO]=_GRUPO_CODIGOS.ColumnNames.CODIGO;
      ht[NOMBRE]=_GRUPO_CODIGOS.ColumnNames.NOMBRE;
      ht[DESCR]=_GRUPO_CODIGOS.ColumnNames.DESCR;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string GRUPO_COD_ID = "s_GRUPO_COD_ID";
      public const string CODIGO = "s_CODIGO";
      public const string NOMBRE = "s_NOMBRE";
      public const string DESCR = "s_DESCR";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int GRUPO_COD_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.GRUPO_COD_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.GRUPO_COD_ID, value);      }  }
 public virtual string CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.CODIGO, value);      }  }
 public virtual string NOMBRE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.NOMBRE); 
     }
   set 
     {
       base.Setstring(ColumnNames.NOMBRE, value);      }  }
 public virtual string DESCR 
 {
   get 
     { 
       return base.Getstring(ColumnNames.DESCR); 
     }
   set 
     {
       base.Setstring(ColumnNames.DESCR, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_GRUPO_COD_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.GRUPO_COD_ID) ? string.Empty : base.GetintAsString(ColumnNames.GRUPO_COD_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.GRUPO_COD_ID); 
				else 
					this.GRUPO_COD_ID = base.SetintAsString(ColumnNames.GRUPO_COD_ID, value); 
			} 
		} 
public virtual string s_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.CODIGO); 
				else 
					this.CODIGO = base.SetstringAsString(ColumnNames.CODIGO, value); 
			} 
		} 
public virtual string s_NOMBRE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.NOMBRE) ? string.Empty : base.GetstringAsString(ColumnNames.NOMBRE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.NOMBRE); 
				else 
					this.NOMBRE = base.SetstringAsString(ColumnNames.NOMBRE, value); 
			} 
		} 
public virtual string s_DESCR 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.DESCR) ? string.Empty : base.GetstringAsString(ColumnNames.DESCR); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.DESCR); 
				else 
					this.DESCR = base.SetstringAsString(ColumnNames.DESCR, value); 
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
				 public WhereParameter GRUPO_COD_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.GRUPO_COD_ID, Parameters.GRUPO_COD_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.CODIGO, Parameters.CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter NOMBRE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.NOMBRE, Parameters.NOMBRE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter DESCR 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.DESCR, Parameters.DESCR); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter GRUPO_COD_ID 
		    {
				get
		        {
					if(_GRUPO_COD_ID_W == null)
	        	    {
						_GRUPO_COD_ID_W = TearOff.GRUPO_COD_ID;
					}
					return _GRUPO_COD_ID_W;
				}
			}
public WhereParameter CODIGO 
		    {
				get
		        {
					if(_CODIGO_W == null)
	        	    {
						_CODIGO_W = TearOff.CODIGO;
					}
					return _CODIGO_W;
				}
			}
public WhereParameter NOMBRE 
		    {
				get
		        {
					if(_NOMBRE_W == null)
	        	    {
						_NOMBRE_W = TearOff.NOMBRE;
					}
					return _NOMBRE_W;
				}
			}
public WhereParameter DESCR 
		    {
				get
		        {
					if(_DESCR_W == null)
	        	    {
						_DESCR_W = TearOff.DESCR;
					}
					return _DESCR_W;
				}
			}

			
			private WhereParameter _GRUPO_COD_ID_W = null;
private WhereParameter _CODIGO_W = null;
private WhereParameter _NOMBRE_W = null;
private WhereParameter _DESCR_W = null;
	
			
			public void WhereClauseReset()
			{
			 _GRUPO_COD_ID_W = null;
_CODIGO_W = null;
_NOMBRE_W = null;
_DESCR_W = null;
	
			 
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
				  public AggregateParameter GRUPO_COD_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.GRUPO_COD_ID, Parameters.GRUPO_COD_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.CODIGO, Parameters.CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter NOMBRE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.NOMBRE, Parameters.NOMBRE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter DESCR 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.DESCR, Parameters.DESCR);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter GRUPO_COD_ID 
		    {
				get
		        {
					if(_GRUPO_COD_ID_W == null)
	        	    {
						_GRUPO_COD_ID_W = TearOff.GRUPO_COD_ID;
					}
					return _GRUPO_COD_ID_W;
				}
			}
public AggregateParameter CODIGO 
		    {
				get
		        {
					if(_CODIGO_W == null)
	        	    {
						_CODIGO_W = TearOff.CODIGO;
					}
					return _CODIGO_W;
				}
			}
public AggregateParameter NOMBRE 
		    {
				get
		        {
					if(_NOMBRE_W == null)
	        	    {
						_NOMBRE_W = TearOff.NOMBRE;
					}
					return _NOMBRE_W;
				}
			}
public AggregateParameter DESCR 
		    {
				get
		        {
					if(_DESCR_W == null)
	        	    {
						_DESCR_W = TearOff.DESCR;
					}
					return _DESCR_W;
				}
			}

			
			private AggregateParameter _GRUPO_COD_ID_W = null;
private AggregateParameter _CODIGO_W = null;
private AggregateParameter _NOMBRE_W = null;
private AggregateParameter _DESCR_W = null;

			
			public void AggregateClauseReset()
			{
			  _GRUPO_COD_ID_W = null;
_CODIGO_W = null;
_NOMBRE_W = null;
_DESCR_W = null;

			  
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
			cmd.CommandText = "[proc_GRUPO_CODIGOSInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.GRUPO_COD_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_GRUPO_CODIGOSUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_GRUPO_CODIGOSDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.GRUPO_COD_ID); 

	p.SourceColumn = ColumnNames.GRUPO_COD_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.GRUPO_COD_ID); 
 p.SourceColumn = ColumnNames.GRUPO_COD_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.CODIGO); 
 p.SourceColumn = ColumnNames.CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.NOMBRE); 
 p.SourceColumn = ColumnNames.NOMBRE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.DESCR); 
 p.SourceColumn = ColumnNames.DESCR; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			