/*
 * �쐬��: 2005/01/23
 *
 * TODO ���̐������ꂽ�t�@�C���̃e���v���[�g��ύX����ɂ͎��փW�����v:
 * �E�B���h�E - �ݒ� - Java - �R�[�h�E�X�^�C�� - �R�[�h�E�e���v���[�g
 */
package jp.ohtsuki.minigame;

import java.awt.Point;
import java.util.StringTokenizer;

/**
 * @author ���[�U�[�P
 *
 * TODO ���̐������ꂽ�^�R�����g�̃e���v���[�g��ύX����ɂ͎��փW�����v:
 * �E�B���h�E - �ݒ� - Java - �R�[�h�E�X�^�C�� - �R�[�h�E�e���v���[�g
 */
public class PatternReader {
	String patstr;
	StringTokenizer tokenizer;
	Point movexy = new Point();
	int kaisuu = 0;
	
	PatternReader(String str){
		patstr = str;
		tokenizer = new StringTokenizer(patstr,",");
	}
	
	Point next(){
		if (kaisuu==0){
			if (tokenizer.hasMoreTokens()==false){
				tokenizer = new StringTokenizer(patstr,",");
			}
			movexy.x = Integer.parseInt(tokenizer.nextToken());	//X�ړ��ʎ��o��
			movexy.y = Integer.parseInt(tokenizer.nextToken());	//Y�ړ��ʎ��o��
			kaisuu = Integer.parseInt(tokenizer.nextToken());	//�J��Ԃ���					
		} else {
			kaisuu = kaisuu-1;
		}
		return movexy;
	}
}