<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }
    void Session_OnStart(object sender, EventArgs e)
    {
        if (Session.IsNewSession)
            Server.Transfer("~/default.aspx", false);


    }

    void Session_End(object sender, EventArgs e)
    {


        //System.Diagnostics.Debugger.Break();
    }

</script>
