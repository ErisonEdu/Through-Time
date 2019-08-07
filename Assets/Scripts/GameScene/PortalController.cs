using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PortalController : MonoBehaviour {

    private Animator animator;
    
    void Awake() {
        animator = GetComponent<Animator> ();
    }

    public void abrirPortal() {
        animator.SetBool("open", true);
    }

    public void fecharPortal() {
        animator.SetBool("open", false);
    }

}