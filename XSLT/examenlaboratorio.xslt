<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <header>
        <style>
          .estilo_table {

          font-family: Consolas,monaco,monospace;
          border-radius: 15px;
          -moz-border-radius: 15px;
          -webkit-border-radius: 15px;
          border: 1px solid #C0C0C0;

          }
          .estilo_table th {
          border:0px solid #C0C0C0;
          padding:5px;
          background:#F0F0F0;
          border-radius : 20px 15px 10px 5px;
          }
          .estilo_table td {
          border:0px solid #C0C0C0;
          padding:5px;
          border-radius : 20px 15px 10px 5px;

          }
        </style>
      </header>
      <body>

        
        <table class="estilo_table"  width="100%">
          <caption>
            <h3>
              <marquee>
                Laboratorio
              </marquee>
            </h3>

          </caption>
          <tr>
            <th></th>
            <th>
              Virus
            </th>
            <th>
              Paciente
            </th>
            <th>
              Edad
            </th>
            <th>
              Tratamiento
            </th>
            <th>
              Condición
            </th>
            
          </tr>
          <xsl:for-each select="//raiz/examenes/examen">
            <tr>
              <td>
                <img width="48" height="48" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAMAAACdt4HsAAABRFBMVEUAAADj4+Pm5ubo6Ojr6+vr6+vs7Ozp6enp6enp6enn5+fo6Ojo6Ojp6eno6Ojp6enq6urq6uro6Ojq6uro6Ojo6Ojp6eno6OgAAAADAAATExMuLi4wMDBZWVlbW1tqAABrAAB7e3uZmZmampqbm5ucnJydnZ2enp6fn5+goKChoaGioqKjo6Onp6eoqKipqamrq6usrKytra2xsbGysrK0tLS1tbW2tra5ubm7u7u/v7/AwMDBwcHCwsLDw8PGxsbHx8fIyMjJycnKysrMzMzNzc3Ozs7Q0NDS0tLT09PU1NTV1dXW1tbX19fY2NjZ2dnc3Nzd3d3e3t7f39/g4ODi4uLj4+Pk5OTlAADl5eXm5ubn5+fo6Ojp6enr6+vs7Ozu7u7v7+/w8PDx8fH19fX4+Pj6z8/60ND8/Pz9/f3/AAD///9AWC9+AAAAGHRSTlMACQoLS05PUmhqbG6YmJmZm5ydnfDx8fNnUNZfAAADJUlEQVRYw+1XaVsTMRAuIMh9KGDAe7pF5ahnqUeB0ipCgWrlshARFLWa///dZDbJJrvZ7fbx8ZPOh+x2Mu/bOXLMZjLJApD5M/nHCa5QLgBinOgY3EOl+ARCejqAX6U0SkDpeEr4kEYcFeYB5pebWjGYBi9tawDgVfcB9qsef61JdVv4ZeV5zg4hp176kvHXJKoWzcEWZPE53db9XVhVoOYCJ3ipfq1AvU0YOO2p/8wyLgBifPtC+uMlMqD/8BBtzluMBQSMtc5QnUf2qYT8wQoaSrgpLZwoIUNvbAA+vsacMhcwxOG9vBjfsxj5IJZU3nMzDGH+ReYDAMFIWiTQCAasxYA7ADGYf0luEXLTwLOf2sy1f7D+9xFY9e33CZc9/72KRA/EehAraizGgTn51/JBZmYIsVQHbhfE/sf1q3y/wMcvFHy9UJHgquZDt9MB0NEHeJ9BZyLndEEUP2dm8AZ5qvGc4Rm5rqfE3tx2EIDKoPLhdkBwx6zEPWkcPj8hVELDAZkGwwVhPOpIQUcE1CY4ynZCkG1GCAoVSp+YJYgSqEQ8orRcjBAs7FF6Ki0OSZl9ISYBOWcVciCnTyltLGoCsEX5wNffR0NQoY4YS2II2F1mEwiFm8AMAaxc2QSGbFshKILl9XAVYgkKziQ2eRl30hE0nWWMLCRiEpA2C2lC6p4b+FAVgpl1aTzi2EyfDHwohIDhjWMzRbazMP8R4L+bB4I4vXccBMi6YS5mO4eK4JvzQMEjbYvSE2s3WDVQBCeUboqN15VJOtOIWUlLdRZzro+LPbqis0Ci15KvqojbTTgwHHexHKPdbJRgVt+w7ttxkCvrkaspLMcC/44P/UmXazz+NZ9d8pKuZyjZ16sla8LiVez1nunTDKF9LeVxgL/kblGmEYtRHG4wu8Vhfue0hI/JVE3W5w2DAFI1WZKhLvskSld5mwhfdadYwvwnd6tTfoMnVnW40dyUjeZkcqvaG9PqehIel79os73Nvc+WGwCNcpa/7qZttrkM6O6+WVwEWCwG7X5/yi+GMfcHx3AH3yzdUYKujr+bRgOCkf9frn+V4DcuZyWGw5QAmQAAAABJRU5ErkJggg=="/>
              </td>
              <td>
                <xsl:value-of select="virus" />
              </td>
              <td>
                <xsl:value-of select="paciente" />
              </td>
              <td>
                <xsl:value-of select='format-number(paciente/@edad,"##")' />
              </td>
              <td>
                <xsl:value-of select="tratamiento" />
              </td>
              <td>
                <xsl:value-of select="condicion" />
              </td>
             
            </tr>
          </xsl:for-each>
        </table>
        <br/>
        <table class="estilo_table"  width="100%">
          <tr>
            <td>

              Cantidad <xsl:value-of select="count(//virus)"/>
            </td>
          </tr>

        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>