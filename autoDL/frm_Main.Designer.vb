<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txt_PasteHere = New System.Windows.Forms.TextBox()
        Me.lbl_PasteHere = New System.Windows.Forms.Label()
        Me.grp_Settings = New System.Windows.Forms.GroupBox()
        Me.btn_Settings_SaveIn = New System.Windows.Forms.Button()
        Me.txt_Settings_SaveIn = New System.Windows.Forms.TextBox()
        Me.lbl_Settings_SaveIn = New System.Windows.Forms.Label()
        Me.btn_Download = New System.Windows.Forms.Button()
        Me.tab_LogAndSite = New System.Windows.Forms.TabControl()
        Me.tab_PageLog = New System.Windows.Forms.TabPage()
        Me.txt_Log = New System.Windows.Forms.TextBox()
        Me.tab_PageSite = New System.Windows.Forms.TabPage()
        Me.grp_Settings.SuspendLayout()
        Me.tab_LogAndSite.SuspendLayout()
        Me.tab_PageLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_PasteHere
        '
        Me.txt_PasteHere.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_PasteHere.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PasteHere.Location = New System.Drawing.Point(12, 38)
        Me.txt_PasteHere.Name = "txt_PasteHere"
        Me.txt_PasteHere.Size = New System.Drawing.Size(844, 32)
        Me.txt_PasteHere.TabIndex = 0
        Me.txt_PasteHere.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_PasteHere
        '
        Me.lbl_PasteHere.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_PasteHere.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PasteHere.Location = New System.Drawing.Point(12, 9)
        Me.lbl_PasteHere.Name = "lbl_PasteHere"
        Me.lbl_PasteHere.Size = New System.Drawing.Size(844, 26)
        Me.lbl_PasteHere.TabIndex = 1
        Me.lbl_PasteHere.Text = "Paste URL here:"
        Me.lbl_PasteHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Settings
        '
        Me.grp_Settings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_Settings.Controls.Add(Me.btn_Settings_SaveIn)
        Me.grp_Settings.Controls.Add(Me.txt_Settings_SaveIn)
        Me.grp_Settings.Controls.Add(Me.lbl_Settings_SaveIn)
        Me.grp_Settings.Location = New System.Drawing.Point(12, 76)
        Me.grp_Settings.Name = "grp_Settings"
        Me.grp_Settings.Size = New System.Drawing.Size(844, 48)
        Me.grp_Settings.TabIndex = 2
        Me.grp_Settings.TabStop = False
        Me.grp_Settings.Text = "Settings"
        '
        'btn_Settings_SaveIn
        '
        Me.btn_Settings_SaveIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Settings_SaveIn.Location = New System.Drawing.Point(785, 15)
        Me.btn_Settings_SaveIn.Name = "btn_Settings_SaveIn"
        Me.btn_Settings_SaveIn.Size = New System.Drawing.Size(53, 23)
        Me.btn_Settings_SaveIn.TabIndex = 2
        Me.btn_Settings_SaveIn.Text = "Set"
        Me.btn_Settings_SaveIn.UseVisualStyleBackColor = True
        '
        'txt_Settings_SaveIn
        '
        Me.txt_Settings_SaveIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Settings_SaveIn.Location = New System.Drawing.Point(65, 17)
        Me.txt_Settings_SaveIn.Name = "txt_Settings_SaveIn"
        Me.txt_Settings_SaveIn.ReadOnly = True
        Me.txt_Settings_SaveIn.Size = New System.Drawing.Size(714, 20)
        Me.txt_Settings_SaveIn.TabIndex = 1
        '
        'lbl_Settings_SaveIn
        '
        Me.lbl_Settings_SaveIn.AutoSize = True
        Me.lbl_Settings_SaveIn.Location = New System.Drawing.Point(7, 20)
        Me.lbl_Settings_SaveIn.Name = "lbl_Settings_SaveIn"
        Me.lbl_Settings_SaveIn.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Settings_SaveIn.TabIndex = 0
        Me.lbl_Settings_SaveIn.Text = "Save in..."
        '
        'btn_Download
        '
        Me.btn_Download.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Download.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Download.Location = New System.Drawing.Point(12, 130)
        Me.btn_Download.Name = "btn_Download"
        Me.btn_Download.Size = New System.Drawing.Size(844, 39)
        Me.btn_Download.TabIndex = 4
        Me.btn_Download.Text = "Download"
        Me.btn_Download.UseVisualStyleBackColor = True
        '
        'tab_LogAndSite
        '
        Me.tab_LogAndSite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_LogAndSite.Controls.Add(Me.tab_PageLog)
        Me.tab_LogAndSite.Controls.Add(Me.tab_PageSite)
        Me.tab_LogAndSite.Location = New System.Drawing.Point(12, 175)
        Me.tab_LogAndSite.Name = "tab_LogAndSite"
        Me.tab_LogAndSite.SelectedIndex = 0
        Me.tab_LogAndSite.Size = New System.Drawing.Size(844, 417)
        Me.tab_LogAndSite.TabIndex = 6
        '
        'tab_PageLog
        '
        Me.tab_PageLog.Controls.Add(Me.txt_Log)
        Me.tab_PageLog.Location = New System.Drawing.Point(4, 22)
        Me.tab_PageLog.Name = "tab_PageLog"
        Me.tab_PageLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PageLog.Size = New System.Drawing.Size(836, 391)
        Me.tab_PageLog.TabIndex = 0
        Me.tab_PageLog.Text = "Log"
        Me.tab_PageLog.UseVisualStyleBackColor = True
        '
        'txt_Log
        '
        Me.txt_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_Log.Location = New System.Drawing.Point(3, 3)
        Me.txt_Log.Multiline = True
        Me.txt_Log.Name = "txt_Log"
        Me.txt_Log.ReadOnly = True
        Me.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_Log.Size = New System.Drawing.Size(830, 385)
        Me.txt_Log.TabIndex = 3
        Me.txt_Log.WordWrap = False
        '
        'tab_PageSite
        '
        Me.tab_PageSite.Location = New System.Drawing.Point(4, 22)
        Me.tab_PageSite.Name = "tab_PageSite"
        Me.tab_PageSite.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PageSite.Size = New System.Drawing.Size(836, 391)
        Me.tab_PageSite.TabIndex = 1
        Me.tab_PageSite.Text = "Site"
        Me.tab_PageSite.UseVisualStyleBackColor = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 604)
        Me.Controls.Add(Me.tab_LogAndSite)
        Me.Controls.Add(Me.btn_Download)
        Me.Controls.Add(Me.grp_Settings)
        Me.Controls.Add(Me.lbl_PasteHere)
        Me.Controls.Add(Me.txt_PasteHere)
        Me.Name = "frm_Main"
        Me.Text = "autoDL"
        Me.grp_Settings.ResumeLayout(False)
        Me.grp_Settings.PerformLayout()
        Me.tab_LogAndSite.ResumeLayout(False)
        Me.tab_PageLog.ResumeLayout(False)
        Me.tab_PageLog.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_PasteHere As TextBox
    Friend WithEvents lbl_PasteHere As Label
    Friend WithEvents grp_Settings As GroupBox
    Friend WithEvents btn_Settings_SaveIn As Button
    Friend WithEvents txt_Settings_SaveIn As TextBox
    Friend WithEvents lbl_Settings_SaveIn As Label
    Friend WithEvents btn_Download As Button
    Friend WithEvents tab_LogAndSite As TabControl
    Friend WithEvents tab_PageLog As TabPage
    Friend WithEvents txt_Log As TextBox
    Friend WithEvents tab_PageSite As TabPage
End Class
