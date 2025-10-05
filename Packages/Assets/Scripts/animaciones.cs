using UnityEngine;

public class Animaciones : Skills
{

    private void CambiarEstadoAnimacion(string estado)
    {
        // Pone todo en false
        animaciones.SetBool("quieto", false);
        animaciones.SetBool("caminar", false);
        animaciones.SetBool("saltar", false);

        // Activa solo el que corresponde
        animaciones.SetBool(estado, true);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("piso"))
        {
            CambiarEstadoAnimacion("saltar");
        }
    }
    protected override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);

        if (Input.GetMouseButtonDown(0) && !collision.gameObject.CompareTag("piso"))
        {
            animaciones.SetTrigger("atacar");
        }

        if (collision.gameObject.CompareTag("piso"))
        {
            
            if (horizontal != 0)
            {
                CambiarEstadoAnimacion("caminar");
            }
            else
            {
                CambiarEstadoAnimacion("quieto");
            }
        }

        if (paredesAgarre && collision.gameObject.CompareTag("paredAgarre"))
        {
            CambiarEstadoAnimacion("saltar");
        }
    }
}
