﻿Imports System.Data.Odbc

Module mod_connection
    Public Sub connectMe()
        If con.State = System.Data.ConnectionState.Open Then con.Close()
        constring = "driver=MySQL ODBC 5.3 ANSI Driver;localhost;port=3306;uid='root';pwd=;database=inventory_db"
        con.ConnectionString = constring
        con.Open()
    End Sub
End Module
