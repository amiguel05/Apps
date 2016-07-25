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
 	public abstract class  _SUPLIDORES : SqlClientEntity
	{
	  public _SUPLIDORES()
		{
		  this.QuerySource = "SUPLIDORES";
			this.MappingName = "SUPLIDORES";
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
			
			return base.LoadFromSql("[proc_SUPLIDORESLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int SUP_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.SUP_ID, SUP_ID);

		   
		   return base.LoadFromSql("[proc_SUPLIDORESLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter SUP_ID
   {
      get 
      {
            return new SqlParameter("@SUP_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter SUP_CODIGO
   {
      get 
      {
            return new SqlParameter("@SUP_CODIGO", SqlDbType.Char, 3);
      }
   }
   public static SqlParameter SUP_NOMBRE
   {
      get 
      {
            return new SqlParameter("@SUP_NOMBRE", SqlDbType.VarChar, 40);
      }
   }
   public static SqlParameter SUP_ESTADO
   {
      get 
      {
            return new SqlParameter("@SUP_ESTADO", SqlDbType.Char, 1);
      }
   }
   public static SqlParameter ORI_ID
   {
      get 
      {
            return new SqlParameter("@ORI_ID", SqlDbType.Int, 0);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  SUP_ID="SUP_ID";
public const string  SUP_CODIGO="SUP_CODIGO";
public const string  SUP_NOMBRE="SUP_NOMBRE";
public const string  SUP_ESTADO="SUP_ESTADO";
public const string  ORI_ID="ORI_ID";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[SUP_ID]=_SUPLIDORES.PropertyNames.SUP_ID;
ht[SUP_CODIGO]=_SUPLIDORES.PropertyNames.SUP_CODIGO;
ht[SUP_NOMBRE]=_SUPLIDORES.PropertyNames.SUP_NOMBRE;
ht[SUP_ESTADO]=_SUPLIDORES.PropertyNames.SUP_ESTADO;
ht[ORI_ID]=_SUPLIDORES.PropertyNames.ORI_ID;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string SUP_ID ="SUP_ID";
      public const string SUP_CODIGO ="SUP_CODIGO";
      public const string SUP_NOMBRE ="SUP_NOMBRE";
      public const string SUP_ESTADO ="SUP_ESTADO";
      public const string ORI_ID ="ORI_ID";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[SUP_ID]=_SUPLIDORES.ColumnNames.SUP_ID;
      ht[SUP_CODIGO]=_SUPLIDORES.ColumnNames.SUP_CODIGO;
      ht[SUP_NOMBRE]=_SUPLIDORES.ColumnNames.SUP_NOMBRE;
      ht[SUP_ESTADO]=_SUPLIDORES.ColumnNames.SUP_ESTADO;
      ht[ORI_ID]=_SUPLIDORES.ColumnNames.ORI_ID;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string SUP_ID = "s_SUP_ID";
      public const string SUP_CODIGO = "s_SUP_CODIGO";
      public const string SUP_NOMBRE = "s_SUP_NOMBRE";
      public const string SUP_ESTADO = "s_SUP_ESTADO";
      public const string ORI_ID = "s_ORI_ID";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int SUP_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.SUP_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.SUP_ID, value);      }  }
 public virtual string SUP_CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUP_CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUP_CODIGO, value);      }  }
 public virtual string SUP_NOMBRE 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUP_NOMBRE); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUP_NOMBRE, value);      }  }
 public virtual string SUP_ESTADO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUP_ESTADO); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUP_ESTADO, value);      }  }
 public virtual int ORI_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.ORI_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.ORI_ID, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_SUP_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUP_ID) ? string.Empty : base.GetintAsString(ColumnNames.SUP_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUP_ID); 
				else 
					this.SUP_ID = base.SetintAsString(ColumnNames.SUP_ID, value); 
			} 
		} 
public virtual string s_SUP_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUP_CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.SUP_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUP_CODIGO); 
				else 
					this.SUP_CODIGO = base.SetstringAsString(ColumnNames.SUP_CODIGO, value); 
			} 
		} 
public virtual string s_SUP_NOMBRE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUP_NOMBRE) ? string.Empty : base.GetstringAsString(ColumnNames.SUP_NOMBRE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUP_NOMBRE); 
				else 
					this.SUP_NOMBRE = base.SetstringAsString(ColumnNames.SUP_NOMBRE, value); 
			} 
		} 
public virtual string s_SUP_ESTADO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUP_ESTADO) ? string.Empty : base.GetstringAsString(ColumnNames.SUP_ESTADO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUP_ESTADO); 
				else 
					this.SUP_ESTADO = base.SetstringAsString(ColumnNames.SUP_ESTADO, value); 
			} 
		} 
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
				 public WhereParameter SUP_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUP_ID, Parameters.SUP_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUP_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUP_CODIGO, Parameters.SUP_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUP_NOMBRE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUP_NOMBRE, Parameters.SUP_NOMBRE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUP_ESTADO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUP_ESTADO, Parameters.SUP_ESTADO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
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

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter SUP_ID 
		    {
				get
		        {
					if(_SUP_ID_W == null)
	        	    {
						_SUP_ID_W = TearOff.SUP_ID;
					}
					return _SUP_ID_W;
				}
			}
public WhereParameter SUP_CODIGO 
		    {
				get
		        {
					if(_SUP_CODIGO_W == null)
	        	    {
						_SUP_CODIGO_W = TearOff.SUP_CODIGO;
					}
					return _SUP_CODIGO_W;
				}
			}
public WhereParameter SUP_NOMBRE 
		    {
				get
		        {
					if(_SUP_NOMBRE_W == null)
	        	    {
						_SUP_NOMBRE_W = TearOff.SUP_NOMBRE;
					}
					return _SUP_NOMBRE_W;
				}
			}
public WhereParameter SUP_ESTADO 
		    {
				get
		        {
					if(_SUP_ESTADO_W == null)
	        	    {
						_SUP_ESTADO_W = TearOff.SUP_ESTADO;
					}
					return _SUP_ESTADO_W;
				}
			}
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

			
			private WhereParameter _SUP_ID_W = null;
private WhereParameter _SUP_CODIGO_W = null;
private WhereParameter _SUP_NOMBRE_W = null;
private WhereParameter _SUP_ESTADO_W = null;
private WhereParameter _ORI_ID_W = null;
	
			
			public void WhereClauseReset()
			{
			 _SUP_ID_W = null;
_SUP_CODIGO_W = null;
_SUP_NOMBRE_W = null;
_SUP_ESTADO_W = null;
_ORI_ID_W = null;
	
			 
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
				  public AggregateParameter SUP_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUP_ID, Parameters.SUP_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUP_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUP_CODIGO, Parameters.SUP_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUP_NOMBRE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUP_NOMBRE, Parameters.SUP_NOMBRE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUP_ESTADO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUP_ESTADO, Parameters.SUP_ESTADO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
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

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter SUP_ID 
		    {
				get
		        {
					if(_SUP_ID_W == null)
	        	    {
						_SUP_ID_W = TearOff.SUP_ID;
					}
					return _SUP_ID_W;
				}
			}
public AggregateParameter SUP_CODIGO 
		    {
				get
		        {
					if(_SUP_CODIGO_W == null)
	        	    {
						_SUP_CODIGO_W = TearOff.SUP_CODIGO;
					}
					return _SUP_CODIGO_W;
				}
			}
public AggregateParameter SUP_NOMBRE 
		    {
				get
		        {
					if(_SUP_NOMBRE_W == null)
	        	    {
						_SUP_NOMBRE_W = TearOff.SUP_NOMBRE;
					}
					return _SUP_NOMBRE_W;
				}
			}
public AggregateParameter SUP_ESTADO 
		    {
				get
		        {
					if(_SUP_ESTADO_W == null)
	        	    {
						_SUP_ESTADO_W = TearOff.SUP_ESTADO;
					}
					return _SUP_ESTADO_W;
				}
			}
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

			
			private AggregateParameter _SUP_ID_W = null;
private AggregateParameter _SUP_CODIGO_W = null;
private AggregateParameter _SUP_NOMBRE_W = null;
private AggregateParameter _SUP_ESTADO_W = null;
private AggregateParameter _ORI_ID_W = null;

			
			public void AggregateClauseReset()
			{
			  _SUP_ID_W = null;
_SUP_CODIGO_W = null;
_SUP_NOMBRE_W = null;
_SUP_ESTADO_W = null;
_ORI_ID_W = null;

			  
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
			cmd.CommandText = "[proc_SUPLIDORESInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.SUP_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_SUPLIDORESUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_SUPLIDORESDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.SUP_ID); 

	p.SourceColumn = ColumnNames.SUP_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.SUP_ID); 
 p.SourceColumn = ColumnNames.SUP_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUP_CODIGO); 
 p.SourceColumn = ColumnNames.SUP_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUP_NOMBRE); 
 p.SourceColumn = ColumnNames.SUP_NOMBRE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUP_ESTADO); 
 p.SourceColumn = ColumnNames.SUP_ESTADO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ORI_ID); 
 p.SourceColumn = ColumnNames.ORI_ID; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			