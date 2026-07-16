INSERT INTO Autores (nombre, nacionalidad) 
VALUES 
('Gabriel García Márquez', 'Colombiana'),
('J.K. Rowling', 'Británica'),
('George Orwell', 'Británica');


INSERT INTO Libros (titulo, año_publicacion, autor_id) 
VALUES 
('Cien años de soledad', 1967, 1),         
('Harry Potter y la piedra filosofal', 1997, 2), 
('1984', 1949, 3),                         
('Harry Potter y el prisionero de Azkaban', 2004, 2); 


INSERT INTO Prestamos (libro_id, fecha_prestamo, fecha_devolucion) 
VALUES 
(1, '2026-07-01', '2026-07-10'), 
(2, '2026-07-15', NULL),       
(4, '2026-07-16', NULL);