IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
msg db "Nadav Hammer$"
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
	mov dx, offset msg
	mov ah, 9
	int 21h
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


