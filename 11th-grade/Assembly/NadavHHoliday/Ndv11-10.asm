IDEAL
MODEL small
STACK 100h
DATASEG
; --------------------------
CRLF db 10, 13, '$' ; CR/LF
SmallLMsg db "Small letter$"
CapitalLMsg db "Capital letter$"
NumberMsg db "Number$"
OtherMsg db "Other$"
; --------------------------
CODESEG

proc InputChars
InputChar:
	mov ah, 1
	int 21h
	cmp al, 0Dh
	je EndInput
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	call CharType
	
	; Newline
	mov dx, offset CRLF
	mov ah, 9
	int 21h
	
	jmp InputChar
	
EndInput:
	ret
endp InputChars

proc CharType
	; Small letter check
SmallL:
	cmp al, 61h
	jnae CapitalL
	cmp al, 7Ah
	ja CapitalL
	
	mov dx, offset SmallLMsg
	mov ah, 9
	int 21h
	
	jmp EndCheck
	
	; Capital letter check
CapitalL:
	cmp al, 41h
	jnae Number
	cmp al, 5Ah
	ja Number
	
	mov dx, offset CapitalLMsg
	mov ah, 9
	int 21h
	
	jmp EndCheck
	
	; Number check
Number:
	cmp al, 30h
	jnae Other
	cmp al, 39h
	ja Other
	
	mov dx, offset NumberMsg
	mov ah, 9
	int 21h
	
	jmp EndCheck
	
	; Other
Other:
	mov dx, offset OtherMsg
	mov ah, 9
	int 21h
	
EndCheck:
	ret
endp CharType

start:
	mov ax, @data
	mov ds, ax
; --------------------------
	call InputChars
; --------------------------
	
exit:
	mov ax, 4c00h
	int 21h
END start


