<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" version='1.0' encoding='UTF-8' indent='yes'/>

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <head>
      <style>
        ul{ list-style-type:none}
      </style>
    </head>
    <html>
      <body style="font-family: sans-serif;font-size:12px;background-color:#C0C0C0">
        <ul>
          <xsl:for-each select="/Students/class/student">
            <li>
              <h3>
                Info about: <xsl:value-of select="name"/>
              </h3>
              <ul>
                <li>
                  GENDER: <xsl:value-of select="gender"/>
                </li>
                <li>
                  DATE OF BIRTH: <xsl:value-of select="birth-date"/>
                </li>
                <li>
                  PHONE: <xsl:value-of select="phone"/>
                </li>
                <li>
                  E-MAIL: <xsl:value-of select="e-mail"/>
                </li>
                <li>
                  COURSE: <xsl:value-of select="course"/>
                </li>
                <li>
                  SPECIALTY: <xsl:value-of select="specialty"/>
                </li>
                <li>
                  FACULTY NUMBER: <xsl:value-of select="faculty-number"/>
                </li>
                <li>
                  <h4>
                    Taken exams:
                  </h4>
                </li>
                <li>
                  <xsl:for-each select="taken-exams/exam">
                    <ul>
                      <li>
                        Exam name: <xsl:value-of select="exam-name"/>
                      </li>
                      <li>
                        Exam score: <xsl:value-of select="exam-score"/>
                      </li>
                    </ul>
                  </xsl:for-each>
                </li>
                <li>
                  <h4>
                    Enrollement info:
                  </h4>
                </li>
                <li>
                  <xsl:for-each select="enrollment-info/enrolled">
                    <ul>
                      <li>
                        Enrollment date: <xsl:value-of select="date"/>
                      </li>
                      <li>
                        Enrollment score: <xsl:value-of select="enrollment-score"/>
                      </li>
                    </ul>
                  </xsl:for-each>
                </li>
                <li>
                  <h4>
                    Endorsed by:
                  </h4>
                </li>
                <li>
                  <ul>
                    <xsl:for-each select="teacher-endorsement/endorsed-by">
                      <li>
                        Endorsed by: <xsl:value-of select="name"/>
                      </li>
                    </xsl:for-each>
                  </ul>
                </li>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
