DELIMITER $$
CREATE PROCEDURE SP_InsertEmpleado(
    IN pNombre VARCHAR(100),
    IN pEdad INT,
    IN pEmail VARCHAR(150),
    IN pContrasena VARCHAR(200),
    IN pNivelPermiso INT
)
BEGIN
    INSERT INTO Empleado (Nombre, Edad, Email, Contrasena, NivelPermiso)
    VALUES (pNombre, pEdad, pEmail,  SHA2(pContrasena, 256), pNivelPermiso);
END $$
DELIMITER ;

-- Stored Procedure para obtener todos los empleados
DELIMITER $$
CREATE PROCEDURE SP_GetEmpleados()
BEGIN
    SELECT * FROM Empleado;
END $$
DELIMITER ;

-- Stored Procedure para validar acceso según permiso
DELIMITER $$
CREATE PROCEDURE SP_ValidarAcceso(
    IN pEmpleadoId INT,
    IN pSectorNivel INT
)
BEGIN
    SELECT 
        CASE 
            WHEN NivelPermiso >= pSectorNivel THEN 'ACCESO CONCEDIDO'
            ELSE 'ACCESO DENEGADO'
        END AS Resultado
    FROM Empleado
    WHERE IdEmpleado = pEmpleadoId;
END $$
DELIMITER ;