using System.Configuration;

public static  class Parametros
{
    public  static string CadenaConexion
    {
        get { return ConfigurationManager.ConnectionStrings["dbepsContext"].ToString(); }
    }

 

}