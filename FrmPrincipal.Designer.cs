namespace SistemaMaterialesConstruccion.Formularios
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnucambiarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnucerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnucategorías = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuproductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuclientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuproveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuusuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnucompras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuventas = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPrincipal = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioSistema = new System.Windows.Forms.Label();
            this.lblRolSistema = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.mantenimientosToolStripMenuItem,
            this.procesosToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnucambiarUsuario,
            this.mnucerrarSesion,
            this.mnusalir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnucambiarUsuario
            // 
            this.mnucambiarUsuario.Name = "mnucambiarUsuario";
            this.mnucambiarUsuario.Size = new System.Drawing.Size(224, 26);
            this.mnucambiarUsuario.Text = "Cambiar Usuario";
            // 
            // mnucerrarSesion
            // 
            this.mnucerrarSesion.Name = "mnucerrarSesion";
            this.mnucerrarSesion.Size = new System.Drawing.Size(224, 26);
            this.mnucerrarSesion.Text = "Cerrar Sesion";
            this.mnucerrarSesion.Click += new System.EventHandler(this.mnucerrarSesion_Click);
            // 
            // mnusalir
            // 
            this.mnusalir.Name = "mnusalir";
            this.mnusalir.Size = new System.Drawing.Size(224, 26);
            this.mnusalir.Text = "Salir";
            this.mnusalir.Click += new System.EventHandler(this.mnusalir_Click);
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnucategorías,
            this.mnuproductos,
            this.mnuclientes,
            this.mnuproveedores,
            this.mnuusuarios});
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // mnucategorías
            // 
            this.mnucategorías.Name = "mnucategorías";
            this.mnucategorías.Size = new System.Drawing.Size(174, 26);
            this.mnucategorías.Text = "Categorías";
            this.mnucategorías.Click += new System.EventHandler(this.mnucategorías_Click);
            // 
            // mnuproductos
            // 
            this.mnuproductos.Name = "mnuproductos";
            this.mnuproductos.Size = new System.Drawing.Size(174, 26);
            this.mnuproductos.Text = "Productos";
            this.mnuproductos.Click += new System.EventHandler(this.mnuproductos_Click);
            // 
            // mnuclientes
            // 
            this.mnuclientes.Name = "mnuclientes";
            this.mnuclientes.Size = new System.Drawing.Size(174, 26);
            this.mnuclientes.Text = "Clientes";
            this.mnuclientes.Click += new System.EventHandler(this.mnuclientes_Click);
            // 
            // mnuproveedores
            // 
            this.mnuproveedores.Name = "mnuproveedores";
            this.mnuproveedores.Size = new System.Drawing.Size(174, 26);
            this.mnuproveedores.Text = "Proveedores";
            this.mnuproveedores.Click += new System.EventHandler(this.mnuproveedores_Click);
            // 
            // mnuusuarios
            // 
            this.mnuusuarios.Name = "mnuusuarios";
            this.mnuusuarios.Size = new System.Drawing.Size(174, 26);
            this.mnuusuarios.Text = "Usuarios";
            this.mnuusuarios.Click += new System.EventHandler(this.mnuusuarios_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnucompras,
            this.mnuventas});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // mnucompras
            // 
            this.mnucompras.Name = "mnucompras";
            this.mnucompras.Size = new System.Drawing.Size(151, 26);
            this.mnucompras.Text = "Compras";
            this.mnucompras.Click += new System.EventHandler(this.mnucompras_Click);
            // 
            // mnuventas
            // 
            this.mnuventas.Name = "mnuventas";
            this.mnuventas.Size = new System.Drawing.Size(151, 26);
            this.mnuventas.Text = "Ventas";
            this.mnuventas.Click += new System.EventHandler(this.mnuventas_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);
            // 
            // statusPrincipal
            // 
            this.statusPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusPrincipal.Location = new System.Drawing.Point(0, 428);
            this.statusPrincipal.Name = "statusPrincipal";
            this.statusPrincipal.Size = new System.Drawing.Size(800, 22);
            this.statusPrincipal.TabIndex = 2;
            this.statusPrincipal.Text = "statusStrip1";
            // 
            // lblUsuarioSistema
            // 
            this.lblUsuarioSistema.AutoSize = true;
            this.lblUsuarioSistema.Location = new System.Drawing.Point(41, 434);
            this.lblUsuarioSistema.Name = "lblUsuarioSistema";
            this.lblUsuarioSistema.Size = new System.Drawing.Size(57, 16);
            this.lblUsuarioSistema.TabIndex = 3;
            this.lblUsuarioSistema.Text = "Usuario:";
            // 
            // lblRolSistema
            // 
            this.lblRolSistema.AutoSize = true;
            this.lblRolSistema.Location = new System.Drawing.Point(572, 434);
            this.lblRolSistema.Name = "lblRolSistema";
            this.lblRolSistema.Size = new System.Drawing.Size(13, 16);
            this.lblRolSistema.TabIndex = 4;
            this.lblRolSistema.Text = "  ";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(572, 434);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 16);
            this.lblRol.TabIndex = 7;
            this.lblRol.Text = "Rol:";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.lblRolSistema);
            this.Controls.Add(this.lblUsuarioSistema);
            this.Controls.Add(this.statusPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Materiales de Construcción";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnucambiarUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnucerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnusalir;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnucategorías;
        private System.Windows.Forms.ToolStripMenuItem mnuproductos;
        private System.Windows.Forms.ToolStripMenuItem mnuclientes;
        private System.Windows.Forms.ToolStripMenuItem mnuproveedores;
        private System.Windows.Forms.ToolStripMenuItem mnuusuarios;
        private System.Windows.Forms.ToolStripMenuItem mnucompras;
        private System.Windows.Forms.ToolStripMenuItem mnuventas;
        private System.Windows.Forms.StatusStrip statusPrincipal;
        private System.Windows.Forms.Label lblUsuarioSistema;
        private System.Windows.Forms.Label lblRolSistema;
        private System.Windows.Forms.Label lblRol;
    }
}