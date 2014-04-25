using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

public partial class agenda : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class Eventos
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string date_num { get; set; }
        public string hora_ini { get; set; }
        public string hora_fin { get; set; }
        public string fecha { get; set; }
        public string type_event { get; set; }
        public string desc_id { get; set; }
        public string expositor { get; set; }

    }

    public class Sesiones
    {

        public string id { get; set; }
        public string nombre { get; set; }
        public string salon { get; set; }
        public string invitados { get; set; }
        public string id_evento { get; set; }
        public string session { get; set; }

    }

    [WebMethod]
    public static string GetAgenda(int day)
    {

        string result = "";
        string Evento = "";
        string resultado = getDatosEvento(day);

        if (day == 1)
        {
            Evento = "<div id=\"event" + day + "\"><div class=\"row-fluid\"><div class=\"span12 agenda-date\">MONDAY, MARCH 24<sup>th</sup>, 2014</div></div><div class=\"row-fluid agenda-title hidden-phone\"><div class=\"span4\">TIME</div><div class=\"span8\">SESSION</div></div>";
        }
        else if (day == 2)
        {
            Evento = "<div id=\"event" + day + "\"><div class=\"row-fluid\"><div class=\"span12 agenda-date\">TUESDAY, MARCH 25<sup>th</sup>, 2014</div></div><div class=\"row-fluid agenda-title hidden-phone\"><div class=\"span4\">TIME</div><div class=\"span8\">SESSION</div></div>";
        }
        else if (day == 3)
        {
            Evento = "<div id=\"event" + day + "\"><div class=\"row-fluid\"><div class=\"span12 agenda-date\">WEDNESDAY, MARCH 26<sup>th</sup>, 2014</div></div><div class=\"row-fluid agenda-title hidden-phone\"><div class=\"span4\">TIME</div><div class=\"span8\">SESSION</div></div>";
        }
        else if (day == 4)
        {
            Evento = "<div id=\"event" + day + "\"><div class=\"row-fluid\"><div class=\"span12 agenda-date\">THURSDAY, MARCH 27<sup>th</sup>, 2014</div></div><div class=\"row-fluid agenda-title hidden-phone\"><div class=\"span4\">TIME</div><div class=\"span8\">SESSION</div></div>";
        }


        var serializer = new JavaScriptSerializer();
        int i = 1;

        List<Eventos> values = serializer.Deserialize<List<Eventos>>(resultado);
        foreach (var root in values)
        {
            //validar para que se arme por dias, aca me estan llegando todos los Eventos y necesito armar dia  a dia;
            if (root.type_event == "Event")
            {
                Evento = Evento + ArmarEvento(root.nombre, root.date_num, root.hora_ini, root.hora_fin, root.fecha, root.type_event, i, root.desc_id, root.expositor);
            }
            else if (root.type_event == "Title")
            {
                Evento = Evento + ArmarTitle(root.nombre);
            }
            else if (root.type_event == "Sessions")
            {
                Evento = Evento + ArmarSession(root.id, i, root.nombre, root.hora_ini, root.hora_fin, root.date_num);
            }
            i += 1;

        }

        result = Evento + "</div>";
        return result;

    }

    public static string ArmarEvento(string nombre, string date, string hora_ini, string hora_fin, string fecha, string type_s, int i, string desc_id, string expositor)
    {
        string Evento = "";
        string clase = "";
        if (i % 2 == 0)
        {
            clase = "row-fluid agenda-oscuro";
        }
        else
        {
            clase = "row-fluid agenda-claro";
        }

        if ((desc_id == "") || (desc_id == null))
        {
            Evento = "<div class=\"" + clase + "\"><div class=\"span4\">" + hora_ini + " - " + hora_fin + "</div><div class=\"span8\"><strong>" + nombre + "</strong></div></div>";
        }
        else
        {
            // <div class="row-fluid agenda-claro">            <div class="span4">8:40 AM - 9:00 AM</div>            <div class="span8"><a class="inline" href="#session27">Direction Forward, Avaya Networking Strategy  - <em>Marc Randall, Avaya</a></em></div>           </div>
            Evento = "<div class=\"" + clase + "\"><div class=\"span4\">" + hora_ini + " - " + hora_fin + "</div><div class=\"span8\"><a class=\"inline\" href=\"#" + desc_id + "\">" + nombre + " - <em>" + expositor + "</a></em></div></div>";
        }

        return Evento;
    }

    public static string ArmarTitle(string nombre)
    {

        string Evento = "<div class=\"row-fluid agenda-title\"><div class=\"span8 offset4 agenda-subtitle\">" + nombre + "</div></div>";
        return Evento;
    }

    public static string ArmarSession(string id_event, int i, string nombre, string hora_ini, string hora_fin, string date)
    {
        string clase;

        //if (i % 2 == 0) {
        //    clase = "row-fluid agenda-oscuro";
        //}
        //else {
        //    clase = "row-fluid agenda-claro";
        //}

        clase = "row-fluid agenda-claro";

        string Evento = "<div class=\"" + clase + "\"><div class=\"span12 visible-phone\">" + hora_ini + " - " + hora_fin + " </div><table><tr><td class=\"span4 hidden-phone\">" + hora_ini + " - " + hora_fin + " </td><td class=\"span8\"><table class=\"table table-bordered\" id=\"Session" + id_event + "\"><div class=\"row\">";

        Evento += "<tr><td>&nbsp;</td><td class=\"span8\"><strong>" + nombre + "</strong></td><!--<td><strong></strong></td>--></tr>";

        string sessiones = getDatosSessiones(id_event);

        var serializer = new JavaScriptSerializer();

        int registrados = 0;
        List<Sesiones> values = serializer.Deserialize<List<Sesiones>>(sessiones);
        foreach (var root in values)
        {
            root.id = root.id.Trim();
            registrados = getRegistradoSession(root.id);
            if (registrados <= Convert.ToInt32(root.invitados))
            {
                if (root.id != "48")
                {
                    Evento += "<tr><td><input type=\"radio\" name=\"event" + date + i + "\" id=\"" + root.id + "\"/></td><td class=\"span8\" style=\"padding-left: 30px;\"><strong style=\"color: #CC0000;\">" + root.salon + "</strong><br><a class=\"inline\" href=\"#" + root.session + "\">" + root.nombre + "</td><!--<td class=\"span4\"></td>--></tr></tr>";
                }
            }
            else
            {
                Evento += "<tr><td><p>We are sorry, this registration is closed.  <p/></td><td class=\"span8\" style=\"padding-left: 30px;\"><strong style=\"color: #CC0000;\">" + root.salon + "</strong><br><a class=\"inline\" href=\"#" + root.session + "\">" + root.nombre + "</td><!--<td class=\"span4\"></td>--></tr></tr>";
            }
        }

        Evento += "</div></table></td></tr></table></div>";

        return Evento;
    }


    public static string DataTableToJSON(DataTable table)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        foreach (DataRow row in table.Rows)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (DataColumn col in table.Columns)
            {
                dict[col.ColumnName] = row[col];
            }
            list.Add(dict);
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(list);
    }

    [WebMethod]
    public static int getRegistradoSession(string id)
    {
        int resultado;
        int id_session = Convert.ToInt32(id);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();
        string strSQL = "select count(id_session) from Tbl_ATF_registrados_session where id_session = @id_session";

        SqlCommand cmd = new SqlCommand(strSQL, con);

        cmd.Parameters.Add("@id_session", SqlDbType.Int);
        cmd.Parameters["@id_session"].Value = id_session;

        try
        {
            con.Open();
            resultado = (Int32)cmd.ExecuteScalar();
            con.Close();

        }
        catch (Exception ex)
        {
            resultado = -1;
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return resultado;

    }


    [WebMethod]
    public static string getDatosEvento(int day)
    {
        string result;
        SqlDataReader datos;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();
        string strSQL = "select  id,nombre,date_num,hora_ini ,hora_fin ,fecha,type_event,desc_id,expositor from Cala_Web.Tbl_AFT_Event where date_num =" + day;
        SqlCommand cmd = new SqlCommand(strSQL, con);
        try
        {
            con.Open();
            datos = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datos);
            result = DataTableToJSON(dt);
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = "";
        }
        finally
        {
            con.Close();
        }
        return result;
    }

    [WebMethod]
    public static string getDatosSessiones(string id)
    {
        int id_evento = Convert.ToInt32(id);
        string result;
        SqlDataReader datos;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();
        string strSQL = "select id,nombre,salon ,invitados ,id_evento, session from Cala_Web.Tbl_AFT_Sessions where id_evento = " + id_evento;
        SqlCommand cmd = new SqlCommand(strSQL, con);
        try
        {
            con.Open();
            datos = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datos);
            result = DataTableToJSON(dt);
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = "";
        }
        finally
        {
            con.Close();
        }
        return result;
    }

    [WebMethod]
    public static string validateEmail(string email)
    {

        string resultado = "";
        string usuario;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();

        string strSQL = "SELECT distinct email from Tbl_ATF where email = '" + email + "'";
        SqlCommand cmd = new SqlCommand(strSQL, con);
        try
        {
            con.Open();
            usuario = (String)cmd.ExecuteScalar();
            con.Close();
            if (usuario == null)
            {
                resultado = "fail";
            }
            else
            {
                resultado = "ok";
            }
        }
        catch (Exception ex)
        {
            resultado = "fail";
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return resultado;
    }

    [WebMethod]
    public static string validaRegistroCalendar(string email)
    {

        string resultado = "";
        string usuario;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();

        string strSQL = "SELECT distinct usuario from Tbl_ATF_registrados_session where usuario = '" + email + "'";
        SqlCommand cmd = new SqlCommand(strSQL, con);
        try
        {
            con.Open();
            usuario = (String)cmd.ExecuteScalar();
            con.Close();
            if (usuario == null)
            {
                resultado = "fail";
            }
            else
            {
                resultado = "ok";
            }
        }
        catch (Exception ex)
        {
            resultado = "fail";
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return resultado;
    }





    [WebMethod]
    public static string getIdSessions()
    {
        string result;
        SqlDataReader datos;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();
        string strSQL = "select  id from Cala_Web.Tbl_AFT_Event where type_event = 'Sessions'";
        SqlCommand cmd = new SqlCommand(strSQL, con);
        try
        {
            con.Open();
            datos = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(datos);
            result = DataTableToJSON(dt);
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = "";
        }
        finally
        {
            con.Close();
        }
        return result;
    }


    [WebMethod]
    public static string registrarDatos(string datos, string email)
    {
        string respuesta = "";
        string[] words = datos.Split(',');
        foreach (string word in words)
        {

            respuesta = registrarEvento(word, email);
        }

        if (respuesta == "ok")
        {
            sendMails(email);
        }
        return respuesta;
    }

    [WebMethod]
    public static string registrarEvento(string session, string email)
    {
        int sessiones = Convert.ToInt32(session);
        string result = "";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["calawebConnectionString"].ToString();

        //Se envian los datos a la consulta por parametro y no concatenandolos directamente para evitar inyección de código :D           
        string stmt = "INSERT INTO Cala_Web.Tbl_ATF_registrados_session (usuario, id_session) VALUES (@email, @session)";

        SqlCommand cmd2 = new SqlCommand(stmt, con);

        cmd2.Parameters.Add("@email", SqlDbType.VarChar, 100);
        cmd2.Parameters.Add("@session", SqlDbType.Int);

        cmd2.Parameters["@email"].Value = email;
        cmd2.Parameters["@session"].Value = sessiones;


        try
        {
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
            result = "ok";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = "fail";
        }
        finally
        {
            con.Close();
        }

        return result;
    }

    public static string sendMails(string correo)
    {
        string result = "";
        string title = "Avaya ATF";
        try
        {
            //string contenido = getContenidoMail(nombre, observacion);
            string plantilla = getPlantilla();
            string rta_mail = SendMail(correo, "e-marketing@avaya.com", title, plantilla);

            result = "ok";
        }
        catch (Exception ex)
        {
            result = "false" + ex;
        }
        return result;
    }

    public static string SendMail(string to, string from, string subject, string contenido)
    {
        string respuesta = "";

        MailAddress sendfrom = new MailAddress(from);
        MailAddress sendto = new MailAddress(to);
        MailMessage message = new MailMessage();

        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
        string body = HttpUtility.HtmlDecode(contenido);
        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
        message.AlternateViews.Add(alternate);

        message.From = new MailAddress(from);
        message.To.Add(to);
        message.Subject = subject;

        SmtpClient client = new SmtpClient("localhost");

        try
        {
            client.Send(message);
            respuesta = "ok";

        }
        catch (SmtpException e)
        {
            respuesta = "fail";
            throw new SmtpException(e.Message);

        }
        return respuesta;
    }

    public static string getContenidoMail(string nombre, string observacion)
    {
        string plantilla = getPlantilla();

        Dictionary<string, string> dataIndex = new Dictionary<string, string>();
        dataIndex.Add("{nombre}", nombre);
        dataIndex.Add("{evento}", observacion);

        string buscar = "";
        string reemplazar = "";
        string index = "";
        //Recorrer la plantilla del index para reemplazar el contenido
        foreach (var datos in dataIndex)
        {
            buscar = datos.Key;
            reemplazar = datos.Value;
            index = plantilla.Replace(buscar, reemplazar);
            plantilla = index;
        }

        return plantilla;
    }

    public static string getPlantilla()
    {
        string fullPath = HttpContext.Current.Server.MapPath("~");

        string html = "";
        html = File.ReadAllText(fullPath + "\\ATF-conf-agenda.html");
        //html = File.ReadAllText(fullPath + "\\usa\\events\\ATF-2014\\ATF-ty-reg.html");
        return html;
    }


}

