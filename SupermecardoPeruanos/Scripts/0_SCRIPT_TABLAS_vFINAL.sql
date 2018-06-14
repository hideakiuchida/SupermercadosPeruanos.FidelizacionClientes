create database sigesu;
use sigesu;

drop table if exists historial_compra;
drop table if exists infocorp;
drop table if exists stock_canje;
drop table if exists solicitud_afiliacion;
drop table if exists tarjetaoh;
drop table if exists calificacion_cliente;
drop table if exists cliente_afiliado;
drop table if exists catalogo_canje;
drop table if exists producto_canje;
drop table if exists categoria_canje;

create table cliente_afiliado (
  `id` int(11) not null auto_increment comment 'ID de la Tabla', 
  `nombre_completo` varchar(50) default null  comment 'Nombre Completo de Cliente',
  `apellido_paterno` varchar(50) default null  comment 'Apellido Paterno de Cliente',
  `apellido_materno` varchar(50) default null  comment 'Apellido Materno de Cliente',
  `tipo_documento` varchar(3) default null comment 'Tipo Documento de Identidad (DNI, RUC)',
  `numero_documento` varchar(10) default null comment 'Número  de Documento de Identidad',
  `fecha_nacimiento` datetime default null comment 'Fecha de Nacimiento de Cliente',
  `sexo` varchar(1) default null comment 'Sexo de Cliente',
  `email` varchar(50) default null comment 'Correo de Cliente',
  `direccion` varchar(100) default null comment 'Dirección de Cliente',
  `telefono_fijo` varchar(20) default null comment 'Teléfono fijo de Cliente',
  `telefono_movil` varchar(20) default null comment 'Teléfono móvil de Cliente',
  `situacion_laboral` varchar(20) default null comment 'Situacion laboral (independiente, empleado)',
  `estado_cliente` varchar(20) default null comment 'Status (activo, inactivo)',
  `indicador_tarjeta` varchar(1) default 'N' comment 'Status si tiene tarjeta oh (s/n)',
  `tarjeta_vclub` varchar(1) default 'N' comment 'Status si tiene tarjeta vea club (s/n)',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint cliente_afiliado_pk primary key (id)
) engine=innodb default charset=utf8 comment='Maestro de Clientes afiliados';

create table categoria_canje (
  `id` int(11) not null auto_increment  comment 'ID de la Tabla', 
  `nombre_categoria` varchar(50) default null comment 'Descripcion de Categoria',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint categoria_canje_pk primary key (id)
) engine=innodb default charset=utf8  comment='Maestro de Categoría de Productos para Canje';

create table producto_canje (
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `nom_prod_canj` varchar(50) default null comment 'Nombre del Producto para Canje',
  `id_categoria_producto` int(11) default null  comment 'ID Categoria Producto',
  `valor` decimal(16,4) default null comment 'Valor del canje de producto',
  `tipo_canje` int(11) default null comment ' Tipo de Canje (1: Producto, 0: Servicio)',
  `descripcion_producto` varchar(500) default null comment 'Descripcion detallada  del producto', 
  `condicion_canje` varchar(500) default null comment 'Condicion para canje producto',
  `dir_ruta` varchar(100) default null comment 'Ruta imagen producto',
  `img_prod` longblob comment 'imagen producto',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint producto_canje_pk primary key (id),
  constraint producto_canje_fk foreign key (id_categoria_producto) 
        references categoria_canje (id)
) engine=innodb default charset=utf8 comment='Maestro de Productos para Canje';

create table catalogo_canje ( 
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `id_catalogo` int(11) not null comment 'ID Catalogo Canje',
  `id_producto_canje` int(11) not null comment 'ID Producto Canje',
  `id_categoria_canje` int(11) not null comment 'ID Categoria Canje',
  `fecha_inicial_catalogo` datetime default null,
  `fecha_final_catalogo` datetime default null,
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint catalogo_canje_pk primary key (id),
  constraint catalogo_canje_uk unique (id_catalogo, id_producto_canje, id_categoria_canje),
  constraint catalogo_canje_fk foreign key (id_producto_canje) 
        references producto_canje (id),
  constraint catalogo_canje_fk2 foreign key (id_categoria_canje) 
        references categoria_canje (id)	
) engine=innodb default charset=utf8 comment='Maestro de Catálogo de Productos para Canje';

create table historial_compra (
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `id_cliente_historial` int(11) not null comment 'ID Cliente para su historial de compras',
  `id_producto_historial` int(11) not null comment 'ID Producto Canje',
  `id_categoria_historial` int(11) not null comment 'ID Categoria Canje',
  `importe_compra` decimal(16,4) default null comment 'Importe  de  compra',
  `fecha_compra` datetime not null comment 'Fecha de compra',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint historial_compra_pk primary key (id),
  constraint historial_compra_uk unique (id_cliente_historial, id_producto_historial, id_categoria_historial),
  constraint historial_compra_fk foreign key (id_cliente_historial) 
        references cliente_afiliado (id),
  constraint historial_compra_fk1 foreign key (id_producto_historial) 
        references producto_canje (id)	,
  constraint historial_compra_fk2 foreign key (id_categoria_historial) 
        references categoria_canje (id)		
) engine=innodb default charset=utf8 comment='Historial de Compras';

create table infocorp ( 
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `entidad_financiera` varchar(50) default null comment 'Nombre de la Entidad Financiera',
  `importe_deuda` decimal(16,4) default null comment 'Importe deuda Infocorp',
  `calificacion_sbs` int(11) default null comment 'Calificacion SBS (0,1,2,3,4)',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint infocorp_pk primary key (id)
) engine=innodb default charset=utf8 comment='Información de Infocorp';

create table solicitud_afiliacion (
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `estado_solicitud` varchar(20) default null comment 'Estado de la Solicitud (Atentido, Activo)',
  `fecha_solicitud` datetime default null  comment 'Fecha de la Solicitud',
  `codigo_solicitante` varchar(10) not null comment 'DNI del solicitante (futuro cliente)',
  `nombre_solicitante` varchar(50) default null comment 'Nombre de Solicitante',
  `paterno_solicitante` varchar(50) default null comment 'Apellido paterno solicitante',
  `materno_solicitante` varchar(50) default null comment 'Apellido materno solicitante',
  `tipo_identidad` varchar(3) default null comment 'Tipo documento identidad (DNI, CEX)',
  `numero_identidad` varchar(10) default null comment 'Número documento identidad',
  `email_solicitante` varchar(50) default null comment 'Correo electronico del solicitante',
  `telefono_solicitante` varchar(20) default null comment 'Teléfono del solicitante',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint solicitud_afiliacion_pk primary key (id)
) engine=innodb default charset=utf8  comment='Solicitud de Afiliaciones';

create table stock_canje (
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `id_stock_categoria` int(11) not null comment 'ID  de Categoria Canje',
  `id_stock_producto` int(11) not null comment 'ID  de Producto Canje',
  `stock` decimal(16,4) not null comment 'Cantidad de Stock de Productos para Canje',
  `fecha_registro` datetime default null comment 'Fecha de Registro Stock',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint stock_canje_pk primary key (id),
  constraint stock_canje_uk unique (id_stock_categoria, id_stock_producto),
  CONSTRAINT stock_canje_fk1 FOREIGN KEY (`id_stock_categoria`) REFERENCES categoria_canje (id),
  CONSTRAINT stock_canje_fk2 FOREIGN KEY (`id_stock_producto`) REFERENCES producto_canje (id)
) engine=innodb default charset=utf8 comment='Cantidad de Stock de Productos para Canje';

create table tarjetaoh (
  `id` int(11) not null auto_increment comment 'ID de la Tabla',
  `id_tarjeta_cliente` int(11)  null comment 'ID de Cliente',
  `tipo_tarjeta` varchar(20) default null comment 'Tipo de tarjeta (Gold, Normal)',
  `numero_tarjeta` bigint(20) default null comment 'Número de tarjeta',
  `bin_tarjeta` varchar(10) default null comment 'Código Bin de tarjeta',
  `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
  `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
  `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
  constraint tarjetaoh_pk primary key (id),
  constraint tarjetaoh_fk foreign key (id_tarjeta_cliente) 
        references cliente_afiliado (id)
) engine=innodb default charset=utf8 comment='Tarjetas Oh';

create table calificacion_cliente (
   `id` int not null auto_increment comment 'ID de la Tabla',
   `id_cliente` int(11) not null comment 'ID de Cliente',
   `calificacion_crediticia` varchar(20) null comment 'Calificación Crediticia del Cliente',
   `linea_credito` decimal(16,4) null comment 'Línea de Crédito del Cliente',
   `sueldo_cliente` decimal(16,4) null  comment 'Sueldo del Cliente',
   `otros_ingresos_cliente` decimal(16,4) null comment 'Otro Ingreso del Cliente',
   `estado_calificacion_cliente` int null  comment 'Estado de Calificación Crediticia del Cliente',
   `fecha_grabacion` datetime not null default now() comment 'Fecha de grabación (auditoria)',
   `usuario_grabacion` varchar(50) not null default 'system' comment 'Usuario (username) de grabación (auditoria)',
   `ventana_grabacion` varchar(15) not null default 'system' comment 'Nemónico ventana de grabación (auditoria)',
    constraint calificacion_cliente_pk primary key (id),
	constraint calificacion_cliente_fk foreign key (id_cliente) 
        references cliente_afiliado (id)
) engine=innodb default charset=utf8  comment='Calificación del Cliente';