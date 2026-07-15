CREATE DATABASE LibreriaDB;
GO

USE LibreriaDB;
GO

CREATE TABLE Autores (
    autor_id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    nacionalidad VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Libros (
    libro_id INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(250) NOT NULL,
    autor_id INT NOT NULL,
    año_publicacion INT NOT NULL,
    genero VARCHAR(100),
    CONSTRAINT FK_Libros_Autores FOREIGN KEY (autor_id) REFERENCES Autores(autor_id)
);
GO

CREATE TABLE Prestamos (
    prestamo_id INT IDENTITY(1,1) PRIMARY KEY,
    libro_id INT NOT NULL,
    fecha_prestamo DATE NOT NULL,
    fecha_devolucion DATE NULL,
    CONSTRAINT FK_Prestamos_Libros FOREIGN KEY (libro_id) REFERENCES Libros(libro_id)
);
GO