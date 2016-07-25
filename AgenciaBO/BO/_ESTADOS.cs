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
 	public abstract class  _ESTADOS : SqlClientEntity
	{
	  public _ESTADOS()
		{
		  this.QuerySource = "ESTADOS";
			this.MappingName = "ESTADOS";
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
			
			return base.LoadFromSql("[proc_ESTADOSLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int ESTADO_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.ESTADO_ID, ESTADO_ID);

		   
		   return base.LoadFromSql("[proc_ESTADOSLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter ESTADO_ID
   {
      get 
      {
            return new SqlParameter("@ESTADO_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter ESTADO_NOMBRE
   {
      get 
      {
            return new SqlParameter("@ESTADO_NOMBRE", SqlDbType.VarChar, 60);
      }
   }
   public static SqlParameter ESTADO_DESCR
   {
      get 
      {
            return new SqlParameter("@ESTADO_DESCR", SqlDbType.VarChar, 200);
      }
   }
   public static SqlParameter ESTADO_CODIGO
   {
      get 
      {
            return new SqlParameter("@ESTADO_CODIGO", SqlDbType.VarChar, 10);
      }
   }
   public static SqlParameter GRUPO_EST_ID
   {
      get 
      {
            return new SqlParameter("@GRUPO_EST_ID", SqlDbType.Int, 0);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  ESTADO_ID="ESTADO_ID";
public const string  ESTADO_NOMBRE="ESTADO_NOMBRE";
public const string  ESTADO_DESCR="ESTADO_DESCR";
public const string  ESTADO_CODIGO="ESTADO_CODIGO";
public const string  GRUPO_EST_ID="GRUPO_EST_ID";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[ESTADO_ID]=_ESTADOS.PropertyNames.ESTADO_ID;
ht[ESTADO_NOMBRE]=_ESTADOS.PropertyNames.ESTADO_NOMBRE;
ht[ESTADO_DESCR]=_ESTADOS.PropertyNames.ESTADO_DESCR;
ht[ESTADO_CODIGO]=_ESTADOS.PropertyNames.ESTADO_CODIGO;
ht[GRUPO_EST_ID]=_ESTADOS.PropertyNames.GRUPO_EST_ID;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string ESTADO_ID ="ESTADO_ID";
      public const string ESTADO_NOMBRE ="ESTADO_NOMBRE";
      public const string ESTADO_DESCR ="ESTADO_DESCR";
      public const string ESTADO_CODIGO ="ESTADO_CODIGO";
      public const string GRUPO_EST_ID ="GRUPO_EST_ID";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[ESTADO_ID]=_ESTADOS.ColumnNames.ESTADO_ID;
      ht[ESTADO_NOMBRE]=_ESTADOS.ColumnNames.ESTADO_NOMBRE;
      ht[ESTADO_DESCR]=_ESTADOS.ColumnNames.ESTADO_DESCR;
      ht[ESTADO_CODIGO]=_ESTADOS.ColumnNames.ESTADO_CODIGO;
      ht[GRUPO_EST_ID]=_ESTADOS.ColumnNames.GRUPO_EST_ID;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string ESTADO_ID = "s_ESTADO_ID";
      public const string ESTADO_NOMBRE = "s_ESTADO_NOMBRE";
      public const string ESTADO_DESCR = "s_ESTADO_DESCR";
      public const string ESTADO_CODIGO = "s_ESTADO_CODIGO";
      public const string GRUPO_EST_ID = "s_GRUPO_EST_ID";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int ESTADO_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.ESTADO_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.ESTADO_ID, value);      }  }
 public virtual string ESTADO_NOMBRE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ESTADO_NOMBRE); 
     }
   set 
     {
       base.Setstring(ColumnNames.ESTADO_NOMBRE, value);      }  }
 public virtual string ESTADO_DESCR 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ESTADO_DESCR); 
     }
   set 
     {
       base.Setstring(ColumnNames.ESTADO_DESCR, value);      }  }
 public virtual string ESTADO_CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.ESTADO_CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.ESTADO_CODIGO, value);      }  }
 public virtual int GRUPO_EST_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.GRUPO_EST_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.GRUPO_EST_ID, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_ESTADO_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ESTADO_ID) ? string.Empty : base.GetintAsString(ColumnNames.ESTADO_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ESTADO_ID); 
				else 
					this.ESTADO_ID = base.SetintAsString(ColumnNames.ESTADO_ID, value); 
			} 
		} 
public virtual string s_ESTADO_NOMBRE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ESTADO_NOMBRE) ? string.Empty : base.GetstringAsString(ColumnNames.ESTADO_NOMBRE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ESTADO_NOMBRE); 
				else 
					this.ESTADO_NOMBRE = base.SetstringAsString(ColumnNames.ESTADO_NOMBRE, value); 
			} 
		} 
public virtual string s_ESTADO_DESCR 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ESTADO_DESCR) ? string.Empty : base.GetstringAsString(ColumnNames.ESTADO_DESCR); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ESTADO_DESCR); 
				else 
					this.ESTADO_DESCR = base.SetstringAsString(ColumnNames.ESTADO_DESCR, value); 
			} 
		} 
public virtual string s_ESTADO_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ESTADO_CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.ESTADO_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ESTADO_CODIGO); 
				else 
					this.ESTADO_CODIGO = base.SetstringAsString(ColumnNames.ESTADO_CODIGO, value); 
			} 
		} 
public virtual string s_GRUPO_EST_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.GRUPO_EST_ID) ? string.Empty : base.GetintAsString(ColumnNames.GRUPO_EST_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.GRUPO_EST_ID); 
				else 
					this.GRUPO_EST_ID = base.SetintAsString(ColumnNames.GRUPO_EST_ID, value); 
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
				 public WhereParameter ESTADO_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ESTADO_ID, Parameters.ESTADO_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ESTADO_NOMBRE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ESTADO_NOMBRE, Parameters.ESTADO_NOMBRE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ESTADO_DESCR 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ESTADO_DESCR, Parameters.ESTADO_DESCR); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter ESTADO_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ESTADO_CODIGO, Parameters.ESTADO_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter GRUPO_EST_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.GRUPO_EST_ID, Parameters.GRUPO_EST_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter ESTADO_ID 
		    {
				get
		        {
					if(_ESTADO_ID_W == null)
	        	    {
						_ESTADO_ID_W = TearOff.ESTADO_ID;
					}
					return _ESTADO_ID_W;
				}
			}
public WhereParameter ESTADO_NOMBRE 
		    {
				get
		        {
					if(_ESTADO_NOMBRE_W == null)
	        	    {
						_ESTADO_NOMBRE_W = TearOff.ESTADO_NOMBRE;
					}
					return _ESTADO_NOMBRE_W;
				}
			}
public WhereParameter ESTADO_DESCR 
		    {
				get
		        {
					if(_ESTADO_DESCR_W == null)
	        	    {
						_ESTADO_DESCR_W = TearOff.ESTADO_DESCR;
					}
					return _ESTADO_DESCR_W;
				}
			}
public WhereParameter ESTADO_CODIGO 
		    {
				get
		        {
					if(_ESTADO_CODIGO_W == null)
	        	    {
						_ESTADO_CODIGO_W = TearOff.ESTADO_CODIGO;
					}
					return _ESTADO_CODIGO_W;
				}
			}
public WhereParameter GRUPO_EST_ID 
		    {
				get
		        {
					if(_GRUPO_EST_ID_W == null)
	        	    {
						_GRUPO_EST_ID_W = TearOff.GRUPO_EST_ID;
					}
					return _GRUPO_EST_ID_W;
				}
			}

			
			private WhereParameter _ESTADO_ID_W = null;
private WhereParameter _ESTADO_NOMBRE_W = null;
private WhereParameter _ESTADO_DESCR_W = null;
private WhereParameter _ESTADO_CODIGO_W = null;
private WhereParameter _GRUPO_EST_ID_W = null;
	
			
			public void WhereClauseReset()
			{
			 _ESTADO_ID_W = null;
_ESTADO_NOMBRE_W = null;
_ESTADO_DESCR_W = null;
_ESTADO_CODIGO_W = null;
_GRUPO_EST_ID_W = null;
	
			 
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
				  public AggregateParameter ESTADO_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ESTADO_ID, Parameters.ESTADO_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ESTADO_NOMBRE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ESTADO_NOMBRE, Parameters.ESTADO_NOMBRE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ESTADO_DESCR 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ESTADO_DESCR, Parameters.ESTADO_DESCR);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter ESTADO_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ESTADO_CODIGO, Parameters.ESTADO_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter GRUPO_EST_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.GRUPO_EST_ID, Parameters.GRUPO_EST_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter ESTADO_ID 
		    {
				get
		        {
					if(_ESTADO_ID_W == null)
	        	    {
						_ESTADO_ID_W = TearOff.ESTADO_ID;
					}
					return _ESTADO_ID_W;
				}
			}
public AggregateParameter ESTADO_NOMBRE 
		    {
				get
		        {
					if(_ESTADO_NOMBRE_W == null)
	        	    {
						_ESTADO_NOMBRE_W = TearOff.ESTADO_NOMBRE;
					}
					return _ESTADO_NOMBRE_W;
				}
			}
public AggregateParameter ESTADO_DESCR 
		    {
				get
		        {
					if(_ESTADO_DESCR_W == null)
	        	    {
						_ESTADO_DESCR_W = TearOff.ESTADO_DESCR;
					}
					return _ESTADO_DESCR_W;
				}
			}
public AggregateParameter ESTADO_CODIGO 
		    {
				get
		        {
					if(_ESTADO_CODIGO_W == null)
	        	    {
						_ESTADO_CODIGO_W = TearOff.ESTADO_CODIGO;
					}
					return _ESTADO_CODIGO_W;
				}
			}
public AggregateParameter GRUPO_EST_ID 
		    {
				get
		        {
					if(_GRUPO_EST_ID_W == null)
	        	    {
						_GRUPO_EST_ID_W = TearOff.GRUPO_EST_ID;
					}
					return _GRUPO_EST_ID_W;
				}
			}

			
			private AggregateParameter _ESTADO_ID_W = null;
private AggregateParameter _ESTADO_NOMBRE_W = null;
private AggregateParameter _ESTADO_DESCR_W = null;
private AggregateParameter _ESTADO_CODIGO_W = null;
private AggregateParameter _GRUPO_EST_ID_W = null;

			
			public void AggregateClauseReset()
			{
			  _ESTADO_ID_W = null;
_ESTADO_NOMBRE_W = null;
_ESTADO_DESCR_W = null;
_ESTADO_CODIGO_W = null;
_GRUPO_EST_ID_W = null;

			  
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
			cmd.CommandText = "[proc_ESTADOSInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.ESTADO_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_ESTADOSUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_ESTADOSDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.ESTADO_ID); 

	p.SourceColumn = ColumnNames.ESTADO_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.ESTADO_ID); 
 p.SourceColumn = ColumnNames.ESTADO_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ESTADO_NOMBRE); 
 p.SourceColumn = ColumnNames.ESTADO_NOMBRE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ESTADO_DESCR); 
 p.SourceColumn = ColumnNames.ESTADO_DESCR; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ESTADO_CODIGO); 
 p.SourceColumn = ColumnNames.ESTADO_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.GRUPO_EST_ID); 
 p.SourceColumn = ColumnNames.GRUPO_EST_ID; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			