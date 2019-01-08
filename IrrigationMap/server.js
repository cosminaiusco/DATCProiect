var express = require('express');
var app = express();

var Connection = require('tedious').Connection;
var Request = require('tedious').Request;

app.get('/', function (req, res) {
  res.render('index');
});

app.set('view engine', 'ejs');

// Loading socket.io
var io = require('socket.io');

var http = require('http');
var server = http.createServer(app).listen(3000);
io = io.listen(server);

// When a client connects, we note it in the console
io.sockets.on("connection",function()
{
  console.log("server receive message");
   queryDatabase();
});

// Create connection to database
var config =
{
    userName: 'cosmina', // update me
    password: 'Mihaela8.', // update me
    server: 'cosmina.database.windows.net', // update me
    options:
    {
        database: 'DATC', //update me
        encrypt: true
    }
}
var connection = new Connection(config);

// Attempt to connect and execute queries if connection goes through
connection.on('connect', function(err)
    {
        if (err)
        {
            console.log(err)
        }
        else
        {
           queryDatabase()
        }
    }
);

function queryDatabase()
{
    console.log('Reading rows from the Table...');

    // Read all rows from table
    var request = new Request(
        "SELECT ID,TIMP,TEMPERATURA,UMIDITATE FROM TABLE2",
        function(err, rowCount, rows)
        {
            console.log(rowCount + ' row(s) returned');
        }
    );

    request.on('row', function(columns) {
          // var results = column.metadata.colName + column.value;
          // console.log(results);
          var ID = columns[0].value;
          var TIMP = columns[1].value;
          var TEMPERATURA = columns[2].value;
          var UMIDITATE = columns[3].value;
          var results = ID+ "," + TIMP + "," +TEMPERATURA + "," +UMIDITATE;
          results=JSON.stringify(results);
          console.log(results);
          io.sockets.emit("message",{ID:ID,TIMP:TIMP,TEMPERATURA:TEMPERATURA,UMIDITATE:UMIDITATE});

    });
    connection.execSql(request);

}
