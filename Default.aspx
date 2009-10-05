<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="http://json.org/json2.js" type="text/javascript"></script>



</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul id="taskList"></ul>
    </div>
    </form>
        <script language="javascript">
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    url: "JonteService.asmx/GetTasks",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(data) {
                        // Hide the fake progress indicator graphic.
                        var tasks = JSON.parse(data.d);
                        for (var i = 0; i < tasks.length; i++) {
                            var task = tasks[i]
                            $("ul#taskList").append("<li>" + task.ID + " <b>" + task.Name + "</b> by " + task.Author + " " + task.Done + "</li>");
                        }
                    }
                });

            });
    </script>
</body>
</html>
