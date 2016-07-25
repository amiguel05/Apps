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
 	public abstract class  _SUCURSALES : SqlClientEntity
	{
	  public _SUCURSALES()
		{
		  this.QuerySource = "SUCURSALES";
			this.MappingName = "SUCURSALES";
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
			
			return base.LoadFromSql("[proc_SUCURSALESLoadAll]", parameters);
		}
		
		public virtual bool LoadByPrimaryKey(int SUC_ID)
		 {
		   ListDictionary parameters = new ListDictionary();
		   
		   parameters.Add(Parameters.SUC_ID, SUC_ID);

		   
		   return base.LoadFromSql("[proc_SUCURSALESLoadByPrimaryKey]", parameters);
		  }
		  
		 #region Parameters
		 protected class Parameters
		  {
		   
		      public static SqlParameter SUC_ID
   {
      get 
      {
            return new SqlParameter("@SUC_ID", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter SUC_CODIGO
   {
      get 
      {
            return new SqlParameter("@SUC_CODIGO", SqlDbType.VarChar, 5);
      }
   }
   public static SqlParameter SUC_DESCRIPCION
   {
      get 
      {
            return new SqlParameter("@SUC_DESCRIPCION", SqlDbType.VarChar, 35);
      }
   }
   public static SqlParameter SUC_ESTADO
   {
      get 
      {
            return new SqlParameter("@SUC_ESTADO", SqlDbType.Char, 1);
      }
   }
   public static SqlParameter COM_CODIGO
   {
      get 
      {
            return new SqlParameter("@COM_CODIGO", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter ALM_CODIGO
   {
      get 
      {
            return new SqlParameter("@ALM_CODIGO", SqlDbType.Int, 0);
      }
   }
   public static SqlParameter BLT_UBICACION
   {
      get 
      {
            return new SqlParameter("@BLT_UBICACION", SqlDbType.VarChar, 11);
      }
   }

		   }
		 	#endregion		
		 	
		#region ColumnNames
		public class ColumnNames
		{
		   public const string  SUC_ID="SUC_ID";
public const string  SUC_CODIGO="SUC_CODIGO";
public const string  SUC_DESCRIPCION="SUC_DESCRIPCION";
public const string  SUC_ESTADO="SUC_ESTADO";
public const string  COM_CODIGO="COM_CODIGO";
public const string  ALM_CODIGO="ALM_CODIGO";
public const string  BLT_UBICACION="BLT_UBICACION";

		   
		  static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				 {
					ht = new Hashtable();
					ht[SUC_ID]=_SUCURSALES.PropertyNames.SUC_ID;
ht[SUC_CODIGO]=_SUCURSALES.PropertyNames.SUC_CODIGO;
ht[SUC_DESCRIPCION]=_SUCURSALES.PropertyNames.SUC_DESCRIPCION;
ht[SUC_ESTADO]=_SUCURSALES.PropertyNames.SUC_ESTADO;
ht[COM_CODIGO]=_SUCURSALES.PropertyNames.COM_CODIGO;
ht[ALM_CODIGO]=_SUCURSALES.PropertyNames.ALM_CODIGO;
ht[BLT_UBICACION]=_SUCURSALES.PropertyNames.BLT_UBICACION;

                 }
					return (string)ht[columnName];
			   }
  			static private Hashtable ht = null;	
  			
  		}
  	#endregion
  	
  	
		#region PropertyNames
		public class PropertyNames
		{
		        public const string SUC_ID ="SUC_ID";
      public const string SUC_CODIGO ="SUC_CODIGO";
      public const string SUC_DESCRIPCION ="SUC_DESCRIPCION";
      public const string SUC_ESTADO ="SUC_ESTADO";
      public const string COM_CODIGO ="COM_CODIGO";
      public const string ALM_CODIGO ="ALM_CODIGO";
      public const string BLT_UBICACION ="BLT_UBICACION";

		  
		  static public string ToColumnName(string propertyName)
			{
			  if(ht == null)
				{
				  ht = new Hashtable();
				        ht[SUC_ID]=_SUCURSALES.ColumnNames.SUC_ID;
      ht[SUC_CODIGO]=_SUCURSALES.ColumnNames.SUC_CODIGO;
      ht[SUC_DESCRIPCION]=_SUCURSALES.ColumnNames.SUC_DESCRIPCION;
      ht[SUC_ESTADO]=_SUCURSALES.ColumnNames.SUC_ESTADO;
      ht[COM_CODIGO]=_SUCURSALES.ColumnNames.COM_CODIGO;
      ht[ALM_CODIGO]=_SUCURSALES.ColumnNames.ALM_CODIGO;
      ht[BLT_UBICACION]=_SUCURSALES.ColumnNames.BLT_UBICACION;

				}
				return (string)ht[propertyName];
			 }
			 static private Hashtable ht = null;		
		 }			 
		#endregion	 
		
		#region StringPropertyNames
		public class StringPropertyNames
		{  
		         public const string SUC_ID = "s_SUC_ID";
      public const string SUC_CODIGO = "s_SUC_CODIGO";
      public const string SUC_DESCRIPCION = "s_SUC_DESCRIPCION";
      public const string SUC_ESTADO = "s_SUC_ESTADO";
      public const string COM_CODIGO = "s_COM_CODIGO";
      public const string ALM_CODIGO = "s_ALM_CODIGO";
      public const string BLT_UBICACION = "s_BLT_UBICACION";

		   
		 }
		#endregion
		
		#region Properties
		 public virtual int SUC_ID 
 {
   get 
     { 
       return base.Getint(ColumnNames.SUC_ID); 
     }
   set 
     {
       base.Setint(ColumnNames.SUC_ID, value);      }  }
 public virtual string SUC_CODIGO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUC_CODIGO); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUC_CODIGO, value);      }  }
 public virtual string SUC_DESCRIPCION 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUC_DESCRIPCION); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUC_DESCRIPCION, value);      }  }
 public virtual string SUC_ESTADO 
 {
   get 
     { 
       return base.Getstring(ColumnNames.SUC_ESTADO); 
     }
   set 
     {
       base.Setstring(ColumnNames.SUC_ESTADO, value);      }  }
 public virtual int COM_CODIGO 
 {
   get 
     { 
       return base.Getint(ColumnNames.COM_CODIGO); 
     }
   set 
     {
       base.Setint(ColumnNames.COM_CODIGO, value);      }  }
 public virtual int ALM_CODIGO 
 {
   get 
     { 
       return base.Getint(ColumnNames.ALM_CODIGO); 
     }
   set 
     {
       base.Setint(ColumnNames.ALM_CODIGO, value);      }  }
 public virtual string BLT_UBICACION 
 {
   get 
     { 
       return base.Getstring(ColumnNames.BLT_UBICACION); 
     }
   set 
     {
       base.Setstring(ColumnNames.BLT_UBICACION, value);      }  }

		#endregion
		
		#region String Properties
		 public virtual string s_SUC_ID 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUC_ID) ? string.Empty : base.GetintAsString(ColumnNames.SUC_ID); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUC_ID); 
				else 
					this.SUC_ID = base.SetintAsString(ColumnNames.SUC_ID, value); 
			} 
		} 
public virtual string s_SUC_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUC_CODIGO) ? string.Empty : base.GetstringAsString(ColumnNames.SUC_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUC_CODIGO); 
				else 
					this.SUC_CODIGO = base.SetstringAsString(ColumnNames.SUC_CODIGO, value); 
			} 
		} 
public virtual string s_SUC_DESCRIPCION 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUC_DESCRIPCION) ? string.Empty : base.GetstringAsString(ColumnNames.SUC_DESCRIPCION); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUC_DESCRIPCION); 
				else 
					this.SUC_DESCRIPCION = base.SetstringAsString(ColumnNames.SUC_DESCRIPCION, value); 
			} 
		} 
public virtual string s_SUC_ESTADO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.SUC_ESTADO) ? string.Empty : base.GetstringAsString(ColumnNames.SUC_ESTADO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.SUC_ESTADO); 
				else 
					this.SUC_ESTADO = base.SetstringAsString(ColumnNames.SUC_ESTADO, value); 
			} 
		} 
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
public virtual string s_ALM_CODIGO 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.ALM_CODIGO) ? string.Empty : base.GetintAsString(ColumnNames.ALM_CODIGO); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.ALM_CODIGO); 
				else 
					this.ALM_CODIGO = base.SetintAsString(ColumnNames.ALM_CODIGO, value); 
			} 
		} 
public virtual string s_BLT_UBICACION 
	    { 
			get 
	        { 
				return this.IsColumnNull(ColumnNames.BLT_UBICACION) ? string.Empty : base.GetstringAsString(ColumnNames.BLT_UBICACION); 
			} 
			set 
	        { 
				if(string.Empty == value) 
					this.SetColumnNull(ColumnNames.BLT_UBICACION); 
				else 
					this.BLT_UBICACION = base.SetstringAsString(ColumnNames.BLT_UBICACION, value); 
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
				 public WhereParameter SUC_ID 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUC_ID, Parameters.SUC_ID); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUC_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUC_CODIGO, Parameters.SUC_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUC_DESCRIPCION 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUC_DESCRIPCION, Parameters.SUC_DESCRIPCION); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter SUC_ESTADO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.SUC_ESTADO, Parameters.SUC_ESTADO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
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
 public WhereParameter ALM_CODIGO 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.ALM_CODIGO, Parameters.ALM_CODIGO); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}
 public WhereParameter BLT_UBICACION 
				{ 
					get 
					{ 
							WhereParameter where = new WhereParameter(ColumnNames.BLT_UBICACION, Parameters.BLT_UBICACION); 
							this._clause._entity.Query.AddWhereParameter(where); 
							return where; 
					}
				}

				
				private WhereClause _clause;
			}
			#endregion
			
			public WhereParameter SUC_ID 
		    {
				get
		        {
					if(_SUC_ID_W == null)
	        	    {
						_SUC_ID_W = TearOff.SUC_ID;
					}
					return _SUC_ID_W;
				}
			}
public WhereParameter SUC_CODIGO 
		    {
				get
		        {
					if(_SUC_CODIGO_W == null)
	        	    {
						_SUC_CODIGO_W = TearOff.SUC_CODIGO;
					}
					return _SUC_CODIGO_W;
				}
			}
public WhereParameter SUC_DESCRIPCION 
		    {
				get
		        {
					if(_SUC_DESCRIPCION_W == null)
	        	    {
						_SUC_DESCRIPCION_W = TearOff.SUC_DESCRIPCION;
					}
					return _SUC_DESCRIPCION_W;
				}
			}
public WhereParameter SUC_ESTADO 
		    {
				get
		        {
					if(_SUC_ESTADO_W == null)
	        	    {
						_SUC_ESTADO_W = TearOff.SUC_ESTADO;
					}
					return _SUC_ESTADO_W;
				}
			}
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
public WhereParameter ALM_CODIGO 
		    {
				get
		        {
					if(_ALM_CODIGO_W == null)
	        	    {
						_ALM_CODIGO_W = TearOff.ALM_CODIGO;
					}
					return _ALM_CODIGO_W;
				}
			}
public WhereParameter BLT_UBICACION 
		    {
				get
		        {
					if(_BLT_UBICACION_W == null)
	        	    {
						_BLT_UBICACION_W = TearOff.BLT_UBICACION;
					}
					return _BLT_UBICACION_W;
				}
			}

			
			private WhereParameter _SUC_ID_W = null;
private WhereParameter _SUC_CODIGO_W = null;
private WhereParameter _SUC_DESCRIPCION_W = null;
private WhereParameter _SUC_ESTADO_W = null;
private WhereParameter _COM_CODIGO_W = null;
private WhereParameter _ALM_CODIGO_W = null;
private WhereParameter _BLT_UBICACION_W = null;
	
			
			public void WhereClauseReset()
			{
			 _SUC_ID_W = null;
_SUC_CODIGO_W = null;
_SUC_DESCRIPCION_W = null;
_SUC_ESTADO_W = null;
_COM_CODIGO_W = null;
_ALM_CODIGO_W = null;
_BLT_UBICACION_W = null;
	
			 
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
				  public AggregateParameter SUC_ID 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUC_ID, Parameters.SUC_ID);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUC_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUC_CODIGO, Parameters.SUC_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUC_DESCRIPCION 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUC_DESCRIPCION, Parameters.SUC_DESCRIPCION);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter SUC_ESTADO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.SUC_ESTADO, Parameters.SUC_ESTADO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
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
 public AggregateParameter ALM_CODIGO 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.ALM_CODIGO, Parameters.ALM_CODIGO);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}
 public AggregateParameter BLT_UBICACION 
		{
			get
			{
					AggregateParameter aggregate = new AggregateParameter(ColumnNames.BLT_UBICACION, Parameters.BLT_UBICACION);
					this._clause._entity.Query.AddAggregateParameter(aggregate);
					return aggregate;
			}
		}

					
				 private AggregateClause _clause;
			}
			#endregion
			
			public AggregateParameter SUC_ID 
		    {
				get
		        {
					if(_SUC_ID_W == null)
	        	    {
						_SUC_ID_W = TearOff.SUC_ID;
					}
					return _SUC_ID_W;
				}
			}
public AggregateParameter SUC_CODIGO 
		    {
				get
		        {
					if(_SUC_CODIGO_W == null)
	        	    {
						_SUC_CODIGO_W = TearOff.SUC_CODIGO;
					}
					return _SUC_CODIGO_W;
				}
			}
public AggregateParameter SUC_DESCRIPCION 
		    {
				get
		        {
					if(_SUC_DESCRIPCION_W == null)
	        	    {
						_SUC_DESCRIPCION_W = TearOff.SUC_DESCRIPCION;
					}
					return _SUC_DESCRIPCION_W;
				}
			}
public AggregateParameter SUC_ESTADO 
		    {
				get
		        {
					if(_SUC_ESTADO_W == null)
	        	    {
						_SUC_ESTADO_W = TearOff.SUC_ESTADO;
					}
					return _SUC_ESTADO_W;
				}
			}
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
public AggregateParameter ALM_CODIGO 
		    {
				get
		        {
					if(_ALM_CODIGO_W == null)
	        	    {
						_ALM_CODIGO_W = TearOff.ALM_CODIGO;
					}
					return _ALM_CODIGO_W;
				}
			}
public AggregateParameter BLT_UBICACION 
		    {
				get
		        {
					if(_BLT_UBICACION_W == null)
	        	    {
						_BLT_UBICACION_W = TearOff.BLT_UBICACION;
					}
					return _BLT_UBICACION_W;
				}
			}

			
			private AggregateParameter _SUC_ID_W = null;
private AggregateParameter _SUC_CODIGO_W = null;
private AggregateParameter _SUC_DESCRIPCION_W = null;
private AggregateParameter _SUC_ESTADO_W = null;
private AggregateParameter _COM_CODIGO_W = null;
private AggregateParameter _ALM_CODIGO_W = null;
private AggregateParameter _BLT_UBICACION_W = null;

			
			public void AggregateClauseReset()
			{
			  _SUC_ID_W = null;
_SUC_CODIGO_W = null;
_SUC_DESCRIPCION_W = null;
_SUC_ESTADO_W = null;
_COM_CODIGO_W = null;
_ALM_CODIGO_W = null;
_BLT_UBICACION_W = null;

			  
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
			cmd.CommandText = "[proc_SUCURSALESInsert]";
	
			CreateParameters(cmd);
			
			 SqlParameter p;

			p = cmd.Parameters[Parameters.SUC_ID.ParameterName];
			p.Direction = ParameterDirection.Output;


    
			return cmd;
		}	

		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[proc_SUCURSALESUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
		
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
		    cmd.CommandText = "[proc_SUCURSALESDelete]";
	
				SqlParameter p; 

	p = cmd.Parameters.Add(Parameters.SUC_ID); 

	p.SourceColumn = ColumnNames.SUC_ID;
	p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
		    SqlParameter p;
		
			 p = cmd.Parameters.Add(Parameters.SUC_ID); 
 p.SourceColumn = ColumnNames.SUC_ID; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUC_CODIGO); 
 p.SourceColumn = ColumnNames.SUC_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUC_DESCRIPCION); 
 p.SourceColumn = ColumnNames.SUC_DESCRIPCION; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.SUC_ESTADO); 
 p.SourceColumn = ColumnNames.SUC_ESTADO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.COM_CODIGO); 
 p.SourceColumn = ColumnNames.COM_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.ALM_CODIGO); 
 p.SourceColumn = ColumnNames.ALM_CODIGO; 
 p.SourceVersion = DataRowVersion.Current; 
 p = cmd.Parameters.Add(Parameters.BLT_UBICACION); 
 p.SourceColumn = ColumnNames.BLT_UBICACION; 
 p.SourceVersion = DataRowVersion.Current; 


			return cmd;
		}
	}
}
			
			