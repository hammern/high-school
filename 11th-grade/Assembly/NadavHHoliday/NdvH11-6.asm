IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
; --------------------------
CODESEG
start:
	mov ax, @data
	mov ds, ax
; --------------------------
	mov ah, 1
	int 21h
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov cx, 10
Print:
	mov dl, al
	mov ah, 2
	int 21h
	loop Print
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


