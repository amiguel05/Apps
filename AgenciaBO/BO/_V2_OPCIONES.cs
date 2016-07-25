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
 	public abstract class  _V2_OPCIONES : SqlClientEntity
	{
	  public _V2_OPCIONES()
		{
		  this.QuerySource = "V2_OPCIONES";
			this.MappingName = "V2_OPCIONES";
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
			
			return base.LoadFromSql("[proc_V2_OPCIONESLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int OPC_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.OPC_ID, OPC_ID);

		   
		   return base.LoadFromSql("[proc_V2_OPCIONESLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter OPC_ID
   {
      get 
      {
            return new SqlParameter("@OPC_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter OPC_NAME
   {
      get 
      {
            return new SqlParameter("@OPC_NAME", SqlDbType.VarChar, 50);
      }
   }
   public static SqlParameter OPC_FORM
   {
      get 
      {
            return new SqlParameter("@OPC_FORM", SqlDbType.VarChar, 50);
      }
   }
   public static SqlParameter OPC_STATE
   {
      get 
      {
            return new SqlParameter("@OPC_STATE", SqlDbType.Bit, 0);
      }
   }
   public static SqlParameter OPC_PARENT_ID
   {
      get 
      {
            return new SqlParameter("@OPC_PARENT_ID", SqlDbType.Int, 0);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  OPC_ID="OPC_ID";
public const string  OPC_NAME="OPC_NAME";
public const string  OPC_FORM="OPC_FORM";
public const string  OPC_STATE="OPC_STATE";
public const string  OPC_PARENT_ID="OPC_PARENT_ID";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[OPC_ID]=_V2_OPCIONES.PropertyNames.OPC_ID;
ht[OPC_NAME]=_V2_OPCIONES.PropertyNames.OPC_NAME;
ht[OPC_FORM]=_V2_OPCIONES.PropertyNames.OPC_FORM;
ht[OPC_STATE]=_V2_OPCIONES.PropertyNames.OPC_STATE;
ht[OPC_PARENT_ID]=_V2_OPCIONES.PropertyNames.OPC_PARENT_ID;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string OPC_ID ="OPC_ID";
      public const string OPC_NAME ="OPC_NAME";
      public const string OPC_FORM ="OPC_FORM";
      public const string OPC_STATE ="OPC_STATE";
      public const string OPC_PARENT_ID ="OPC_PARENT_ID";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[OPC_ID]=_V2_OPCIONES.ColumnNames.OPC_ID;
      ht[OPC_NAME]=_V2_OPCIONES.ColumnNames.OPC_NAME;
      ht[OPC_FORM]=_V2_OPCIONES.ColumnNames.OPC_FORM;
      ht[OPC_STATE]=_V2_OPCIONES.ColumnNames.OPC_STATE;
      ht[OPC_PARENT_ID]=_V2_OPCIONES.ColumnNames.OPC_PARENT_ID;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string OPC_ID = "s_OPC_ID";
      public const string OPC_NAME = "s_OPC_NAME";
      public const string OPC_FORM = "s_OPC_FORM";
      public const string OPC_STATE = "s_OPC_STATE";
      public const string OPC_PARENT_ID = "s_OPC_PARENT_ID";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int OPC_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.OPC_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.OPC_ID, value);      }  }
 public virtual string OPC_NAME 
 {
   get 
     { 
       return base.Getstring(ColumnNames.OPC_NAME); 
     }
   set 
     {
       base.Setstring(ColumnNames.OPC_NAME, value);      }  }
 public virtual string OPC_FORM 
 {
   get 
     { 
       return base.Getstring(ColumnNames.OPC_FORM); 
     }
   set 
     {
       base.Setstring(ColumnNames.OPC_FORM, value);      }  }
 public virtual bool OPC_STATE 
 {
   get 
     { 
       return base.Getbool(ColumnNames.OPC_STATE); 
     }
   set 
     {
       base.Setbool(ColumnNames.OPC_STATE, value);      }  }
 public virtual int OPC_PARENT_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.OPC_PARENT_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.OPC_PARENT_ID, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_OPC_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.OPC_ID) ? string.Empty : base.GetintAsString(ColumnNames.OPC_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.OPC_ID); 
				else 
					this.OPC_ID = base.SetintAsString(ColumnNames.OPC_ID, value); 
			} 
		} 
public virtual string s_OPC_NAME 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.OPC_NAME) ? string.Empty : base.GetstringAsString(ColumnNames.OPC_NAME); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.OPC_NAME); 
				else 
					this.OPC_NAME = base.SetstringAsString(ColumnNames.OPC_NAME, value); 
			} 
		} 
public virtual string s_OPC_FORM 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.OPC_FORM) ? string.Empty : base.GetstringAsString(ColumnNames.OPC_FORM); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.OPC_FORM); 
				else 
					this.OPC_FORM = base.SetstringAsString(ColumnNames.OPC_FORM, value); 
			} 
		} 
public virtual string s_OPC_STATE 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.OPC_STATE) ? string.Empty : base.GetboolAsString(ColumnNames.OPC_STATE); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.OPC_STATE); 
				else 
					this.OPC_STATE = base.SetboolAsString(ColumnNames.OPC_STATE, value); 
			} 
		} 
public virtual string s_OPC_PARENT_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.OPC_PARENT_ID) ? string.Empty : base.GetintAsString(ColumnNames.OPC_PARENT_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.OPC_PARENT_ID); 
				else 
					this.OPC_PARENT_ID = base.SetintAsString(ColumnNames.OPC_PARENT_ID, value); 
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
				 public WhereParameter OPC_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.OPC_ID, Parameters.OPC_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter OPC_NAME 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.OPC_NAME, Parameters.OPC_NAME); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter OPC_FORM 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.OPC_FORM, Parameters.OPC_FORM); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter OPC_STATE 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.OPC_STATE, Parameters.OPC_STATE); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter OPC_PARENT_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.OPC_PARENT_ID, Parameters.OPC_PARENT_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter OPC_ID 
		    {
				get
		        {
					if(_OPC_ID_W == null)
	        	    {
						_OPC_ID_W = TearOff.OPC_ID;
					}
					return _OPC_ID_W;
				}
			}
public WhereParameter OPC_NAME 
		    {
				get
		        {
					if(_OPC_NAME_W == null)
	        	    {
						_OPC_NAME_W = TearOff.OPC_NAME;
					}
					return _OPC_NAME_W;
				}
			}
public WhereParameter OPC_FORM 
		    {
				get
		        {
					if(_OPC_FORM_W == null)
	        	    {
						_OPC_FORM_W = TearOff.OPC_FORM;
					}
					return _OPC_FORM_W;
				}
			}
public WhereParameter OPC_STATE 
		    {
				get
		        {
					if(_OPC_STATE_W == null)
	        	    {
						_OPC_STATE_W = TearOff.OPC_STATE;
					}
					return _OPC_STATE_W;
				}
			}
public WhereParameter OPC_PARENT_ID 
		    {
				get
		        {
					if(_OPC_PARENT_ID_W == null)
	        	    {
						_OPC_PARENT_ID_W = TearOff.OPC_PARENT_ID;
					}
					return _OPC_PARENT_ID_W;
				}
			}

			
			private WhereParameter _OPC_ID_W = null;
private WhereParameter _OPC_NAME_W = null;
private WhereParameter _OPC_FORM_W = null;
private WhereParameter _OPC_STATE_W = null;
private WhereParameter _OPC_PARENT_ID_W = null;
	
			
			public void WhereClauseReset()
			{
			 _OPC_ID_W = null;
_OPC_NAME_W = null;
_OPC_FORM_W = null;
_OPC_STATE_W = null;
_OPC_PARENT_ID_W = null;
	
			 
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
				  public AggregateParameter OPC_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.OPC_ID, Parameters.OPC_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter OPC_NAME 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.OPC_NAME, Parameters.OPC_NAME);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter OPC_FORM 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.OPC_FORM, Parameters.OPC_FORM);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter OPC_STATE 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.OPC_STATE, Parameters.OPC_STATE);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter OPC_PARENT_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.OPC_PARENT_ID, Parameters.OPC_PARENT_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter OPC_ID 
		    {
				get
		        {
					if(_OPC_ID_W == null)
	        	    {
						_OPC_ID_W = TearOff.OPC_ID;
					}
					return _OPC_ID_W;
				}
			}
public AggregateParameter OPC_NAME 
		    {
				get
		        {
					if(_OPC_NAME_W == null)
	        	    {
						_OPC_NAME_W = TearOff.OPC_NAME;
					}
					return _OPC_NAME_W;
				}
			}
public AggregateParameter OPC_FORM 
		    {
				get
		        {
					if(_OPC_FORM_W == null)
	        	    {
						_OPC_FORM_W = TearOff.OPC_FORM;
					}
					return _OPC_FORM_W;
				}
			}
public AggregateParameter OPC_STATE 
		    {
				get
		        {
					if(_OPC_STATE_W == null)
	        	    {
						_OPC_STATE_W = TearOff.OPC_STATE;
					}
					return _OPC_STATE_W;
				}
			}
public AggregateParameter OPC_PARENT_ID 
		    {
				get
		        {
					if(_OPC_PARENT_ID_W == null)
	        	    {
						_OPC_PARENT_ID_W = TearOff.OPC_PARENT_ID;
					}
					return _OPC_PARENT_ID_W;
				}
			}

			
			private AggregateParameter _OPC_ID_W = null;
private AggregateParameter _OPC_NAME_W = null;
private AggregateParameter _OPC_FORM_W = null;
private AggregateParameter _OPC_STATE_W = null;
private AggregateParameter _OPC_PARENT_ID_W = null;

			
			public void AggregateClauseReset()
			{
			  _OPC_ID_W = null;
_OPC_NAME_W = null;
_OPC_FORM_W = null;
_OPC_STATE_W = null;
_OPC_PARENT_ID_W = null;

			  
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
			cmd.CommandText = "[proc_V2_OPCIONESInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.OPC_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_V2_OPCIONESUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_V2_OPCIONESDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.OPC_ID); 

	p.SourceColumn = ColumnNames.OPC_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.OPC_ID); 
 p.SourceColumn = ColumnNames.OPC_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.OPC_NAME); 
 p.SourceColumn = ColumnNames.OPC_NAME; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.OPC_FORM); 
 p.SourceColumn = ColumnNames.OPC_FORM; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.OPC_STATE); 
 p.SourceColumn = ColumnNames.OPC_STATE; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.OPC_PARENT_ID); 
 p.SourceColumn = ColumnNames.OPC_PARENT_ID; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			