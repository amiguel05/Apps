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
 	public abstract class  _CODIGOS : SqlClientEntity
	{
	  public _CODIGOS()
		{
		  this.QuerySource = "CODIGOS";
			this.MappingName = "CODIGOS";
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
			
			return base.LoadFromSql("[proc_CODIGOSLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int CODIGO_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.CODIGO_ID, CODIGO_ID);

		   
		   return base.LoadFromSql("[proc_CODIGOSLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter CODIGO_ID
   {
      get 
      {
            return new SqlParameter("@CODIGO_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter CODIGO_NOMBRE
   {
      get 
      {
            return new SqlParameter("@CODIGO_NOMBRE", SqlDbType.VarChar, 60);
      }
   }
   public static SqlParameter CODIGO_DESCR
   {
      get 
      {
            return new SqlParameter("@CODIGO_DESCR", SqlDbType.VarChar, 200);
      }
   }
   public static SqlParameter CODIGO_COD
   {
      get 
      {
            return new SqlParameter("@CODIGO_COD", SqlDbType.VarChar, 10);
      }
   }
   public static SqlParameter GRUPO_COD_ID
   {
      get 
      {
            return new SqlParameter("@GRUPO_COD_ID", SqlDbType.Int, 0);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  CODIGO_ID="CODIGO_ID";
public const string  CODIGO_NOMBRE="CODIGO_NOMBRE";
public const string  CODIGO_DESCR="CODIGO_DESCR";
public const string  CODIGO_COD="CODIGO_COD";
public const string  GRUPO_COD_ID="GRUPO_COD_ID";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[CODIGO_ID]=_CODIGOS.PropertyNames.CODIGO_ID;
ht[CODIGO_NOMBRE]=_CODIGOS.PropertyNames.CODIGO_NOMBRE;
ht[CODIGO_DESCR]=_CODIGOS.PropertyNames.CODIGO_DESCR;
ht[CODIGO_COD]=_CODIGOS.PropertyNames.CODIGO_COD;
ht[GRUPO_COD_ID]=_CODIGOS.PropertyNames.GRUPO_COD_ID;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string CODIGO_ID ="CODIGO_ID";
      public const string CODIGO_NOMBRE ="CODIGO_NOMBRE";
      public const string CODIGO_DESCR ="CODIGO_DESCR";
      public const string CODIGO_COD ="CODIGO_COD";
      public const string GRUPO_COD_ID ="GRUPO_COD_ID";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[CODIGO_ID]=_CODIGOS.ColumnNames.CODIGO_ID;
      ht[CODIGO_NOMBRE]=_CODIGOS.ColumnNames.CODIGO_NOMBRE;
      ht[CODIGO_DESCR]=_CODIGOS.ColumnNames.CODIGO_DESCR;
      ht[CODIGO_COD]=_CODIGOS.ColumnNames.CODIGO_COD;
      ht[GRUPO_COD_ID]=_CODIGOS.ColumnNames.GRUPO_COD_ID;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string CODIGO_ID = "s_CODIGO_ID";
      public const string CODIGO_NOMBRE = "s_CODIGO_NOMBRE";
      public const string CODIGO_DESCR = "s_CODIGO_DESCR";
      public const string CODIGO_COD = "s_CODIGO_COD";
      public const string GRUPO_COD_ID = "s_GRUPO_COD_ID";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int CODIGO_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.CODIGO_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.CODIGO_ID, value);      }  }
 public virtual string CODIGO_NOMBRE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.CODIGO_NOMBRE); 
     }
   set 
     {
       base.Setstring(ColumnNames.CODIGO_NOMBRE, value);      }  }
 public virtual string CODIGO_DESCR 
 {
   get 
     { 
       return base.Getstring(ColumnNames.CODIGO_DESCR); 
     }
   set 
     {
       base.Setstring(ColumnNames.CODIGO_DESCR, value);      }  }
 public virtual string CODIGO_COD 
 {
   get 
     { 
       return base.Getstring(ColumnNames.CODIGO_COD); 
     }
   set 
     {
       base.Setstring(ColumnNames.CODIGO_COD, value);      }  }
 public virtual int GRUPO_COD_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.GRUPO_COD_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.GRUPO_COD_ID, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_CODIGO_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.CODIGO_ID) ? string.Empty : base.GetintAsString(ColumnNames.CODIGO_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.CODIGO_ID); 
				else 
					this.CODIGO_ID = base.SetintAsString(ColumnNames.CODIGO_ID, value); 
			} 
		} 
public virtual string s_CODIGO_NOMBRE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.CODIGO_NOMBRE) ? string.Empty : base.GetstringAsString(ColumnNames.CODIGO_NOMBRE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.CODIGO_NOMBRE); 
				else 
					this.CODIGO_NOMBRE = base.SetstringAsString(ColumnNames.CODIGO_NOMBRE, value); 
			} 
		} 
public virtual string s_CODIGO_DESCR 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.CODIGO_DESCR) ? string.Empty : base.GetstringAsString(ColumnNames.CODIGO_DESCR); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.CODIGO_DESCR); 
				else 
					this.CODIGO_DESCR = base.SetstringAsString(ColumnNames.CODIGO_DESCR, value); 
			} 
		} 
public virtual string s_CODIGO_COD 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.CODIGO_COD) ? string.Empty : base.GetstringAsString(ColumnNames.CODIGO_COD); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.CODIGO_COD); 
				else 
					this.CODIGO_COD = base.SetstringAsString(ColumnNames.CODIGO_COD, value); 
			} 
		} 
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
				 public WhereParameter CODIGO_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.CODIGO_ID, Parameters.CODIGO_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter CODIGO_NOMBRE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.CODIGO_NOMBRE, Parameters.CODIGO_NOMBRE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter CODIGO_DESCR 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.CODIGO_DESCR, Parameters.CODIGO_DESCR); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter CODIGO_COD 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.CODIGO_COD, Parameters.CODIGO_COD); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
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

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter CODIGO_ID 
		    {
				get
		        {
					if(_CODIGO_ID_W == null)
	        	    {
						_CODIGO_ID_W = TearOff.CODIGO_ID;
					}
					return _CODIGO_ID_W;
				}
			}
public WhereParameter CODIGO_NOMBRE 
		    {
				get
		        {
					if(_CODIGO_NOMBRE_W == null)
	        	    {
						_CODIGO_NOMBRE_W = TearOff.CODIGO_NOMBRE;
					}
					return _CODIGO_NOMBRE_W;
				}
			}
public WhereParameter CODIGO_DESCR 
		    {
				get
		        {
					if(_CODIGO_DESCR_W == null)
	        	    {
						_CODIGO_DESCR_W = TearOff.CODIGO_DESCR;
					}
					return _CODIGO_DESCR_W;
				}
			}
public WhereParameter CODIGO_COD 
		    {
				get
		        {
					if(_CODIGO_COD_W == null)
	        	    {
						_CODIGO_COD_W = TearOff.CODIGO_COD;
					}
					return _CODIGO_COD_W;
				}
			}
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

			
			private WhereParameter _CODIGO_ID_W = null;
private WhereParameter _CODIGO_NOMBRE_W = null;
private WhereParameter _CODIGO_DESCR_W = null;
private WhereParameter _CODIGO_COD_W = null;
private WhereParameter _GRUPO_COD_ID_W = null;
	
			
			public void WhereClauseReset()
			{
			 _CODIGO_ID_W = null;
_CODIGO_NOMBRE_W = null;
_CODIGO_DESCR_W = null;
_CODIGO_COD_W = null;
_GRUPO_COD_ID_W = null;
	
			 
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
				  public AggregateParameter CODIGO_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.CODIGO_ID, Parameters.CODIGO_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter CODIGO_NOMBRE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.CODIGO_NOMBRE, Parameters.CODIGO_NOMBRE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter CODIGO_DESCR 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.CODIGO_DESCR, Parameters.CODIGO_DESCR);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter CODIGO_COD 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.CODIGO_COD, Parameters.CODIGO_COD);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
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

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter CODIGO_ID 
		    {
				get
		        {
					if(_CODIGO_ID_W == null)
	        	    {
						_CODIGO_ID_W = TearOff.CODIGO_ID;
					}
					return _CODIGO_ID_W;
				}
			}
public AggregateParameter CODIGO_NOMBRE 
		    {
				get
		        {
					if(_CODIGO_NOMBRE_W == null)
	        	    {
						_CODIGO_NOMBRE_W = TearOff.CODIGO_NOMBRE;
					}
					return _CODIGO_NOMBRE_W;
				}
			}
public AggregateParameter CODIGO_DESCR 
		    {
				get
		        {
					if(_CODIGO_DESCR_W == null)
	        	    {
						_CODIGO_DESCR_W = TearOff.CODIGO_DESCR;
					}
					return _CODIGO_DESCR_W;
				}
			}
public AggregateParameter CODIGO_COD 
		    {
				get
		        {
					if(_CODIGO_COD_W == null)
	        	    {
						_CODIGO_COD_W = TearOff.CODIGO_COD;
					}
					return _CODIGO_COD_W;
				}
			}
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

			
			private AggregateParameter _CODIGO_ID_W = null;
private AggregateParameter _CODIGO_NOMBRE_W = null;
private AggregateParameter _CODIGO_DESCR_W = null;
private AggregateParameter _CODIGO_COD_W = null;
private AggregateParameter _GRUPO_COD_ID_W = null;

			
			public void AggregateClauseReset()
			{
			  _CODIGO_ID_W = null;
_CODIGO_NOMBRE_W = null;
_CODIGO_DESCR_W = null;
_CODIGO_COD_W = null;
_GRUPO_COD_ID_W = null;

			  
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
			cmd.CommandText = "[proc_CODIGOSInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.CODIGO_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_CODIGOSUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_CODIGOSDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.CODIGO_ID); 

	p.SourceColumn = ColumnNames.CODIGO_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.CODIGO_ID); 
 p.SourceColumn = ColumnNames.CODIGO_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.CODIGO_NOMBRE); 
 p.SourceColumn = ColumnNames.CODIGO_NOMBRE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.CODIGO_DESCR); 
 p.SourceColumn = ColumnNames.CODIGO_DESCR; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.CODIGO_COD); 
 p.SourceColumn = ColumnNames.CODIGO_COD; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.GRUPO_COD_ID); 
 p.SourceColumn = ColumnNames.GRUPO_COD_ID; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			