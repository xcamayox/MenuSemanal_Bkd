
-- =====================================================
-- INSERTS INICIALES DE CONFIGURACIÓN
-- =====================================================
INSERT INTO categorias (id, nombre) VALUES 
(1, 'Entrada'), 
(2, 'Fondo');


INSERT INTO diasemana (id, nombre) VALUES
(1, 'Lunes'),
(2, 'Martes'),
(3, 'Miércoles'),
(4, 'Jueves'),
(5, 'Viernes'),
(6, 'Sábado'),
(7, 'Domingo');



-- Platos del catálogo
INSERT INTO platos (id, nombre, categoria_id) VALUES
(1, 'Ceviche', 2),
(2, 'Ceviche mixto', 2),
(3, 'Tiradito de pescado', 2),
(4, 'Papa a la huancaína', 1),
(5, 'Causa limeña', 1);

-- Ajustar la secuencia de los IDs autoincrementables
SELECT setval('categorias_id_seq', (SELECT MAX(id) FROM categorias));
SELECT setval('platos_id_seq', (SELECT MAX(id) FROM platos));

-- Asignación de prueba en el Menú Semanal
INSERT INTO menu_semanal (dia_id, plato_id, categoria_id) VALUES
(1, 5, 1), -- Lunes: Causa limeña (Entrada)
(1, 1, 2), -- Lunes: Ceviche (Fondo)
(2, 4, 1); -- Martes: Papa a la huancaína (Entrada)

use bdmenusemanal

SELECT 
    d.nombre AS dia,
    c.nombre AS categoria,
    p.nombre AS plato,
    p.foto_url
FROM menu_semanal ms
JOIN dias_semana d ON ms.dia_id = d.id
JOIN categorias c ON ms.categoria_id = c.id
JOIN platos p ON ms.plato_id = p.id
ORDER BY d.orden ASC, c.id ASC;