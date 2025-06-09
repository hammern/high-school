IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
	var db 0
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
	; Ex 1
	mov al, 100
	mov al, 64h
	mov al, 01100100b
	
	mov bh, 0
	mov bl, al
	
	; Ex2
	mov al, 100
	mov bx, 2
	mov [var], al
	mov [1], al
	mov [bx], al
	mov [bx+1], al
	
	; Ex3
	mov [var], al
	mov [1], al
	mov [bx], al
	mov [bx+1], al
	;-----1-----
	mov al, 0
	mov al, [var]
	;-----2-----
	mov al, 0
	mov al, [1]
	;-----3------
	mov al, 0
	mov al, [bx]
	;------4-------
	mov al, 0
	mov al, [bx+1]
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


