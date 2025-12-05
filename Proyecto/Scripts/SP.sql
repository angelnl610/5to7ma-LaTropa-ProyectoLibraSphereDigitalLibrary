
DELIMITER $$
CREATE PROCEDURE SP_InsertEmpleadoConDNI(
    IN pDNI VARCHAR(15),
    IN pNombre VARCHAR(100),
    IN pEdad INT,
    IN pEmail VARCHAR(150),
    IN pContrasena VARCHAR(200),
    IN pNivelPermiso INT
)
BEGIN
    INSERT INTO Empleado (DNI, Nombre, Edad, Email, Contrasena, NivelPermiso)
    VALUES (pDNI, pNombre, pEdad, pEmail, SHA2(pContrasena, 256), pNivelPermiso);
END $$


-- SP para obtener todos los empleados
DELIMITER $$
CREATE PROCEDURE SP_GetEmpleadosConDNI()
BEGIN
    SELECT IdEmpleado, DNI, Nombre, Edad, Email, Contrasena, NivelPermiso
    FROM Empleado;
END $$


-- SP para validar acceso según permiso 
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

