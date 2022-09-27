function mostrarInformacion(){

    let elementoUsuario=document.getElementById("idusuario");
    let usuario=elementoUsuario.value;

    let elementoContrasenia=document.getElementById("idclave");
    let contrasenia=elementoContrasenia.value;

    if(usuario=="" || contrasenia==""){
        alert("uy datos no diligenciados");
        return;
    }

    alert("usuario: "+usuario+", contraseña; "+contrasenia+"/hice clik");
}