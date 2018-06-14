USE SIGESU;

DROP PROCEDURE IF EXISTS CalificacionCliente_Q02; 
delimiter &&
CREATE Procedure CalificacionCliente_Q02 (IN P_ID_Cliente INTEGER)
-- ===============================================================  
-- Propósito: Buscar Calificacion de Cliente
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente 		-> Código de Cliente
-- ===============================================================   
Begin
	If (P_ID_Cliente = 0) Then
		Select id, id_cliente, calificacion_crediticia, linea_credito,
		sueldo_cliente, otros_ingresos_cliente, estado_calificacion_cliente, usuario_grabacion, 
		fecha_grabacion, ventana_grabacion
		From calificacion_cliente;
	Else 
		Select id, id_cliente, calificacion_crediticia, linea_credito,
		sueldo_cliente, otros_ingresos_cliente, estado_calificacion_cliente, usuario_grabacion, 
		fecha_grabacion, ventana_grabacion
		From calificacion_cliente
		Where id_cliente = p_id_cliente;
	End If;
End &&
delimiter ;
-- CALL CALIFICACIONCLIENTE_Q02 (0);

DROP PROCEDURE IF EXISTS Categoria_Q01; 
delimiter &&
CREATE PROCEDURE Categoria_Q01()
-- ===============================================================  
-- Propósito: Cargar Categorias
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
-- ===============================================================  
Begin
	Select id, nombre_categoria
	From  categoria_canje;
End &&
delimiter ;
--  CALL Categoria_Q01;

DROP PROCEDURE IF EXISTS Cliente_Q01; 
delimiter &&
CREATE PROCEDURE Cliente_Q01 (IN P_Docu_Iden INTEGER)
-- ===============================================================  
-- Propósito: Buscar Datos de Cliente
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_docu_iden 		-> Número de Documento de Identidad
-- ===============================================================  
Begin
	Select id, nombre_completo, apellido_paterno, apellido_materno,
	tipo_documento, numero_documento, fecha_nacimiento, sexo,
	email, direccion, telefono_fijo, telefono_movil,
	situacion_laboral, estado_cliente, indicador_tarjeta, tarjeta_vclub
	From cliente_afiliado
    Where numero_documento Like CONCAT('%', P_Docu_Iden, '%');
End &&
delimiter ;
-- CALL Cliente_Q01(45);

DROP PROCEDURE IF EXISTS Historial_Compra_Q01; 
delimiter &&
CREATE PROCEDURE Historial_Compra_Q01 (IN P_Id_Cliente INTEGER)
-- ===============================================================  
-- Propósito: Buscar Historial de Compras
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente 		-> Código de Cliente
-- ===============================================================   
Begin
	If (P_Id_Cliente = 0) Then
		Select id_cliente_historial, id_producto_historial, id_categoria_historial, importe_compra, fecha_compra
	    From   historial_compra;
	ELSE
		Select id_cliente_historial, id_producto_historial, id_categoria_historial, importe_compra, fecha_compra
	    From   historial_compra
		Where  id = P_Id_Cliente;
	End If;
End &&
delimiter ;
--  CALL Historial_Compra_Q01(0);

DROP PROCEDURE IF EXISTS Infocorp_Q03;
delimiter &&
CREATE Procedure Infocorp_Q03 (IN P_Id_Cliente INTEGER)
-- ===============================================================  
-- Propósito: Buscar Datos de Infocorp
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente 		-> Código de Cliente
-- ===============================================================   
Begin
	If (P_Id_Cliente = 0) Then
		Select id, entidad_financiera, importe_deuda, calificacion_sbs
		From infocorp;
	Else
	    Select id, entidad_financiera, importe_deuda, calificacion_sbs
		From infocorp
		Where id = P_Id_Cliente;
	END IF;
END &&
delimiter ;
-- CALL Infocorp_Q03(4);

DROP PROCEDURE IF EXISTS Producto_Q01;
delimiter &&
CREATE Procedure Producto_Q01 (IN P_Id_Producto INTEGER)
-- ===============================================================  
-- Propósito: Buscar Datos de Producto
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_producto 		-> Código de Producto
-- ===============================================================   
Begin
	If (P_Id_Producto = 0) Then
		Select t2.id 'id_producto', t2.nom_prod_canj, t2.descripcion_producto, t2.dir_ruta 'imagen', 
		t2.valor, t1.stock, t2.condicion_canje -- t2.id_categoria_producto 'codigo categoria', t3.nombre_categoria 'desc. categoria'
		From stock_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id and t2.id_categoria_producto = t1.id_stock_categoria )
		inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		Order by t1.id_stock_categoria;
	Else
		Select t2.id 'id_producto', t2.nom_prod_canj, t2.descripcion_producto, t2.dir_ruta 'imagen', 
		t2.valor, t1.stock, t2.condicion_canje -- t2.id_categoria_producto 'codigo categoria', t3.nombre_categoria 'desc. categoria'
		From stock_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id and t2.id_categoria_producto = t1.id_stock_categoria )
		inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		Where t1.id = P_Id_Producto
		Order By t1.id_stock_categoria;
	End If;
End&&
delimiter ;
--  CALL P_Id_Producto(5); 

DROP PROCEDURE IF EXISTS Productos_x_Catalogo_Q01;
delimiter &&
CREATE Procedure Productos_x_Catalogo_Q01 (IN P_Id_Catalogo INTEGER)
-- ===============================================================  
-- Propósito: Buscar Catalogos de Producto
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_catalogo 		-> Código de Catálogo
-- ===============================================================   
Begin
	If (P_Id_Catalogo = 0) Then
		Select t1.id_producto_canje 'codigo producto canje', t2.nom_prod_canj 'desc. producto canje', t1.id_categoria_canje 'codigo categoria', t3.nombre_categoria 'desc. categoria',
		t2.valor 'puntos canje', case when t2.tipo_canje = 1 then 'producto' else 'servicio' end 'tipo producto', t2.condicion_canje 'condiciones producto canje'
		from catalogo_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id_producto_canje and t2.id_categoria_producto = t1.id_categoria_canje )
		inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		-- Where month(t1.fecha_inicial_catalogo) = month (current_timestamp) or month(t1.fecha_final_catalogo) = month (current_timestamp)
		Order by t1.id_categoria_canje, t1.id_producto_canje;
	Else
        Select t1.id_producto_canje 'codigo producto canje', t2.nom_prod_canj 'desc. producto canje', t1.id_categoria_canje 'codigo categoria', t3.nombre_categoria 'desc. categoria',
		t2.valor 'puntos canje', case when t2.tipo_canje = 1 then 'producto' else 'servicio' end 'tipo producto', t2.condicion_canje 'condiciones producto canje'
		from catalogo_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id_producto_canje and t2.id_categoria_producto = t1.id_categoria_canje )
		inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		Where t1.id = P_Id_Catalogo
		Order by t1.id_categoria_canje, t1.id_producto_canje;
	End If;
End&&
delimiter ;
--  CALL PRODUCTOS_X_CATALOGO_Q01(1); 

DROP PROCEDURE IF EXISTS Stock_x_Producto_Q01;
delimiter &&
CREATE Procedure Stock_x_Producto_Q01 (IN P_Id_Producto INTEGER)
-- ===============================================================  
-- Propósito: Buscar Datos de Producto
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_producto 		-> Código de Producto
-- ===============================================================   
Begin
	If (P_Id_Producto = 0) Then 
		Select t2.id 'codigo producto canje', t2.dir_ruta 'imagen', t2.valor 'puntos canje', t1.stock 'stock',
		t2.nom_prod_canj 'desc. producto canje', t2.id_categoria_producto 'codigo categoria', t3.nombre_categoria 'desc. categoria'
		From stock_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id_stock_producto and t2.id_categoria_producto = t1.id_stock_categoria )
		Inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		Order by t1.id_stock_producto;
	Else
		Select t2.id 'codigo producto canje', t2.dir_ruta 'imagen', t2.valor 'puntos canje', t1.stock 'stock',
		t2.nom_prod_canj 'desc. producto canje', t2.id_categoria_producto 'codigo categoria', t3.nombre_categoria 'desc. categoria'
		From stock_canje t1 inner join producto_canje t2 on
		( t2.id = t1.id_stock_producto and t2.id_categoria_producto = t1.id_stock_categoria )
		Inner join categoria_canje t3 on
		( t3.id = t2.id_categoria_producto )
		Where t1.id = P_Id_Producto
		Order By t1.id_stock_producto;
	End If;
End&&
delimiter ;
-- CALL Stock_x_Producto_Q01(5); 

DROP PROCEDURE IF EXISTS TarjetaOh_I01;
delimiter &&
CREATE Procedure TarjetaOh_I01 (IN P_Id_Tarjeta INTEGER, IN P_Id_Cliente INTEGER, IN P_Tipo_Tarjeta VARCHAR(20), IN P_Num_Tarjeta INTEGER, IN P_Bin_Tarjeta VARCHAR(10))
-- ===============================================================  
-- Propósito: Registrar Tarjeta OH
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_tarjeta 		-> Código de Tarjeta Oh
--    p_id_cliente      -> Código de Cliente
--    p_tipo_tarjeta    -> Tipo de Tarjeta
--    p_num_tarjeta     -> Número de Tarjeta
--    p_bin_tarjeta     -> Bin de Tarjeta
-- ===============================================================   
Begin
	Insert into tarjetaoh (id, id_tarjeta_cliente, tipo_tarjeta, numero_tarjeta,
		bin_tarjeta, usuario_grabacion, fecha_grabacion, ventana_grabacion)
	Values
	   (p_id_tarjeta, p_id_cliente, p_tipo_tarjeta ,p_num_tarjeta, p_bin_tarjeta,'admin', current_timestamp,'System');
End&&
delimiter ;

DROP PROCEDURE IF EXISTS TarjetaOh_Q01;
delimiter &&
CREATE PROCEDURE TarjetaOh_Q01 (IN P_Id_Cliente INTEGER)
-- ===============================================================  
-- Propósito: Buscar Datos de Tarjeta Oh
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente 		-> Código de Cliente
-- ===============================================================    
Begin
	If (P_Id_Cliente = 0) Then
		Select id, id_tarjeta_cliente, tipo_tarjeta, numero_tarjeta,
		bin_tarjeta
		From tarjetaoh;
	Else
	    Select id, id_tarjeta_cliente, tipo_tarjeta, numero_tarjeta,
		bin_tarjeta
		From tarjetaoh
		Where id_tarjeta_cliente = P_Id_Cliente;
	End If;
End&&
delimiter ;
-- CALL TarjetaOh_Q01 (1);

DROP PROCEDURE IF EXISTS TarjetaOh_Solicitud_I02;
delimiter &&
CREATE PROCEDURE TarjetaOh_Solicitud_I02 (IN P_Id_Cliente INTEGER, IN P_Tipo_Tarjeta VARCHAR(20), IN P_Num_Tarjeta BIGINT(20))
-- ===============================================================  
-- Propósito: Actualizar Tarjeta OH
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente      -> Código de Cliente
--    p_tipo_tarjeta    -> Tipo de Tarjeta
--    p_num_tarjeta     -> Número de Tarjeta
-- ===============================================================  
Begin
	Update tarjetaoh
	   Set fecha_grabacion = current_timestamp, tipo_tarjeta = P_Tipo_Tarjeta -- , est_tarj = 1
	Where numero_tarjeta = P_Num_Tarjeta;

	Update solicitud_afiliacion
	   Set estado_solicitud = 'Aprobado', fecha_grabacion = current_timestamp
	Where numero_identidad = p_Id_Cliente;
End&&
delimiter ;

DROP PROCEDURE IF EXISTS Solicitud_DesaprobadaI03;
delimiter &&
CREATE PROCEDURE Solicitud_DesaprobadaI03 (IN P_Id_Cliente INTEGER)
-- ===============================================================  
-- Propósito: Actualizar Solicitud Afiliacion
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_id_cliente      -> Código de Cliente
-- ===============================================================  
Begin
	Update solicitud_afiliacion
	  Set estado_solicitud ='Desaprobado', fecha_grabacion = current_timestamp
	Where numero_identidad = p_id_cliente;
End&&
delimiter ;

DROP PROCEDURE IF EXISTS Estado_Solicitud;
delimiter &&
CREATE PROCEDURE Estado_Solicitud (IN P_Num_Docu_Iden VARCHAR(10))
-- ===============================================================  
-- Propósito: Buscar Solicitud por Estado
-- Autor: Jeison Juarez		Fecha: 01/06/2018
-- ---------------------------------------------------------------
-- Datos Relevantes:
--    p_num_docu_iden     -> Número de Documento de Identidad
-- ===============================================================  
Begin
	Select estado_solicitud
	From solicitud_afiliacion
	Where numero_identidad = p_Num_Docu_Iden;
End&&
delimiter ;


/*CUS Actualizar Clientes*/
DROP PROCEDURE IF EXISTS LISTAR_CLIENTES;
CREATE DEFINER=`root`@`localhost` PROCEDURE LISTAR_CLIENTES()
	Select id, nombre_completo, apellido_paterno, apellido_materno,
	tipo_documento, numero_documento, fecha_nacimiento, sexo,
	email, direccion, telefono_fijo, telefono_movil,
	situacion_laboral, estado_cliente, indicador_tarjeta, tarjeta_vclub
	From cliente_afiliado;

DROP PROCEDURE IF EXISTS INSERT_CLIENTE;
CREATE PROCEDURE INSERT_CLIENTE                
(in nombre_completo  varchar(50),
  in apellido_paterno varchar(50),
  in apellido_materno varchar(50),
  in tipo_documento varchar(3),
  in numero_documento varchar(10),
  in fecha_nacimiento datetime,
  in sexo varchar(1),
  in email varchar(50),
  in direccion varchar(100),
  in telefono_fijo varchar(20),
  in telefono_movil varchar(20),
  in situacion_laboral varchar(20),
  in estado_cliente varchar(20),
  in indicador_tarjeta varchar(1),
  in tarjeta_vclub varchar(1)
)                    
	INSERT INTO cliente_afiliado (nombre_completo, apellido_paterno, apellido_materno, tipo_documento, 
		numero_documento, fecha_nacimiento, sexo, email, direccion, telefono_fijo, telefono_movil, situacion_laboral, 
        estado_cliente, indicador_tarjeta, tarjeta_vclub, fecha_grabacion, usuario_grabacion, ventana_grabacion)
    VALUES (nombre_completo, apellido_paterno, apellido_materno, tipo_documento, 
		numero_documento, fecha_nacimiento, sexo, email, direccion, telefono_fijo, telefono_movil, situacion_laboral, 
        estado_cliente, indicador_tarjeta, tarjeta_vclub, NOW(), 'ADMINISTRADOR', 'CLIENTE');  