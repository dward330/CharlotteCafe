/* TYPESCRIPT */
import { Injectable } from '@angular/core';

@Injectable()
export class ResponsiveService {

  constructor() {
    this.callSubscribers();
    window.onresize = this.callSubscribers
  }

  private callbacks: Function[] = [];

  // taken from bootstrap's grid system
  private breakpoints = {
    xs: '(max-width:575px)',
    s: '(min-width:576px) and (max-width:767px)',
    m: '(min-width:768px) and (max-width:991px)',
    l: '(min-width:992px) and (max-width:1199px)',
    xl: '(min-width:1200px)'
  };

  private xsOrs = this.breakpoints.xs + ',' + this.breakpoints.s;

  public isXS = () => this.ruleIsMet(this.breakpoints.xs);
  public isS = () => this.ruleIsMet(this.breakpoints.s);
  public isM = () => this.ruleIsMet(this.breakpoints.m);
  public isl = () => this.ruleIsMet(this.breakpoints.l);
  public isxl = () => this.ruleIsMet(this.breakpoints.xl);

  public isSmallScreen =  () => this.ruleIsMet(this.xsOrs);

  public registerChangeCallback = (f: Function) => {
    this.callbacks.push(f);
  }


  private ruleIsMet = (rule: string) => window.matchMedia(rule).matches;

  private callSubscribers = () => {
    let len = this.callbacks.length;

    if(len == 0) {
      return;
    }

    let i = 0;

    for(;i < len; i++) {
      this.callbacks[i]();
    }
  }
}