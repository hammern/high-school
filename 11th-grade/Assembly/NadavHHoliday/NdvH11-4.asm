IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
msg db 11, ?, 11 dup(?)
; --------------------------
CODESEG

proc CharsToCapitalChars
	mov dx, offset msg
	mov ah, 0ah
	int 21h
	
	mov [msg + 12], '$'
	
	mov cx, 10
	mov si, 2
Capital:
	sub [msg + si], 20h
	inc si
	loop Capital

	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	mov dx, offset msg + 2
	mov ah, 9
	int 21h
	
	ret
endp CharsToCapitalChars

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	call CharsToCapitalChars
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


